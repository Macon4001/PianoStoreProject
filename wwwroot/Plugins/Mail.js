var Mail = function () {
    var handleSuccess = function (data) {
        Base.showToast(data);
        if (data.key) {

        }
    };
    return {
        initSuccess: function (data) {
            handleSuccess(data);
        }
    };
}();