document.getElementById('minPermanentLinkInput').addEventListener('blur', validateDiapason);

document.getElementById('minPermanentLinkInput').addEventListener('blur', validateStep);

document.getElementById('maxPermanentLinkInput').addEventListener('blur', validateDiapason);

document.getElementById('maxPermanentLinkInput').addEventListener('blur', validateStep);

document.getElementById('numberOfWorkplacesInput').addEventListener('blur', validateDiapason);

document.getElementById('numberOfWorkplacesInput').addEventListener('blur', validateStep);

document.getElementById('numberOfPortsInput').addEventListener('blur', validateDiapason);

document.getElementById('numberOfPortsInput').addEventListener('blur', validateStep);

document.getElementById('cableHankMeterageInput').addEventListener('blur', validateDiapason);

document.getElementById('cableHankMeterageInput').addEventListener('blur', validateStep);

document.getElementById('technologicalReserveInput').addEventListener('blur', validateDiapason);

document.getElementById('technologicalReserveInput').addEventListener('blur', validateStep);

document.getElementById('cableHankMeterageInput').addEventListener('blur', function () {
    const minPermanentLink = +document.getElementById('minPermanentLinkInput').value;
    const maxPermanentLink = +document.getElementById('maxPermanentLinkInput').value;
    const technologicalReserve = +document.getElementById('technologicalReserveInput').value;
    const ceiledAveragePermanentLink = Math.ceil((minPermanentLink + maxPermanentLink) / 2 * technologicalReserve);
    const cableHankMeterage = +this.value;
    if (cableHankMeterage < ceiledAveragePermanentLink) {
        this.value = ceiledAveragePermanentLink;
    }
});

document.getElementById('calculateButton').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('restoreDefaultsButton').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isStrictComplianceWithTheStandartCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isAnArbitraryNumberOfPortsCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isTechnologicalReserveAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isRecommendationsAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isCableHankMeterageAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('calculateButton').addEventListener('click', function () {
    document.getElementById('approvedCalculationInput').value = "approved";
});

document.getElementById('restoreDefaultsButton').addEventListener('click', function () {
    document.getElementById('approvedRestoreDefaultsInput').value = "approved";
});

document.getElementById('calculateButton').addEventListener('click', function () {
    document.getElementById('recordTimeInput').value = new Date().getTime().toString();
});

document.getElementById('isStrictComplianceWithTheStandartCheckBox').addEventListener('click', calculateFormSubmit);

document.getElementById('isAnArbitraryNumberOfPortsCheckBox').addEventListener('click', calculateFormSubmit);

document.getElementById('isTechnologicalReserveAvailabilityCheckBox').addEventListener('click', calculateFormSubmit);

document.getElementById('isRecommendationsAvailabilityCheckBox').addEventListener('click', calculateFormSubmit);

document.getElementById('isCableHankMeterageAvailabilityCheckBox').addEventListener('click', calculateFormSubmit);

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
        e.target.value = (Math.floor(inputValue * 100) / 100).toFixed(2);
    }
}

function calculateFormSubmit() {
    document.forms["calculateForm"].submit();
}

function removeDisabledAttributesFromAllInputs() {
    document.querySelectorAll('input').forEach(i => i.removeAttribute('disabled'));
}