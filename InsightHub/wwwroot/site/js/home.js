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
        // Verifica se o clique foi fora do parent do .js-input-trigger
        if (!$(event.target).closest(".js-input-trigger").parent().hasClass("active")) {
            $(".js-input-trigger").parent().removeClass("active");
        }
    });
}


$(() => {
    init();
});