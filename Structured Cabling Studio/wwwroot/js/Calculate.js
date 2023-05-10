loadCalculateForm();
loadConfigurationDisplay();

document.addEventListener('focusout', e => {
    if (e.target.id === "minPermanentLinkInput") {
        validateDiapason(e);
        validateStep(e);
        checkCableHankMeterage();
    }
});

document.addEventListener('focusout', e => {
    if (e.target.id === "maxPermanentLinkInput") {
        validateDiapason(e);
        validateStep(e);
        checkCableHankMeterage();
    }
});

document.addEventListener('focusout', e => {
    if (e.target.id === "numberOfWorkplacesInput") {
        validateDiapason(e);
        validateStep(e);
    }
});

document.addEventListener('focusout', e => {
    if (e.target.id === "numberOfPortsInput") {
        validateDiapason(e);
        validateStep(e);
    }
});

document.addEventListener('focusout', e => {
    if (e.target.id === "cableHankMeterageInput") {
        validateDiapason(e);
        validateStep(e);
        checkCableHankMeterage();
    }
});

document.addEventListener('focusout', e => {
    if (e.target.id === "technologicalReserveInput") {
        validateDiapason(e);
        validateStep(e);
        checkCableHankMeterage();
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "restoreDefaultsButton") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Configurations/RestoreDefaultsCalculateForm");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isStrictComplianceWithTheStandartCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Configurations/PutStrictComplianceWithTheStandart");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isAnArbitraryNumberOfPortsCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Configurations/PutAnArbitraryNumberOfPorts");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isTechnologicalReserveAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Configurations/PutTechnologicalReserveAvailability");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isRecommendationsAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Configurations/PutRecommendationsAvailability");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isCableHankMeterageAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Configurations/PutCableHankMeterageAvailability");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "calculateButton") {
        removeDisabledAttributesFromAllInputs();
        document.getElementById('recordTimeInput').value = new Date().getTime().toString();
    }
});

document.addEventListener('submit', e => {
    if (e.target.id === "calculateForm") {
        e.preventDefault();
        validateDiapason(e);
        validateStep(e);
        checkCableHankMeterage();
        calculate();
    }
});

async function loadCalculateForm() {
    try {
        let resp = await fetch("Configurations/LoadCalculateForm", {
            method: "PUT"
        });
        if (resp.ok === true) {
            let calculateForm = await resp.text();
            document.getElementById('calculateFormDiv').innerHTML = calculateForm;
        }
        else {
            alert("Data loading error!");
        }
    }
    catch {
        alert("Data loading error!");
    }
}

async function loadConfigurationDisplay() {
    try {
        let resp = await fetch("Configurations/LoadConfigurationDisplayCalculate", {
            method: "PUT"
        });
        if (resp.ok === true) {
            let configurationDisplay = await resp.text();
            document.getElementById('configurationDisplayDiv').innerHTML = configurationDisplay;
        }
        else {
            alert("Data loading error!");
        }
    }
    catch {
        alert("Data loading error!");
    }
}

async function editCalculateForm(path) {
    document.getElementById('calculateFormDiv').classList.add('formLoading');
    try {
        let resp = await fetch(path, {
            method: "PUT",
            body: new FormData(document.forms.calculateForm)
        });
        if (resp.ok === true) {
            let calculateForm = await resp.text();
            document.getElementById('calculateFormDiv').innerHTML = calculateForm;
        }
        else {
            alert("Data loading error!");
        }
    } catch {
        alert("Data loading error!");
    }
    finally {
        document.getElementById('calculateFormDiv').classList.remove('formLoading');
    }
}

async function calculate() {
    document.getElementById('calculateFormDiv').classList.add('formLoading');
    try {
        let resp = await fetch("Configurations/Calculate", {
            method: "POST",
            body: new FormData(document.forms.calculateForm)
        });
        if (resp.ok === true) {
            let configurationDisplay = await resp.text();
            let configurationDisplayDiv = document.getElementById('configurationDisplayDiv');
            configurationDisplayDiv.innerHTML = configurationDisplay;
            configurationDisplayDiv.scrollIntoView();
        }
        else {
            alert("Data loading error!");
        }
    } catch {
        alert("Data loading error!");
    }
    finally {
        document.getElementById('calculateFormDiv').classList.remove('formLoading');
    }
}

function validateDiapason(e) {
    if (parseFloat(e.target.value) > parseFloat(e.target.getAttribute('max'))) {
        e.target.value = e.target.getAttribute('max');
    }
    if (parseFloat(e.target.value) < parseFloat(e.target.getAttribute('min'))) {
        e.target.value = e.target.getAttribute('min');
    }
}

function validateStep(e) {
    const inputValue = parseFloat(e.target.value);
    const stepValue = parseFloat(e.target.getAttribute('step'));
    if (stepValue === 1) {
        if (!Number.isInteger(inputValue)) {
            e.target.value = Math.floor(inputValue);
        }
    }
    else if (stepValue === 0.01) {
        e.target.value = parseFloat(e.target.value).toFixed(2);
    }
}

function checkCableHankMeterage() {
    const value = document.getElementById('cableHankMeterageInput').value
    if (value !== "" && !isNaN(value)) {
        const minPermanentLink = +document.getElementById('minPermanentLinkInput').value;
        const maxPermanentLink = +document.getElementById('maxPermanentLinkInput').value;
        const technologicalReserve = +document.getElementById('technologicalReserveInput').value;
        const ceiledAveragePermanentLink = Math.ceil((minPermanentLink + maxPermanentLink) / 2 * technologicalReserve);
        const cableHankMeterage = +document.getElementById('cableHankMeterageInput').value;
        if (cableHankMeterage < ceiledAveragePermanentLink) {
            document.getElementById('cableHankMeterageInput').value = ceiledAveragePermanentLink;
        }
    }
}

function removeDisabledAttributesFromAllInputs() {
    document.querySelectorAll('input').forEach(i => i.removeAttribute('disabled'));
}