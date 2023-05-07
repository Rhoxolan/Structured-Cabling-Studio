LoadCalculateForm();

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
    if (e.target.id === "technologicalReserveInput") {
        removeDisabledAttributesFromAllInputs();
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "restoreDefaultsButton") {
        removeDisabledAttributesFromAllInputs();
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isStrictComplianceWithTheStandartCheckBox") {
        removeDisabledAttributesFromAllInputs();
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isAnArbitraryNumberOfPortsCheckBox") {
        removeDisabledAttributesFromAllInputs();
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isTechnologicalReserveAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isRecommendationsAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "isCableHankMeterageAvailabilityCheckBox") {
        removeDisabledAttributesFromAllInputs();
    }
});

document.addEventListener('click', e => {
    if (e.target.id === "calculateButton") {
        document.getElementById('recordTimeInput').value = new Date().getTime().toString();
        pleaseWaitDisplay();
    }
});

async function LoadCalculateForm() {
    let resp = await fetch("Calculation/GetCalculateForm", {
        method: "POST"
    });
    if (resp.ok === true) {
        let calculateForm = await resp.text();
        document.getElementById('calculateFormDiv').innerHTML = calculateForm;
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

function pleaseWaitDisplay() {
    document.getElementById('pleaseWaitTotalDiv').style.setProperty("display", "flex", "important");
}