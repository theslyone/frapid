﻿function showForm() {
    window.scrudForm = $(".form.factory");
    window.scrudView = $(".view.factory");

    var defaultView = window.getQueryStringByName("View");

    if ((defaultView || "") === "FormView") {
        if (window.scrudView.length) {
            window.scrudView.hide();
        };

        window.scrudForm.show();
    } else {
        if (window.scrudView.length) {
            window.scrudForm.hide();
        } else {
            window.scrudForm.show();
        };
    };
};