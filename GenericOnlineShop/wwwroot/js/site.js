$("document").ready(() => {
    $("#catalogButton").on("click", OpenCategories);
    $("#catalogPopupBgShade").on("click", CloseCategories);

    if ($("#accountButton > a").attr("href") == "") {
        $("#accountButton > a").removeAttr("href");
        $("#accountButton").on("click", OpenSignInWindow);
        $("#signInPopupBgShade").on("click", CloseSignInWindow);
    }
})

function OpenCategories() {
    $("#catalogPopupBlock").css("display", "block");
}

function CloseCategories() {
    $("#catalogPopupBlock").css("display", "none");
}

function OpenSignInWindow() {
    $("#signInPopupBlock").css("display", "block");
}

function CloseSignInWindow() {
    $("#signInPopupBlock").css("display", "none");
}