//#verticalSiteNav

verticalSiteNavResize();
document.addEventListener('DOMContentLoaded', verticalSiteNavResize);
window.addEventListener('resize', verticalSiteNavResize);
window.addEventListener('load', verticalSiteNavResize);

function verticalSiteNavResize() {
    document.getElementById('verticalSiteNav').style.minHeight
        = (window.innerHeight - document.querySelector('header').offsetHeight - document.querySelector('footer').offsetHeight) + "px";
}


//#brandDisplay

brandDisplayFSChanger();
document.addEventListener('DOMContentLoaded', brandDisplayFSChanger);
window.addEventListener('resize', brandDisplayFSChanger);
window.addEventListener('load', brandDisplayFSChanger);

function brandDisplayFSChanger() {
    let brandDiv = document.getElementById("brandDisplay");
    let windowWidth = window.innerWidth;
    if (windowWidth > 1399) {
        brandDiv.style.fontSize = "26px";
    }
    else if (windowWidth > 1199) {
        brandDiv.style.fontSize = "25px";
    }
    else if (windowWidth > 575) {
        brandDiv.style.fontSize = "24px";
    }
    else if (windowWidth > 399) {
        brandDiv.style.fontSize = "19px";
    }
    else if (windowWidth > 359) {
        brandDiv.style.fontSize = "17px";
    }
    else if (windowWidth > 319) {
        brandDiv.style.fontSize = "14.5px";
    }
    else if (windowWidth > 299) {
        brandDiv.style.fontSize = "13.1px";
    }
    else if (windowWidth > 279) {
        brandDiv.style.fontSize = "11.5px";
    }
    else if (windowWidth > 259) {
        brandDiv.style.fontSize = "9.5px";
    }
    else if (windowWidth > 239) {
        brandDiv.style.fontSize = "8.3px";
    }
    else if (windowWidth > 0) {
        brandDiv.style.fontSize = "7.3px";
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