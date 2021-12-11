using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWA.ViewModels.Interfaces
{
    public interface IUploadViewModel
    {
        Task<string> UploadAsync(IBrowserFile file);
    }
}
