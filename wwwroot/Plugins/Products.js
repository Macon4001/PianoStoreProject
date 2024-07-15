var $editor;
var Products = function () {
    var handleSuccess = function (data) {
        Base.showToast(data);
        if (data.key) {
            debugger
            $("#Id").val(data.id);
            handleBindImages(data.id);
        }
    };
    var handleBindImages = function (productId) {
        var url = "/Product/Photos?productId=" + productId;
        Base.renderPartial(url, "#section-images");
    };
    var handleAddImage = function () {
        var _productID = $("#Id").val();
        var url = '/Product/UploadProductImages?ProductId=' + _productID;
        var element = "#UploadImageModal";
        Base.initModal(url, element);
    };
    var handleUploadImageSuccess = function (data) {
        var _productID = $("#Id").val();
        Base.showToast(data);
        if (data.key) {
            debugger
            $("#UploadImageModal").modal("hide");
            handleBindImages(_productID);
        }
    };
    var handleBindPackageListing = function (_productID) {
        var url = "/Product/PackagesListing?ProductId=" + _productID;
        Base.renderPartial(url, "#sectionPackageListing");
    };
    var handleDeletePackage = function (id) {
        var _productID = $("#Id").val();
        var url = '/Product/DeletePackage';
        var renderUrl = "/Product/PackagesListing?ProductId=" + _productID;;
        var element = "#sectionPackageListing";
        var result = Base.initDeleteItem(id, url, renderUrl, element);
    };
    var handleBindProducts = function () {
        var url = '/Product/ProductListing';
        var element = "#section-products";
        Base.renderPartial(url, element);
    };
    var handleOnFinish = function () {
        window.location.href = "/Product";
    };
    var handleDeleteProduct = function (id) {
        var url = '/Product/DeleteProduct';
        var renderUrl = '/Product/ProductListing';
        var element = "#section-products";
        var result = Base.initDeleteItem(id, url, renderUrl, element);
    };
    var handleDeleteProductImage = function (id) {
        var _productID = $("#Id").val();
        var url = '/Product/DeleteProductImage';
        var renderUrl = "/Product/Photos?productId=" + _productID;
        var element = "#section-images";
        var result = Base.initDeleteItem(id, url, renderUrl, element);
        handleBindImages(_productID);
    };
    return {
        initSuccess: function (data) {
            handleSuccess(data);
        },
        initUploadImageSuccess: function (data) {
            handleUploadImageSuccess(data);
        },
        initAddImage: function () {
            handleAddImage();
        },
        initBindImages: function (_productID) {
            handleBindImages(_productID);
        },
        initBindPackageListing: function (_productID) {
            handleBindPackageListing(_productID);
        },
        initDeletePackage: function (id) {
            handleDeletePackage(id);
        },
        initBindProducts: function () {
            handleBindProducts();
        },
        onFinish: function () {
            handleOnFinish();
        },
        initDeleteProduct: function (id) {
            handleDeleteProduct(id);
        },
        initDeleteProductImage: function (id) {
            handleDeleteProductImage(id);
        },
    };
}();