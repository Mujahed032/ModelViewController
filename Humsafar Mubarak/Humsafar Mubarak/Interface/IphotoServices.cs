using CloudinaryDotNet.Actions;

namespace Humsafar_Mubarak.Interface
{
    public interface IphotoServices
    {
        public Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        public Task<DeletionResult> DeletePhotoAsync(string Id);
    }
}
