$("document").ready(() => {
    $("#toCartHandler").on("click", ToCart);
})

function ToCart() {
    let button = event.target.closest("button");
    if (!button || button.name != "toCart")
        return;

    $.ajax("/catalog/addtocart", {
        type: "POST",
        data: JSON.stringify({ id: button.value }),
        contentType: "application/json"
    });
}