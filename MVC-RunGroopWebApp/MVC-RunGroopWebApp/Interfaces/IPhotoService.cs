using CloudinaryDotNet.Actions;

namespace MVC_RunGroopWebApp.Interfaces
{
    public interface IPhotoService
    {
      public  Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        public Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
