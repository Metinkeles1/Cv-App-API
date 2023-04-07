using Microsoft.AspNetCore.Http;

namespace CvAPI.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);
        Task<string> FileRenamAsync(string fileName);
        Task<bool> CopyFileAsync(string path, IFormFile file);
    }
}
