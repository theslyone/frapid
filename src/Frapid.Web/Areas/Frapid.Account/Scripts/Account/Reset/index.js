$("#ConfirmEmailInputEmail").hide();

$(document).ready(function () {
    window.validator.initialize($(".reset.password.segment"));
});

$("#EmailInputEmail").blur(function () {
    function request(email) {
        const url = "/account/reset/validate-email?email=" + email;
        return window.getAjaxRequest(url, "POST");
    };

    var el = $(this);
    const email = el.val();

    if (!email) {
        return;
    };

    $("#ResetButton").addClass("disabled");
    const ajax = request(email);

    ajax.success(function (response) {
        if (response) {
            $(".big.error").html(window.translate("NoAccountWithThisEmail"));
            window.makeDirty(el);
        } else {
            $(".big.error").html("");
            window.removeDirty(el);
            $("#ResetButton").removeClass("disabled");
        };
    });
});


$("#ResetButton").click(function () {
    function request(model) {
        const url = "/account/reset";
        const data = JSON.stringify(model);

        return window.getAjaxRequest(url, "POST", data);
    };

    function validate() {
        $(".big.error").html("");
        const formEl = $(".reset.password.segment");
        var isValid = window.validator.validate(formEl);

        const hp = $("#ConfirmEmailInputEmail").val();

        if (hp) {
            isValid = false;
        };

        return isValid;
    };

    $(".big.error").html("");

    const isValid = validate();
    if (!isValid) {
        return;
    };


    const formEl = $(".reset.password.segment");
    formEl.addClass("loading");
    const model = window.serializeForm(formEl);
    const token = $("#TokenInputHidden").val();
    model.Token = token;

    const ajax = request(model);
    ajax.success(function (response) {
        if (response) {
            window.location = "/account/reset/email-sent";
        };
    });
});