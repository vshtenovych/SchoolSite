/*News slider*/
$('#recipeCarousel').carousel({
    interval: 10000000
})

$('#news-carousel .carousel .carousel-item').each(function () {
    if ($(window).width() >= 768) {
        var next = $(this).next();
        for (var i = 0; i < 2; i++) {

            if (!next.length) {
                next = $(this).siblings(':first');
            }

            next.children(':first-child').clone().appendTo($(this));
            next = next.next();
        }
    }

});

/*Slider Swipe*/
$(document).ready(function () {
    $(".carousel").swipe({
        swipeLeft: function () {
            $(this).carousel("next");
        },
        swipeRight: function () {
            $(this).carousel("prev");
        },
        allowPageScroll: "vertical"
    });
});

/*myscropt*/
$('ol').on('click', 'li', function () {
    $('#recipeCarousel').addClass("tr3");


});


$(".carousel-control-prev, .carousel-control-next").click(function () {
    $('#recipeCarousel').removeClass("tr3");
});


$(".carousel-item").click(function () {
    alert($(this).attr("news-id"));
});
