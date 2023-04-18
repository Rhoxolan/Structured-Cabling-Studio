//.navLinkText

let navLinks = document.querySelectorAll('.navLinkText');

document.addEventListener('load', verticalSiteNavbarUlFSChanger);
window.addEventListener('resize', verticalSiteNavbarUlFSChanger);
window.addEventListener('load', verticalSiteNavbarUlFSChanger);
navLinks.forEach(n => n.addEventListener('load', verticalSiteNavbarUlFSChanger));

function verticalSiteNavbarUlFSChanger() {
    if (window.innerWidth > 1399) {
        navLinks.forEach(n => n.style.fontSize = '16px');
    }
    else if (window.innerWidth > 575) {
        navLinks.forEach(n => n.style.fontSize = '15px');
    }
    else if (window.innerWidth > 319) {
        navLinks.forEach(n => n.style.fontSize = '12px');
    }
    else if (window.innerWidth > 0) {
        navLinks.forEach(n => n.style.fontSize = '8px');
    }
};


//#siteFooterText

let footer = document.getElementById('siteFooterText');

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