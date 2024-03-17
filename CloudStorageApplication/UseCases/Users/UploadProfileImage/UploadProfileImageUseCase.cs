using FileTypeChecker;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CloudStorageApplication.UseCases.Users.UploadProfileImage;

public class UploadProfileImageUseCase
{
    public void Execute(IFormFile image)
    {
        var fileStream = image.OpenReadStream();
        var isRecognizableType = FileTypeValidator.IsImage(fileStream);
    }
}
