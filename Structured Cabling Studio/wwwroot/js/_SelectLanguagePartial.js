//#languageSelect

languageSelectFSChanger();
document.addEventListener('DOMContentLoaded', languageSelectFSChanger);
window.addEventListener('resize', languageSelectFSChanger);
window.addEventListener('load', languageSelectFSChanger);

function languageSelectFSChanger() {
    let select = document.getElementById('languageSelect');
    if (window.innerWidth > 575) {
        //select.style.fontSize = '14px';
        select.style.fontSize = '0.9rem';
    }
    else if (window.innerWidth > 319) {
        //select.style.fontSize = '12px';
        select.style.fontSize = '0.85rem';
    }
    else if (window.innerWidth > 0) {
        //select.style.fontSize = '8px';
        select.style.fontSize = '0.55rem';
    }
};