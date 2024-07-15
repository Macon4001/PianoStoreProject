using PianoStoreProject.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
namespace PianoStoreProject.Providers
{
    public class ImageProvider : IImageRepository
    {
        private IWebHostEnvironment _hostingEnvironment { get; set; }
        public ImageProvider(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string UploadImage(IFormFile ImageFile)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string _imageUrl = "";
            if (ImageFile != null)
            {
                var PathWithFolderName = System.IO.Path.Combine(webRootPath, "Uploads");
                if (!Directory.Exists(PathWithFolderName))
                {
                    DirectoryInfo di = Directory.CreateDirectory(PathWithFolderName);
                }

                string extension = Path.GetExtension(ImageFile.FileName);
                string fname = "";
                var myUniqueFileName = Guid.NewGuid().ToString();
                fname = myUniqueFileName + extension;
                _imageUrl = "/Uploads/" + fname;
                var _filePath = Path.Combine(PathWithFolderName, fname);
                using (var fileStream = new FileStream(_filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(fileStream);
                }
            }
            else
            {
                _imageUrl = "/images/NoImage.png";
            }
            return _imageUrl;
        }
    }
}
