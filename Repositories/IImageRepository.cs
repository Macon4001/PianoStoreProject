using Microsoft.AspNetCore.Http;

namespace PianoStoreProject.Repositories
{
    public interface IImageRepository
    {
        string UploadImage(IFormFile file);
    }
}
