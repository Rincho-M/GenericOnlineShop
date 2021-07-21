$("document").ready(() => {
    Validation();
});

function FormSubmitOverride() {
    let formData = {
        email: $("#email").val(),
        password: $("#password").val()
    }

    $.ajax("/account/signin", {
        type: "POST",
        data: JSON.stringify(formData),
        contentType: "application/json",
        success: ResponseHandler
    });

    // This prevents default submit.
    return false;
}

// Change some elements according to new logged state.
function ResponseHandler(data) {
    if (data.id != undefined) {
        $("#signInPopupBlock").css("display", "none");
        $("#accountButton").off("click");
        $("#accountLink").attr("href", "/account");
        $("#accountLinkText").text(data.name);
    } else {
        $("#" + data.errorField + "Errors").text(data.errorText);
    }
}

function Validation() {
    $("#signInForm").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            password: {
                required: true,
                rangelength: [8, 32]
            }
        },
        messages: {
            email: {
                required: "Email is required."
            },
            password: {
                required: "Password is required.",
                rangelength: "Password must be between 8 and 32 characters long."
            }
        },
        submitHandler: FormSubmitOverride
    });
}