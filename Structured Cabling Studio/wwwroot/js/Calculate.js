loadCalculateForm();

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

document.addEventListener('click', e => {
    if (e.target.id === "calculateButton") {
        document.getElementById('recordTimeInput').value = new Date().getTime().toString();
    }
});

async function loadCalculateForm() {
    let resp = await fetch("Calculation/LoadCalculateForm", {
        method: "PUT"
    });
    if (resp.ok === true) {
        let calculateForm = await resp.text();
        document.getElementById('calculateFormDiv').innerHTML = calculateForm;
    }
}

async function editCalculateForm(path) {
    overlayDisplay();
    try {
        let resp = await fetch(path, {
            method: "PUT",
            body: new FormData(document.forms.calculateForm)
        });
        if (resp.ok === true) {
            let calculateForm = await resp.text();
            document.getElementById('calculateFormDiv').innerHTML = calculateForm;
            //overlayHide();
        }
        else {
            alert("Data loading error!");
        }
    } catch {
        alert("Data loading error!");
    }
    finally {
        //overlayHide();
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

function overlayDisplay() {
    let overlayDiv = document.getElementById('overlayDiv');
    let mainContainerDiv = document.getElementById('mainContainerDiv');

    //overlayDiv.clientTop = mainContainerDiv.offsetTop;
    //overlayDiv.clientLeft = mainContainerDiv.offsetLeft;
    //overlayDiv.clientHeight = mainContainerDiv.offsetHeight;
    //overlayDiv.clientWidth = mainContainerDiv.offsetWidth;

    //overlayDiv.style.setProperty("display", "flex", "important");
    //overlayDiv.style.setProperty("top", mainContainerDiv.offsetTop);
    //overlayDiv.style.setProperty("left", mainContainerDiv.offsetLeft);
    //overlayDiv.style.setProperty("height", mainContainerDiv.offsetHeight);
    //overlayDiv.style.setProperty("width", mainContainerDiv.offsetWidth);

    overlayDiv.style.setProperty("display", "flex", "important");
    overlayDiv.style.top = mainContainerDiv.offsetTop + "px";
    overlayDiv.style.left = mainContainerDiv.offsetLeft + "px";
    overlayDiv.style.height = mainContainerDiv.offsetHeight + "px";
    overlayDiv.style.width = mainContainerDiv.offsetWidth + "px";


    debugger;
}

function overlayHide() {
    document.getElementById('overlayDiv').style.setProperty("display", "none", "important");
}