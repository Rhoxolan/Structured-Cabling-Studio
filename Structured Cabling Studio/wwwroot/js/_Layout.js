//#verticalSiteNav

verticalSiteNavResize();
document.addEventListener('DOMContentLoaded', verticalSiteNavResize);
window.addEventListener('resize', verticalSiteNavResize);
window.addEventListener('load', verticalSiteNavResize);

function verticalSiteNavResize() {
    document.getElementById('verticalSiteNav').style.minHeight
        = (window.innerHeight - document.querySelector('header').offsetHeight - document.querySelector('footer').offsetHeight) + "px";
}


//#eMailNavDisplayDiv

eMailNavDisplayDivFSChanger();
document.addEventListener('DOMContentLoaded', eMailNavDisplayDivFSChanger);
window.addEventListener('resize', eMailNavDisplayDivFSChanger);
window.addEventListener('load', eMailNavDisplayDivFSChanger);

function eMailNavDisplayDivFSChanger() {
    let eMailDiv = document.getElementById('eMailNavDisplayDiv');
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


//.navLinkText

verticalSiteNavbarUlFSChanger();
document.addEventListener('DOMContentLoaded', verticalSiteNavbarUlFSChanger);
window.addEventListener('resize', verticalSiteNavbarUlFSChanger);
window.addEventListener('load', verticalSiteNavbarUlFSChanger);

function verticalSiteNavbarUlFSChanger() {
    let navLinks = document.querySelectorAll('.navLinkText');
    if (window.innerWidth > 1399) {
        navLinks.forEach(n => n.style.fontSize = '15.5px');
    }
    else if (window.innerWidth > 575) {
        navLinks.forEach(n => n.style.fontSize = '15px');
    }
    else if (window.innerWidth > 319) {
        navLinks.forEach(n => n.style.fontSize = '12px');
    }
    else if (window.innerWidth > 0) {
        navLinks.forEach(n => n.style.fontSize = '8.1px');
    }
};


//#languageSelect

languageSelectFSChanger();
document.addEventListener('DOMContentLoaded', languageSelectFSChanger);
window.addEventListener('resize', languageSelectFSChanger);
window.addEventListener('load', languageSelectFSChanger);

function languageSelectFSChanger() {
    let select = document.getElementById('languageSelect');
    if (window.innerWidth > 575) {
        select.style.fontSize = '14px';
    }
    else if (window.innerWidth > 319) {
        select.style.fontSize = '12px';
    }
    else if (window.innerWidth > 0) {
        select.style.fontSize = '8px';
    }
};


//#siteFooterText

footerFSChanger();
document.addEventListener('DOMContentLoaded', footerFSChanger);
window.addEventListener('resize', footerFSChanger);
window.addEventListener('load', footerFSChanger);

function footerFSChanger() {
    let footer = document.getElementById('siteFooterText');
    if (window.innerWidth > 1399) {
        footer.style.fontSize = '17px';
    }
    else if (window.innerWidth > 575) {
        footer.style.fontSize = '16px';
    }
    else if (window.innerWidth > 319) {
        footer.style.fontSize = '15px';
    }
    else if (window.innerWidth > 0) {
        footer.style.fontSize = '12.5px';
    }
};