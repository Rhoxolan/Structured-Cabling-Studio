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
        return 1.9;
    }
    else if (textLength > 63) { //Max 127
        return 3.8;
    }
    else if (textLength > 45) { //Max 63
        return 7;
    }
    else if (textLength > 31) { //Max 45
        return 9.1;
    }
    else if (textLength > 0) { //Max 31
        return 15;
    }
});

