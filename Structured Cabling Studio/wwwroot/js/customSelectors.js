//.verticalSiteContent

verticalSiteContentResize();

$(document).ready(verticalSiteContentResize);

$(window).on('resize load', verticalSiteContentResize);

$('footer, header, .verticalSiteContent').on('resize load', verticalSiteContentResize);

function verticalSiteContentResize() {
    $('.verticalSiteContent').css('min-height', getverticalSiteContentSize());
}

function getverticalSiteContentSize() {
    return $(window).height() - $('header').outerHeight() - $('footer').outerHeight();
}


//.eMailNavDisplay

$('.eMailNavDisplay').css('font-size', function () {
    let textLength = $(this).prop("innerText").length;
    if (textLength > 127 && textLength <= 255) {
        return 2;
    }
    else if (textLength > 63) { //Max 127
        return 4;
    }
    else if (textLength > 45) { //Max 63
        return 8;
    }
    else if (textLength > 31) { //Max 45
        return 12;
    }
    else if (textLength > 0) { //Max 31
        return 15;
    }
});


//.brandDisplay

resizeBrandDisplay();

$(document).ready(resizeBrandDisplay);

$(window).on('resize load', resizeBrandDisplay);

$('header, .brandDisplay').on('resize load', resizeBrandDisplay);

function resizeBrandDisplay() {
    $('.brandDisplay').css('font-size', getBrandDisplayFS);
};

function getBrandDisplayFS() {
    if ($(window).width() < 576) {
        return 17;
    }
    else {
        return 25;
    }

    //Сделать лесенку ифэлсеиф и уменьшить fs для экранов меньше, например, 360-и
}