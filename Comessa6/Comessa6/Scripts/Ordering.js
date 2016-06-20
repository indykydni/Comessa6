function ItemClicked(button) {
    var orderItem = document.getElementById("orderItem");
    document.getElementById("orderItem").value = button.getAttribute("itemName");
    orderItem.setAttribute("itemID", button.id);
    document.getElementById("orderQuantity").value = 1;    
}