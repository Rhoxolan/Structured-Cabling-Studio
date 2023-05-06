LoadCalculateForm();

async function LoadCalculateForm() {
    let resp = await fetch("Calculation/GetCalculateForm", {
        method: "POST"
    });
    if (resp.ok === true) {
        let calculateForm = await resp.text();
        document.getElementById('calculateFormDiv').innerHTML = calculateForm;
    }
}

document.getElementById('minPermanentLinkInput').addEventListener('blur', validateDiapason);

document.getElementById('minPermanentLinkInput').addEventListener('blur', validateStep);

document.getElementById('minPermanentLinkInput').addEventListener('blur', checkCableHankMeterage);

document.getElementById('maxPermanentLinkInput').addEventListener('blur', validateDiapason);

document.getElementById('maxPermanentLinkInput').addEventListener('blur', validateStep);

document.getElementById('maxPermanentLinkInput').addEventListener('blur', checkCableHankMeterage);

document.getElementById('numberOfWorkplacesInput').addEventListener('blur', validateDiapason);

document.getElementById('numberOfWorkplacesInput').addEventListener('blur', validateStep);

document.getElementById('numberOfPortsInput').addEventListener('blur', validateDiapason);

document.getElementById('numberOfPortsInput').addEventListener('blur', validateStep);

document.getElementById('cableHankMeterageInput').addEventListener('blur', validateDiapason);

document.getElementById('cableHankMeterageInput').addEventListener('blur', validateStep);

document.getElementById('cableHankMeterageInput').addEventListener('blur', checkCableHankMeterage);

document.getElementById('technologicalReserveInput').addEventListener('blur', validateDiapason);

document.getElementById('technologicalReserveInput').addEventListener('blur', validateStep);

document.getElementById('technologicalReserveInput').addEventListener('blur', checkCableHankMeterage);

document.getElementById('calculateButton').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('restoreDefaultsButton').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isStrictComplianceWithTheStandartCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isAnArbitraryNumberOfPortsCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isTechnologicalReserveAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isRecommendationsAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isCableHankMeterageAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('calculateButton').addEventListener('click', function () {
    document.getElementById('recordTimeInput').value = new Date().getTime().toString();
});

document.forms.calculateForm.addEventListener('submit', pleaseWaitDisplay);


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