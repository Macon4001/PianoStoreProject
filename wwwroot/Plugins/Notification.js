var Notification = function () {
    var handleSuccess = function (data) {
        Base.showToast(data);
        if (data.key) {
            setTimeout(function () { window.location.href = "/Manage/Notifications" }, 1200);
        }
    };
    var handleDeleteNotification = function (id) {
        var url = '/Manage/DeleteNotification';
        var renderUrl = '/Manage/NotificationListing';
        var element = "#section-notification";
        var result = Base.initDeleteItem(id, url, renderUrl, element);
    };

    var handleBindNotification = function () {
        var url = '/Manage/NotificationListing';
        var element = "#section-notification";
        Base.renderPartial(url, element);
    };
    return {
        initSuccess: function (data) {
            handleSuccess(data);
        },
        initDeleteNotification: function (id) {
            handleDeleteNotification(id);
        },
        initBindNotification: function () {
            handleBindNotification();
        }
    };
}();