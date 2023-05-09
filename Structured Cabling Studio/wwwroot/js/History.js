loadConfigurationsList();

async function loadConfigurationsList() {
    try {
        let resp = await fetch("Calculation/LoadConfigurationsList", {
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