function getDefaultScrudView(){
    var defaultView = "kanban";
    
    if(window.defaultScrudView){
        defaultView = window.defaultScrudView;
    };

    var queryStringView = window.getQueryStringByName("View");

    if(queryStringView){
        return queryStringView;
    };

    return defaultView;
};


function showForm() {
    window.scrudForm = $(".form.factory");
    window.scrudView = $(".view.factory");

    var defaultView = window.getDefaultScrudView();

    if ((defaultView || "") === "form-view") {
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