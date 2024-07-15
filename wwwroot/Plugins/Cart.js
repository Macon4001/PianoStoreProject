var Cart = function () {
    var handleInitCart = function () {
        var url = '/Cart/CartListing';
        var element = "#section-cart";
        Base.renderPartial(url, element);
    };
    var handleCartSuccess = function (data) {
        Base.showToast(data);
        if (data.key) {
            setTimeout(function () { window.location.href = "/Cart" }, 1200);
        }
    };
    var handleDeleteCart = function (id) {
        var url = '/Cart/DeleteCartItem';
        var renderUrl = '/Cart/CartListing';
        var element = "#section-cart";
        $.confirm({
            title: 'Confirm Delete',
            content: 'Are you sure you want to Delete the item with its Content?',
            buttons: {
                confirm: function () {
                    $.ajax({
                        url: url,
                        type: 'post',
                        dataType: 'json',
                        data: { "id": id },
                        success: function (result) {
                            Base.showToast(result);
                            if (result.key) {
                                Base.renderPartial(renderUrl, element);
                            }
                        },
                        error: function () {
                            console.log("Error");
                        }
                    });
                },
                cancel: function () {
                    $.alert('Cancelled!');
                },
            }
        });
    };
    return {
        initCart: function () {
            handleInitCart();
        },
        initCartSuccess: function (data) {
            handleCartSuccess(data);
        },
        initDeleteCart: function (id) {
            handleDeleteCart(id);
        },
    };
}();


