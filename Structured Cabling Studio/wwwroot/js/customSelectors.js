$('.siteContent').css('height', $(window).height() - $('header').outerHeight() - $('footer').outerHeight());

$(window).on('resize', function () {
    $('.siteContent').css('height', $(window).height() - $('header').outerHeight() - $('footer').outerHeight());
});

$('.siteContent').on('resize', function () {
    $(this).css('height', $(window).height() - $('header').outerHeight() - $('footer').outerHeight());
});

