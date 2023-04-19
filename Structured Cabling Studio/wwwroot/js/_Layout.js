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
        //brandDiv.style.fontSize = "26px";
        brandDiv.style.fontSize = "1.7rem";
    }
    else if (windowWidth > 1199) {
        //brandDiv.style.fontSize = "25px";
        brandDiv.style.fontSize = "1.6rem";
    }
    else if (windowWidth > 575) {
        //brandDiv.style.fontSize = "24px";
        brandDiv.style.fontSize = "1.5rem";
    }
    else if (windowWidth > 399) {
        //brandDiv.style.fontSize = "19px";
        brandDiv.style.fontSize = "1.3rem";
    }
    else if (windowWidth > 359) {
        //brandDiv.style.fontSize = "17px";
        brandDiv.style.fontSize = "1.25rem";
    }
    else if (windowWidth > 319) {
        //brandDiv.style.fontSize = "14.5px";
        brandDiv.style.fontSize = "1.05rem";
    }
    else if (windowWidth > 299) {
        //brandDiv.style.fontSize = "13.1px";
        brandDiv.style.fontSize = "0.9rem";
    }
    else if (windowWidth > 279) {
        //brandDiv.style.fontSize = "11.5px";
        brandDiv.style.fontSize = "0.8rem";
    }
    else if (windowWidth > 259) {
        //brandDiv.style.fontSize = "9.5px";
        brandDiv.style.fontSize = "0.7rem";
    }
    else if (windowWidth > 239) {
        //brandDiv.style.fontSize = "8.3px";
        brandDiv.style.fontSize = "0.55rem";
    }
    else if (windowWidth > 0) {
        //brandDiv.style.fontSize = "7.3px";
        brandDiv.style.fontSize = "0.5rem";
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
        //navLinks.forEach(n => n.style.fontSize = '15.5px');
        navLinks.forEach(n => n.style.fontSize = '1rem');
    }
    else if (window.innerWidth > 991) {
        //navLinks.forEach(n => n.style.fontSize = '15px');
        navLinks.forEach(n => n.style.fontSize = '1rem');
    }
    else if (window.innerWidth > 785) {
        //navLinks.forEach(n => n.style.fontSize = '13.5px');
        navLinks.forEach(n => n.style.fontSize = '0.9rem');
    }
    else if (window.innerWidth > 575) {
        //navLinks.forEach(n => n.style.fontSize = '12.5px');
        navLinks.forEach(n => n.style.fontSize = '0.9rem');
    }
    else if (window.innerWidth > 319) {
        //navLinks.forEach(n => n.style.fontSize = '12px');
        navLinks.forEach(n => n.style.fontSize = '0.85rem');
    }
    else if (window.innerWidth > 0) {
        //navLinks.forEach(n => n.style.fontSize = '8.1px');
        navLinks.forEach(n => n.style.fontSize = '0.7rem');
    }
};


//.verticalSiteNavbarText

verticalSiteNavbarLiFSChanger();
document.addEventListener('DOMContentLoaded', verticalSiteNavbarLiFSChanger);
window.addEventListener('resize', verticalSiteNavbarLiFSChanger);
window.addEventListener('load', verticalSiteNavbarLiFSChanger);

function verticalSiteNavbarLiFSChanger() {
    let verticalNavbarLis = document.querySelectorAll(".verticalSiteNavbarText");
    let windowWidth = window.innerWidth;
    if (windowWidth < 321) {
        //verticalNavbarLis.forEach(l => l.style.fontSize = "11px");
        verticalNavbarLis.forEach(l => l.style.fontSize = "0.8rem");
    }
    else {
        //verticalNavbarLis.forEach(l => l.style.fontSize = "19px");
        verticalNavbarLis.forEach(l => l.style.fontSize = "1.25rem");
    }
}


//#siteFooterText

footerFSChanger();
document.addEventListener('DOMContentLoaded', footerFSChanger);
window.addEventListener('resize', footerFSChanger);
window.addEventListener('load', footerFSChanger);

function footerFSChanger() {
    let footer = document.getElementById('siteFooterText');
    if (window.innerWidth > 1399) {
        //footer.style.fontSize = '17px';
        footer.style.fontSize = '1rem';
    }
    else if (window.innerWidth > 575) {
        //footer.style.fontSize = '16px';
        footer.style.fontSize = '1rem';
    }
    else if (window.innerWidth > 319) {
        //footer.style.fontSize = '15px';
        footer.style.fontSize = '1rem';
    }
    else if (window.innerWidth > 0) {
        //footer.style.fontSize = '12.5px';
        footer.style.fontSize = '0.9rem';
    }
};