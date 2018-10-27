/*Dropdown menu*/
$('body').on('mouseenter mouseleave', '.navbar .dropdown', function (e) {
    var dropdown = $(e.target).closest('.navbar .dropdown');
    var menu = $('.dropdown-menu', dropdown);
    dropdown.addClass('show');
    menu.addClass('show');
    setTimeout(function () {
        dropdown[dropdown.is(':hover') ? 'addClass' : 'removeClass']('show');
        menu[dropdown.is(':hover') ? 'addClass' : 'removeClass']('show');
    }, 100);
});

$(function () {
    $("#news-item").first().addClass('active');
});

/* preloader */
var time = 1000;
$(window).on('load', function () {
    setTimeout(function () {
        $preloader = $('.loaderArea'),
            $loader = $preloader.find('.loader');
        $loader.fadeOut();
        $preloader.delay(0).fadeOut('slow');
    }, time)
});


$(document).ready(function () {
    setTimeout(function () {
        $('.non-loader-section').css("display", "block");
    }, time)

});