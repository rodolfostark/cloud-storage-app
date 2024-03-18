using CloudStorageDomain.Entities;
using CloudStorageDomain.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;

namespace CloudStorageInfrastructure.Storage;

public class GoogleDriveStorageService : IStorageService
{
    public string Upload(IFormFile image, User user)
    {
        var credential = new UserCredential(null, user.Email, new TokenResponse
        {

        });

        var service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
        {
            ApplicationName = "GoogleDriveCloudStorage",
            // TODO HttpClientInitializer = 
        });
        var driveFile = new Google.Apis.Drive.v3.Data.File
        {
            Name = image.Name,
            MimeType = image.ContentType,
        };
        var command = service.Files.Create(driveFile, image.OpenReadStream(), image.ContentType);
        var response = command.Upload();

        if (response.Status is not Google.Apis.Upload.UploadStatus.Completed)
        {
            throw response.Exception;
        }

        return command.ResponseBody.Id;
    }
}
