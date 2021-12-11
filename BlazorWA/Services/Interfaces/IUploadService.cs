using BlazorWA.Models;

namespace BlazorWA.Services.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadFileAsync(UploadedFile uploadedFile);
    }
}
