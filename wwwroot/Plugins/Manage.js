var Manage = function () {
    var handleBindNewOrders = function () {
        var url = '/Orders/NewOrdersListing';
        var element = "#section-orders";
        Base.renderPartial(url, element);
    };
    var handleConfirmOrder = function (id) {
        var url = '/Orders/ConfirmShippedOrder';
        var renderUrl = '/Orders/NewOrdersListing';
        var element = "#section-orders";
        $.confirm({
            title: 'Confirm Deliver',
            content: 'Are you sure you want to complete this order and change the status to delivered?',
            buttons: {
                confirm: function () {
                    $.ajax({
                        url: url,
                        type: 'post',
                        dataType: 'json',
                        data: { "id": id, "statusId": 2 },
                        success: function (result) {
                            if (result.key) {
                                swal("Confirmed", "Order marked as confirmed successfully.", "success");
                                Base.renderPartial(renderUrl, element);
                            }
                            else {
                                swal("Error", result.value, "error");
                            }
                        },
                        error: function () {
                            console.log("Error");
                        }
                    });
                },
                cancel: function () {
                    $.ajax({
                        url: url,
                        type: 'post',
                        dataType: 'json',
                        data: { "id": id, "statusId": 5 },
                        success: function (result) {
                            if (result.key) {
                                swal("Cancelled", "Order marked as cancelled", "success");
                                Base.renderPartial(renderUrl, element);
                            }
                            else {
                                swal("Error", result.value, "error");
                            }
                        },
                        error: function () {
                            console.log("Error");
                        }
                    });
                },
                close: function () {
                    $.alert({
                        title: 'Closed!',
                        content: 'Closed!',
                    });
                }
            }
        });
    };
    return {
        initNewOrders: function () {
            handleBindNewOrders();
        },
        initConfirmOrder: function (id) {
            handleConfirmOrder(id);
        },
    };
}();