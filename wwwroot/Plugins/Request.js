var Request = function () {
    var handleRequestSuccess = function (data) {
        if (data.key) {
            $("#RequestForm").trigger("reset");
            $("#txtMessage").removeClass("hide");
        }
    };
    return {
        initSuccess: function (data) {
            handleRequestSuccess(data);
        }
    };
}();