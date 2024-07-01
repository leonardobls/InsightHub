function init() {
    changeFooterColor();
    productionCarousel();
}

function changeFooterColor() {
    $(".footer").addClass("is-white");
}

function productionCarousel() {


    $(".js-production-carousel").slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
        row: 0,

    });

}


$(() => {
    init();
});