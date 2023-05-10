loadConfigurationDisplay();

document.querySelectorAll('.configurationsListLi').forEach(l => l.addEventListener('click',
    e => loadConfigurationDisplayById(e.currentTarget.dataset.id)));

async function loadConfigurationDisplay() {
    try {
        let resp = await fetch("/Calculation/LoadConfigurationDisplayHistory", {
            method: "PUT"
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
        let resp = await fetch("/Calculation/LoadConfigurationDisplayById", {
            method: "PUT",
            body: new URLSearchParams("id="+id)
        });
        if (resp.ok === true) {
            let configurationDisplay = await resp.text();
            document.getElementById('configurationHistoryDisplayDiv').innerHTML = configurationDisplay;
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