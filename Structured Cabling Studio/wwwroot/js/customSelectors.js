$('.verticalSiteContent').css('min-height', $(window).height() - $('header').outerHeight() - $('footer').outerHeight());

$(window).on('resize', function () {
    $('.verticalSiteContent').css('min-height', $(window).height() - $('header').outerHeight() - $('footer').outerHeight());
});

$('.verticalSiteContent').on('resize', function () {
    $(this).css('min-height', $(window).height() - $('header').outerHeight() - $('footer').outerHeight());
});

