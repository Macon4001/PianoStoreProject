var Users = function () {
    var handleAddUsers = function () {
        var url = '/Manage/AddUsers';
        var element = "#addUsersModal";
        Base.initModal(url, element);
    };
    var handlebindUsers = function () {
        var url = '/Manage/UserListing';
        var element = "#UsersList";
        Base.renderPartial(url, element);
    };
    var handleUserSuccess = function (data) {
        Base.showToast(data);
        if (data.key) {
            $("#UserForm").trigger("reset");
        }
    };
    var handleDeleteUser = function (id) {
        var url = '/Manage/DeleteUser';
        var renderUrl = '/Manage/UserListing';
        var element = "#UsersList";
        var result = Base.initDeleteItem(id, url, renderUrl, element);
    };

    var handleEditUser = function (id) {
        var url = '/Manage/EditUser';
        var element = "#addUsersModal";
        Base.initEditItem(id, url, element);
    };

    var handleBlockUser = function (userId, status) {
        var msg = "";
        if (status == "True" || status == true) {
            msg = 'Are you sure you want to unblock the user?'
        }
        else {
            msg = 'Are you sure you want to block the user?'
        }
        $.confirm({
            title: 'Confirm',
            content: msg,
            buttons: {
                confirm: function () {
                    $.ajax({
                        url: "/Manage/BlockUser",
                        type: 'post',
                        dataType: 'json',
                        data: { "UserId": userId },
                        success: function (result) {
                            if (result.key) {
                                $.toast({
                                    heading: 'Success',
                                    text: result.value,
                                    position: 'bottom-left',
                                    loaderBg: '#7460ee',
                                    icon: 'success',
                                    hideAfter: 3000,
                                    stack: 6
                                });
                                var url = '/Manage/UserListing';
                                var element = "#UsersList";
                                Base.renderPartial(url, element);

                            }
                            else {
                                $.toast({
                                    heading: 'Error',
                                    text: result.value,
                                    position: 'bottom-left',
                                    loaderBg: '#ff6849',
                                    icon: 'error',
                                    hideAfter: 3500

                                });
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
        initAddUsers: function () {
            handleAddUsers();
        },
        initUserSuccess: function (data) {
            handleUserSuccess(data);
        },
        bindUsers: function () {
            handlebindUsers();
        },
        initDeleteUser: function (id) {
            handleDeleteUser(id);
        },
        initEditUser: function (id) {
            handleEditUser(id);
        },
        initBlockUser: function (id, status) {
            handleBlockUser(id, status);
        }

    };
}();

