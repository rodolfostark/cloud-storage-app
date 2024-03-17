using FileTypeChecker;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CloudStorageApplication.UseCases.Users.UploadProfileImage;

public class UploadProfileImageUseCase
{
    public void Execute(IFormFile image)
    {
        var fileStream = image.OpenReadStream();
        var isImage = FileTypeValidator.IsImage(fileStream);

        if (!isImage)
        {
            throw new Exception("The file is not an image.");           
        }


    }
}
