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
        editCalculateForm("Calculation/RestoreDefaultsCalculateForm");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isStrictComplianceWithTheStandartCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Calculation/PutStrictComplianceWithTheStandart");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isAnArbitraryNumberOfPortsCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Calculation/PutAnArbitraryNumberOfPorts");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isTechnologicalReserveAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Calculation/PutTechnologicalReserveAvailability");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isRecommendationsAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Calculation/PutRecommendationsAvailability");
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isCableHankMeterageAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
        editCalculateForm("Calculation/PutCableHankMeterageAvailability");
    }
});

document.addEventListener('submit', e => {
    if (e.target.id === "calculateForm") {
        e.preventDefault();
        document.getElementById('recordTimeInput').value = new Date().getTime().toString();
        validateDiapason(e);
        validateStep(e);
        checkCableHankMeterage();
        let disabledInputs = removeDisabledAttributesFromAllInputs();
        calculate().then(() => {
            disabledInputs.forEach(i => i.setAttribute('disabled', 'disabled'));
        });
    }
});

async function loadCalculateForm() {
    try {
        let resp = await fetch("Calculation/GetCalculateForm", {
            method: "GET"
        });
        if (resp.ok === true) {
            let calculateForm = await resp.text();
            document.getElementById('calculateFormDiv').innerHTML = calculateForm;
            document.getElementById("loadingDiv").style.setProperty('display', 'none', 'Important');
        }
        else {
            dataLoadingError();
        }
    }
    catch {
        dataLoadingError();
    }
}

async function loadConfigurationDisplay() {
    try {
        let resp = await fetch("Calculation/GetConfigurationDisplayCalculate", {
            method: "GET"
        });
        if (resp.ok === true) {
            let configurationDisplay = await resp.text();
            document.getElementById('configurationDisplayDiv').innerHTML = configurationDisplay;
            document.getElementById("loadingDiv").style.setProperty('display', 'none', 'Important');
        }
        else {
            dataLoadingError();
        }
    }
    catch {
        dataLoadingError();
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
            dataLoadingError();
        }
    } catch {
        dataLoadingError();
    }
    finally {
        document.getElementById('calculateFormDiv').classList.remove('formLoading');
    }
}

async function calculate() {
    document.getElementById('calculateFormDiv').classList.add('formLoading');
    try {
        let resp = await fetch("Calculation/Calculate", {
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
            dataLoadingError();
        }
    } catch {
        dataLoadingError();
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
    let disabledInputs = document.querySelectorAll('input[disabled]');
    disabledInputs.forEach(i => i.removeAttribute('disabled'));
    return disabledInputs;
}

function dataLoadingError() {
    document.getElementById("dataLoadingErrorDiv").style.setProperty('display', 'block', 'Important');
    document.getElementById("calculatePageContentDiv").style.setProperty('display', 'none', 'Important');
}