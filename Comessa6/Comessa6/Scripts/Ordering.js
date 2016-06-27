function ItemClicked(button) {
    //var orderItem = document.getElementById("orderItem");
    //document.getElementById("orderItem").value = button.getAttribute("itemName");
    //orderItem.setAttribute("itemID", button.id);
    //document.getElementById("orderQuantity").value = 1;
    //$("#orderPanel").collapse("show");

    var shownPanel = $("#orderPanel");
    if (shownPanel)
        shownPanel.remove();
    var itemID = button.getAttribute("id");
    var orderPanel = $("#panel" + itemID);
    orderPanel.html(itemID);
    $.ajax({
        url: "Orders/CreateOrder",
        type: 'GET',
        cache: false,
        async: false,        
        data: { itemID },
        success: function (result) { orderPanel.html(result); },
        error: function (error) { alert("Database failure: " + error.statusText); }
    });
    return false;            
}

function CancelOrder() {
    //document.getElementById("orderItem").value = "";
    //document.getElementById("orderQuantity").value = "";
    //document.getElementById("orderComments").value = "";
    //$("#orderPanel").collapse("hide");
    
    $("#orderPanel").remove();
    event.preventDefault ? event.preventDefault() : event.returnValue = false;
    return false;
}