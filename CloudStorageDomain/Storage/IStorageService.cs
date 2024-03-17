using CloudStorageDomain.Entities;
using Microsoft.AspNetCore.Http;

namespace CloudStorageDomain.Storage;

public interface IStorageService
{
    string Upload(IFormFile image, User user);
}
