function ItemClicked(button) {
    var orderItem = document.getElementById("orderItem");
    document.getElementById("orderItem").value = button.getAttribute("itemName");
    orderItem.setAttribute("itemID", button.id);
    document.getElementById("orderQuantity").value = 1;
    $("#orderPanel").collapse("show");
}

function CancelOrder() {
    document.getElementById("orderPanel").style.visibility = "visible";
    document.getElementById("orderItem").value = "";
    document.getElementById("orderQuantity").value = "";
    document.getElementById("orderComments").value = "";
    document.getElementById("orderPanel").style.visibility = "collapse";
    $("#orderPanel").collapse("hide");

}