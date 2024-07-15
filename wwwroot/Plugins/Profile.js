var $editor;
var Profile = function () {
    var handleUploadImage = function () {
        try {
           
            var imgSrc = $editor.cropit('imageSrc');
            var offset = $editor.cropit('offset');
            var zoom = $editor.cropit('zoom');
            var previewSize = $editor.cropit('previewSize');
            var exportZoom = $editor.cropit('exportZoom');

            var img = new Image();
            img.src = imgSrc;

            // Draw image in original size on a canvas
            var originalCanvas = document.createElement('canvas');
            originalCanvas.width = previewSize.width / zoom;
            originalCanvas.height = previewSize.height / zoom;
            var ctx = originalCanvas.getContext('2d');
            ctx.drawImage(img, offset.x / zoom, offset.y / zoom);

            // Use pica to resize image and paint on destination canvas
            var zoomedCanvas = document.createElement('canvas');
            zoomedCanvas.width = previewSize.width * exportZoom;
            zoomedCanvas.height = previewSize.height * exportZoom;
            // Resizing completed
            // Read resized image data
            var images = zoomedCanvas.toDataURL();
            var canvasImageData = $editor.cropit('export');
            var previewImage = $editor.cropit('previewSize');
            var images = canvasImageData;
            $.ajax({
                url: "/Account/UpdateProfilePicture",
                type: 'post',
                dataType: 'json',
                data: { "Imagedata": images },
                success: function (result) {
                    if (result.key) {
                        window.location.reload();
                    }
                },
                error: function () {
                    console.log("Error");
                }
            });
        }
        catch (err) {
            $.toast({
                heading: 'Warning',
                text: "Please select a valid Image.",
                position: 'bottom-left',
                loaderBg: '#ff6849',
                icon: 'warning',
                hideAfter: 3500

            });
        }

    };
    var ProfileReload = function (data) {
        Base.showToast(data);
        if (data.key) {
            window.location.reload();
        }
       
   };
    var handleUpdateImage = function () {
        var url = '/Account/UploadImageView';
        var element = "#CropImageModal";
        Base.initModal(url, element);
    };
    return {
        initUploadImage: function () {
            handleUploadImage();
        },
        initUpdateImage: function () {
            handleUpdateImage();
        },
        initPageReload: function (data) {

            ProfileReload(data);
        },
     
    }

}();
