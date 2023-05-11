loadConfigurationsListBox();
loadConfigurationDisplay();

document.addEventListener('click', (e) => {
    let li = e.target.closest('.configurationsListLi');
    if (li != null) {
        loadConfigurationDisplayById(li.dataset.id);
    }
});

async function loadConfigurationsListBox() {
    try {
        let resp = await fetch("/Configurations/GetConfigurationsListBox", {
            method: "GET"
        });
        if (resp.ok === true) {
            let configurationsListBox = await resp.text();
            document.getElementById('configurationsListBoxDiv').innerHTML = configurationsListBox;
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
        let resp = await fetch("/Configurations/GetConfigurationDisplayHistory", {
            method: "GET"
        });
        if (resp.ok === true) {
            let configurationDisplay = await resp.text();
            document.getElementById('configurationHistoryDisplayDiv').innerHTML = configurationDisplay;
        }
        else {
            alert("Data loading error!");
        }
    }
    catch {
        alert("Data loading error!");
    }
}

async function loadConfigurationDisplayById(id) {
    document.querySelectorAll('.historyPageButton').forEach(b => b.setAttribute('disabled', 'disabled'));
    try {
        let resp = await fetch(`/Configurations/GetConfigurationDisplayHistoryById/${id}`, {
            method: "GET"
        });
        if (resp.ok === true) {
            let configurationHistoryDisplayDiv = document.getElementById('configurationHistoryDisplayDiv');
            let configurationDisplay = await resp.text();
            configurationHistoryDisplayDiv.innerHTML = configurationDisplay;
            configurationHistoryDisplayDiv.scrollIntoView();
            document.querySelectorAll('li[data-id]').forEach(l => l.classList.remove('selectedConfigurationsListLi'));
            document.querySelector(`li[data-id="${id}"]`).classList.add('selectedConfigurationsListLi');
        }
        else {
            alert("Data loading error!");
        }
    } catch {
        alert("Data loading error!");
    }
    finally {
        document.querySelectorAll('.historyPageButton').forEach(b => b.removeAttribute('disabled'));
    }
}