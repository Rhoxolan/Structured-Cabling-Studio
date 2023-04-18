//.navLinkText

let navLinks = document.querySelectorAll('.navLinkText');

verticalSiteNavbarUlFSChanger();
document.addEventListener('load', verticalSiteNavbarUlFSChanger);
window.addEventListener('resize', verticalSiteNavbarUlFSChanger);
window.addEventListener('load', verticalSiteNavbarUlFSChanger);
navLinks.forEach(n => n.addEventListener('load', verticalSiteNavbarUlFSChanger));

function verticalSiteNavbarUlFSChanger() {
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

let select = document.getElementById('languageSelect');

languageSelectFSChanger();
document.addEventListener('load', languageSelectFSChanger);
window.addEventListener('resize', languageSelectFSChanger);
window.addEventListener('load', languageSelectFSChanger);
select.addEventListener('load', languageSelectFSChanger);

function languageSelectFSChanger() {
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

let footer = document.getElementById('siteFooterText');

footerFSChanger();
document.addEventListener('load', footerFSChanger);
window.addEventListener('resize', footerFSChanger);
window.addEventListener('load', footerFSChanger);
footer.addEventListener('load', footerFSChanger);

function footerFSChanger() {
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