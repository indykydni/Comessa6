function ItemClicked(button) {
    var orderItem = document.getElementById("orderItem");
    document.getElementById("orderItem").value = button.getAttribute("itemName");
    orderItem.setAttribute("itemID", button.id);
    document.getElementById("orderQuantity").value = 1;    
}


function ProviderClicked(providerID) {    
    var xhttp;
    xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            document.getElementById("provider" + providerID).innerHTML = "dupa"
        }
    }
    //var itemsPanel = document.getElementById("provider" + providerID);
}