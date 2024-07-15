var Category = function () {
    var handleSuccess = function (data) {
        Base.showToast(data);
        if (data.key) {
            setTimeout(function () { window.location.href = "/Manage/Categories" }, 1200);
        }
    };
    var handleDeleteCategory = function (id) {
        var url = '/Manage/DeleteCategory';
        var renderUrl = '/Manage/CategoryListing';
        var element = "#section-categories";
        var result = Base.initDeleteItem(id, url, renderUrl, element);
    };
    var handleBindCategory = function () {
        var url = '/Manage/CategoryListing';
        var element = "#section-categories";
        Base.renderPartial(url, element);
    };
    return {
        initSuccess: function (data) {
            handleSuccess(data);
        },
        initDeleteCategory: function (id) {
            handleDeleteCategory(id);
        },
        initBindCategory: function () {
            handleBindCategory();
        }
    };
}();