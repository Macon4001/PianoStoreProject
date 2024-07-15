var pageIndex = 0;
var totalPages = -1;
var Store = function () {
    var handleInitSuccess = function (data) {
        $("#section-products").html(data);
    };

    var handleInitProducts = function () {
        debugger
        var filter = localStorage.getItem("BackFilter");

        if (filter == true || filter == "true") {
            var ProductFilter = JSON.parse(localStorage.getItem("filters"));
        }
        else {
            var ProductFilter = {
                'CategoryId': $("#txtSubCategoryId").val(),
                'pageNumber': pageIndex
            };
            localStorage.setItem("filters", JSON.stringify(ProductFilter));
        }

        $.ajax({
            url: "/Home/ProductListing",
            type: 'post',
            dataType: 'HTML',
            data: { 'data': ProductFilter },
            success: function (result) {
                pageIndex = pageIndex + 1;
                $("#section-products").append(result);
            },
            error: function () {
                console.log("Error");
            }
        });

    };

    var handleUpdateTotal = function (total) {
        totalPages = parseInt(total);
        if (pageIndex < totalPages) {
            $("#btnLoadMore").removeClass("hide");
        }
        else {
            $("#btnLoadMore").addClass("hide");
        }
    };
    var handleLoadMore = function () {
        if (pageIndex < totalPages) {
            Store.initProducts();
            $("#btnLoadMore").addClass("hide");
        }
    };
    return {
        initSuccess: function (data) {
            handleInitSuccess(data);
        },
        initProducts: function () {
            handleInitProducts();
        },
        updateTotal: function (total) {
            handleUpdateTotal(total);
        },
        initLoadMore: function () {
            handleLoadMore();
        },
    };
}();

$(function () {
    Store.initProducts();
});
