$("document").ready(() => {
    $(".to-cart-button").on("click", ToCart);
})

function ToCart() {
    console.log(event.target.id);

    $.ajax("/catalog/addtocart", {
        type: "POST",
        data: JSON.stringify({ id: event.target.id }),
        contentType: "application/json"
    });
}