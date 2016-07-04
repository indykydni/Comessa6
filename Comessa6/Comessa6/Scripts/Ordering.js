function CancelOrder() {
    //document.getElementById("orderItem").value = "";
    //document.getElementById("orderQuantity").value = "";
    //document.getElementById("orderComments").value = "";
    //$("#orderPanel").collapse("hide");
    
    $("#orderPanel").remove();
    event.preventDefault ? event.preventDefault() : event.returnValue = false;
    return false;
}