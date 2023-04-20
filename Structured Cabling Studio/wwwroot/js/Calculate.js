document.getElementById('calculateButton').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('restoreDefaultsButton').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isStrictComplianceWithTheStandartCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isAnArbitraryNumberOfPortsCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isTechnologicalReserveAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isRecommendationsAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('isCableHankMeterageAvailabilityCheckBox').addEventListener('click', removeDisabledAttributesFromAllInputs);

document.getElementById('calculateButton').addEventListener('click', function () {
    document.getElementById('approvedCalculationInput').value = 'approved';
});

document.getElementById('restoreDefaultsButton').addEventListener('click', function () {
    document.getElementById('approvedRestoreDefaultsInput').value = 'approved';
});

document.getElementById('isStrictComplianceWithTheStandartCheckBox').addEventListener('click', calculateFormSubmit);

document.getElementById('isAnArbitraryNumberOfPortsCheckBox').addEventListener('click', calculateFormSubmit);

document.getElementById('isTechnologicalReserveAvailabilityCheckBox').addEventListener('click', calculateFormSubmit);

document.getElementById('isRecommendationsAvailabilityCheckBox').addEventListener('click', calculateFormSubmit);

document.getElementById('isCableHankMeterageAvailabilityCheckBox').addEventListener('click', calculateFormSubmit);

function calculateFormSubmit() {
    document.getElementById('calculateForm').submit();
}

function removeDisabledAttributesFromAllInputs() {
    document.querySelectorAll('input').forEach(i => i.removeAttribute('disabled'));
}