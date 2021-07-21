$("document").ready(() => {
    $("input.input-number").prev().on("click", () => { $("input.input-number")[0].stepUp(); });
    $("input.input-number").next().on("click", () => { $("input.input-number")[0].stepDown(); });
});