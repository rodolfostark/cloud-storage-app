using CloudStorageDomain.Entities;
using CloudStorageDomain.Storage;
using FileTypeChecker;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CloudStorageApplication.UseCases.Users.UploadProfileImage;

public class UploadProfileImageUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfileImageUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public void Execute(IFormFile image)
    {
        var fileStream = image.OpenReadStream();
        var isImage = FileTypeValidator.IsImage(fileStream);

        if (!isImage)
        {
            throw new Exception("The file is not an image.");           
        }
        var user = GetUserFromDatabase();
        _storageService.Upload(image, user);
    }
    private User GetUserFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Jonatas",
            Email = "jonatas.santos.700@ufrn.edu.br"
        };
    }
}
