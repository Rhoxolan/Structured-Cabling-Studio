//#signInWithGoogleA

document.addEventListener('click', e => {
    if (e.target.id === "signInWithGoogleA") {
        document.getElementById('signInWithGoogleForm').submit();
    }
});


//#eMailNavDisplayDiv

eMailNavDisplayDivFSChanger();
document.addEventListener('DOMContentLoaded', eMailNavDisplayDivFSChanger);
window.addEventListener('resize', eMailNavDisplayDivFSChanger);
window.addEventListener('load', eMailNavDisplayDivFSChanger);

function eMailNavDisplayDivFSChanger() {
    let eMailDiv = document.getElementById('eMailNavDisplayDiv');
    if (eMailDiv != null) {
        let textLength = eMailDiv.innerText.length;
        if (textLength > 127 && textLength <= 255) {
            eMailDiv.style.fontSize = "2px";
        }
        else if (textLength > 63) { //Max 127
            eMailDiv.style.fontSize = "4px";
        }
        else if (textLength > 45) { //Max 63
            eMailDiv.style.fontSize = "8px";
        }
        else if (textLength > 31) { //Max 45
            eMailDiv.style.fontSize = "12px";
        }
        else if (textLength > 0) { //Max 31
            eMailDiv.style.fontSize = "15px";
        }
    }
}