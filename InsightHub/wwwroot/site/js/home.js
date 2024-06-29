function init() {
    changeFooterColor();
    openInput();
}

function changeFooterColor() {
    $(".footer").addClass("is-white");
}

function openInput() {
    $(".js-input-trigger").on("click", function (event) {
        var $parent = $(this).parent();
        if ($parent.hasClass("active")) {
            $parent.removeClass("active");
        } else {
            $parent.addClass("active");
        }
        event.stopPropagation(); // Impede que o clique no elemento seja propagado para o documento
    });

    // Adiciona o manipulador de eventos ao documento
    $(document).on("click", function (event) {
        // Verifica se o clique foi fora do parent do .js-input-trigger e fora do .input-options
        if (!$(event.target).closest(".js-input-trigger").parent().hasClass("active") &&
            $(event.target).closest(".js-input-trigger").length === 0 &&
            $(event.target).closest(".select-options").length === 0) {
            $(".js-input-trigger").parent().removeClass("active");
        }
    });
}


$(() => {
    init();
});