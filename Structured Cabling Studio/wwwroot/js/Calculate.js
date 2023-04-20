document.getElementById('calculateButton').addEventListener('click', function () {
    document.getElementById('approvedCalculationInput').value = 'approved';
});

document.getElementById('restoreDefaultsButton').addEventListener('click', function () {
    document.getElementById('approvedRestoreDefaultsInput').value = 'approved';
});

document.getElementById('isStrictComplianceWithTheStandartCheckBox').addEventListener('click', function () {
    document.getElementById('calculateForm').submit();
})

document.getElementById('isAnArbitraryNumberOfPortsCheckBox').addEventListener('click', function () {
    document.getElementById('calculateForm').submit();
})