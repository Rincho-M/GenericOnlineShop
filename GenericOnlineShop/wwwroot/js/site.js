$("document").ready(() => {
    $("#categoryButton").on("click", OpenCategories);
    $("#popupBackgroundShade").on("click", CloseCategories);
})

function OpenCategories() {
    $("#categoryPopupBlock").css("display", "block");
}

function CloseCategories() {
    $("#categoryPopupBlock").css("display", "none");
}