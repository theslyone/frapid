function showView(target, dontRefresh) {
    if (!target) {
        target = $(".active[data-target]").attr("data-target") || "grid";
    };

    if (target === "FormView") {
        window.scrudView.hide();
        window.scrudForm.show();
    } else {
        //var url = updateQueryString("View", target);
        //window.history.replaceState({ path: url }, '', url);
        window.scrudForm.hide();
        $("div[data-target]").hide();
        $("[data-target]").removeClass("active green");
        $('[data-target="' + target + '"]').show().addClass("active green");
        window.scrudView.show();

        if (!dontRefresh) {
            loadPageCount(loadGrid);
        };
    };
};