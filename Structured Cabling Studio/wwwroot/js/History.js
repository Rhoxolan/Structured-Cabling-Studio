loadConfigurationsList();
loadConfigurationDisplay();

async function loadConfigurationsList() {
    try {
        let resp = await fetch("/Calculation/LoadConfigurationsList", {
            method: "PUT"
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

