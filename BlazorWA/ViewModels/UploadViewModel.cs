using BlazorWA.Models;

using BlazorWA.Services.Interfaces;
using BlazorWA.ViewModels.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWA.ViewModels
{
    public class UploadViewModel : IUploadViewModel
    {
        private readonly IUploadService uploadFileService;

        public UploadViewModel(IUploadService uploadFileService)
        {
            this.uploadFileService = uploadFileService;
        }

        public async Task<string> UploadAsync(IBrowserFile file)
        {
            if (file != null)
            {
                var resizedFile = await file.RequestImageFileAsync(file.Name, 500, 300);

                using (var stream = resizedFile.OpenReadStream())
                {
                    MemoryStream ms = new MemoryStream();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    UploadedFile uploadedFile = new UploadedFile();
                    uploadedFile.FileName = file.Name;
                    uploadedFile.FileContent = ms.ToArray();
                    ms.Close();

                    return await uploadFileService.UploadFileAsync(uploadedFile);

                }
            }
            else
                return "";

        }
    }
}
