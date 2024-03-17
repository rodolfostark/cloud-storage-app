using CloudStorageApplication.UseCases.Users.UploadProfileImage;
using Microsoft.AspNetCore.Mvc;

namespace CloudStorageAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage(IFormFile image)
    {
        var useCase = new UploadProfileImageUseCase();
        
        useCase.Execute(image);

        return Created();
    }
}
