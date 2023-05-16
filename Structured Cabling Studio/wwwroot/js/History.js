loadConfigurationsListBox();
loadConfigurationDisplay();

document.addEventListener('click', (e) => {
    let li = e.target.closest('.configurationsListLi');
    if (li != null) {
        let id = li.dataset.id;
        loadConfigurationDisplayById(id);
        document.querySelectorAll('li[data-id]').forEach(l => l.classList.remove('selectedConfigurationsListLi'));
        li.classList.add('selectedConfigurationsListLi');
        document.getElementById("selectedConfigurationId").value = id;
    }
});

document.addEventListener('click', e => {
    if (e.target.id == 'deleteButton' &&
        document.getElementById('selectedConfigurationId').value != "") {
        loadDeleteConfirm();
    }
});

document.addEventListener('click', e => {
    if (e.target.id == 'deleteConfigurationButton' &&
        document.getElementById('selectedConfigurationId').value != "") {
        deleteConfiguration(document.getElementById('selectedConfigurationId').value);
    }
});

document.addEventListener('click', e => {
    if (e.target.id == 'cancelDeleteConfigurationButton' &&
        document.getElementById('selectedConfigurationId').value != "") {
        document.querySelectorAll('.deleteConfirmButton').forEach(b => b.setAttribute('disabled', 'disabled'));
        loadConfigurationsListBox().then(() => {
            let id = document.getElementById('selectedConfigurationId').value;
            document.querySelectorAll('li[data-id]').forEach(l => l.classList.remove('selectedConfigurationsListLi'));
            document.querySelector(`li[data-id="${id}"]`).classList.add('selectedConfigurationsListLi');
        });
    }
});

document.addEventListener('click', e => {
    if (e.target.id == 'deleteAllButton' &&
        document.querySelectorAll('li[data-id]').length > 0) {
        loadDeleteAllConfirm();
    }
});

document.addEventListener('click', e => {
    if (e.target.id == 'deleteAllConfigurationsButton') {
        deleteAllConfigurations();
    }
});

document.addEventListener('click', e => {
    if (e.target.id == 'cancelDeleteAllConfigurationsButton') {
        document.querySelectorAll('.deleteAllConfirmButton').forEach(b => b.setAttribute('disabled', 'disabled'));
        let id = document.getElementById('selectedConfigurationId').value; 
        if (id != "") {
            loadConfigurationsListBox().then(() => {
                let id = document.getElementById('selectedConfigurationId').value;
                document.querySelectorAll('li[data-id]').forEach(l => l.classList.remove('selectedConfigurationsListLi'));
                document.querySelector(`li[data-id="${id}"]`).classList.add('selectedConfigurationsListLi');
            });
            loadConfigurationDisplayById(document.getElementById('selectedConfigurationId').value);
        }
        else {
            loadConfigurationsListBox();
            loadConfigurationDisplay();
        }
    }
});

document.addEventListener('click', e => {
    if (e.target.id == "saveToTxtButton" &&
        document.getElementById('selectedConfigurationId').value != "" &&
        document.forms.historySaveToTxtCablingConfigurationForm != null) {
        document.forms.historySaveToTxtCablingConfigurationForm.submit();
    }
})


async function loadConfigurationsListBox() {
    try {
        let resp = await fetch("/Calculation/GetConfigurationsListBox", {
            method: "GET"
        });
        if (resp.ok === true) {
            let configurationsListBox = await resp.text();
            document.getElementById('configurationsListBoxDiv').innerHTML = configurationsListBox;
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
        let resp = await fetch("/Calculation/GetConfigurationDisplayHistory", {
            method: "GET"
        });
        if (resp.ok === true) {
            let configurationDisplay = await resp.text();
            document.getElementById('configurationHistoryDisplayDiv').innerHTML = configurationDisplay;
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

async function loadConfigurationDisplayById(id) {
    document.querySelectorAll('.historyPageButton').forEach(b => b.setAttribute('disabled', 'disabled'));
    try {
        let resp = await fetch(`/Calculation/GetConfigurationDisplayHistoryById/${id}`, {
            method: "GET"
        });
        if (resp.ok === true) {
            let configurationHistoryDisplayDiv = document.getElementById('configurationHistoryDisplayDiv');
            let configurationDisplay = await resp.text();
            configurationHistoryDisplayDiv.innerHTML = configurationDisplay;
            configurationHistoryDisplayDiv.scrollIntoView();
        }
        else {
            dataLoadingError();
        }
    } catch {
        dataLoadingError();
    }
    finally {
        document.querySelectorAll('.historyPageButton').forEach(b => b.removeAttribute('disabled'));
    }
}

async function loadDeleteConfirm() {
    document.querySelectorAll('.historyPageButton').forEach(b => b.setAttribute('disabled', 'disabled'));
    try {
        let resp = await fetch("/Calculation/GetDeleteConfigurationConfirm", {
            method: "GET"
        });
        if (resp.ok === true) {
            let deleteConfigurationConfirm = await resp.text();
            document.getElementById('configurationsListBoxDiv').innerHTML = deleteConfigurationConfirm;
        }
        else {
            dataLoadingError();
        }
    }
    catch {
        dataLoadingError();
    }
    finally {
        document.querySelectorAll('.historyPageButton').forEach(b => b.removeAttribute('disabled'));
    }
}

async function deleteConfiguration(id) {
    document.querySelectorAll('.deleteConfirmButton').forEach(b => b.setAttribute('disabled', 'disabled'));
    try {
        let resp = await fetch(`/Calculation/DeleteConfiguration/${id}`, {
            method: "DELETE"
        });
        if (resp.ok === true) {
            document.getElementById('selectedConfigurationId').value = "";
            await loadConfigurationsListBox();
            await loadConfigurationDisplay();
        }
        else {
            dataLoadingError();
        }
    }
    catch {
        dataLoadingError();
    }
    finally {
        document.querySelectorAll('.deleteConfirmButton').forEach(b => b.removeAttribute('disabled'));
    }
}

async function loadDeleteAllConfirm() {
    document.querySelectorAll('.historyPageButton').forEach(b => b.setAttribute('disabled', 'disabled'));
    try {
        let resp = await fetch("/Calculation/GetDeleteAllConfigurationsConfirm", {
            method: "GET"
        });
        if (resp.ok === true) {
            let deleteAllConfigurationsConfirm = await resp.text();
            document.getElementById('configurationsListBoxDiv').innerHTML = deleteAllConfigurationsConfirm;
            document.getElementById('configurationHistoryDisplayDiv').innerHTML = "";
        }
        else {
            dataLoadingError();
        }
    }
    catch {
        dataLoadingError();
    }
    finally {
        document.querySelectorAll('.historyPageButton').forEach(b => b.removeAttribute('disabled'));
    }
}

async function deleteAllConfigurations() {
    document.querySelectorAll('.deleteConfirmButton').forEach(b => b.setAttribute('disabled', 'disabled'));
    try {
        let resp = await fetch(`/Calculation/DeleteAllConfigurations/`, {
            method: "POST"
        });
        if (resp.ok === true) {
            document.getElementById('selectedConfigurationId').value = "";
            await loadConfigurationsListBox();
            await loadConfigurationDisplay();
        }
        else {
            dataLoadingError();
        }
    }
    catch {
        dataLoadingError();
    }
    finally {
        document.querySelectorAll('.deleteConfirmButton').forEach(b => b.removeAttribute('disabled'));
    }
}

function dataLoadingError() {
    document.getElementById("dataLoadingErrorDiv").style.setProperty('display', 'block', 'Important');
    document.getElementById("historyPageContentDiv").style.setProperty('display', 'none', 'Important');
}