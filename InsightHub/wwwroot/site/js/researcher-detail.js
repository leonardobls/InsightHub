function init() {
    changeFooterColor();
    projectsCarousel();
}

function changeFooterColor() {
    $(".footer").addClass("is-white");
}



function projectsCarousel() {
    $(".js-projects-carousel").slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
        row: 0,

    });
}


$(() => {

    console.log("HOME PAGE");

    init();
});