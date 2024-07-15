var Base = function () {
    var handleInitModal = function ($url, $element) {
        $.ajax({
            url: $url,
            type: 'GET',
            dataType: 'HTML',
            data: {},
            success: function (result) {
                $($element).empty();
                $($element).html(result);

                ///$('.datepicker-textbox').datepicker({
                ///    autoclose: true,
                ///    todayHighlight: true,
                ///    format: 'dd/mm/yyyy'
                ///});
                $('.select2').SumoSelect({
                    destroy: true,
                    placeholder: '-- Select --',
                    floatWidth: "100%",
                    search: true,
                    searchText: "Search...",
                    csvDispCount: 3,
                    floatWidth: 500,
                });
                //$('.summernote').summernote({
                //    destroy: true,
                //    tabsize: 2,
                //    height: 100
                //});
                $($element).modal({
                    backdrop: 'static',
                    keyboard: false
                })
                //$($element).modal("show");

            },
            error: function () {
                console.log("Error");
            }
        });
    };
    var handleRenderPartial = function ($url, $element) {
        $.ajax({
            url: $url,
            type: 'GET',
            dataType: 'HTML',
            data: {},
            success: function (result) {
                $($element).empty();
                $($element).html(result);
            },
            error: function () {
                console.log("Error");
            }
        });
    };
    var handleDeleteItem = function ($id, $url, $renderUrl, $element) {
        $.confirm({
            title: 'Confirm Delete',
            content: 'Are you sure you want to Delete the item with its Content?',
            buttons: {
                confirm: function () {
                    $.ajax({
                        url: $url,
                        type: 'post',
                        dataType: 'json',
                        data: { "id": $id },
                        success: function (result) {
                            if (result.key) {
                                swal("Deleted!", "Item Deleted successfully.", "success");
                                handleRenderPartial($renderUrl, $element);
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
                    $.alert('Cancelled!');
                },
            }
        });
        
    };
    var handleShowToast = function ($result) {
        if ($result.key == true) {
            $.toast({
                heading: 'Success',
                text: $result.value,
                position: 'bottom-left',
                loaderBg: '#7460ee',
                icon: 'success',
                hideAfter: 3000,
                stack: 6
            });
        }
        else {
            $.toast({
                heading: 'Error',
                text: $result.value,
                position: 'bottom-left',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500

            });
        }

    };
    var handleEditItem = function ($id, $url, $element) {
        $.ajax({
            url: $url,
            type: 'post',
            dataType: 'HTML',
            data: { "id": $id },
            success: function (result) {
                $($element).empty();
                $($element).html(result);
                $('.datepicker-textbox').datepicker({
                    autoclose: true,
                    todayHighlight: true,
                    format: 'dd/mm/yyyy'
                });
                $('.select2').SumoSelect({
                    destroy: true,
                    placeholder: '-- Select --',
                    floatWidth: "100%",
                    search: true,
                    searchText: "Search...",
                    csvDispCount: 3,
                    floatWidth: 500,
                });
                $('.summernote').summernote({
                    destroy: true,
                    tabsize: 2,
                    height: 100
                });
                $($element).modal({
                    backdrop: 'static',
                    keyboard: false
                })
            },
            error: function () {
                console.log("Error");
            }
        });
    };
    var handleAllowNumeric = function (evt) {
        $(event.srcElement).val($(event.srcElement).val().replace(/[^\d].+/, ""));
        if ((event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    };
    var handleAllowDecimal = function (event) {
        $(event.srcElement).val($(event.srcElement).val().replace(/[^0-9\.]/g, ''));
        if ((event.which != 46 || $(event.srcElement).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    };
    return {
        initModal: function (url, element) {
            handleInitModal(url, element);
        },
        renderPartial: function (url, element) {
            handleRenderPartial(url, element);
        },
        initDeleteItem: function ($id, $url, $renderUrl, $element) {
            handleDeleteItem($id, $url, $renderUrl, $element)
        },
        initEditItem: function ($id, $url, $element) {
            handleEditItem($id, $url, $element);
        },
        showToast: function ($result) {
            handleShowToast($result);
        },
        allowNumeric: function (event) {
            handleAllowNumeric(event);
        },
        allowDecimal: function (event) {
            handleAllowDecimal(event);
        },
    };
}();

