using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAttachmentService
    {
        public string Upload(IFormFile file, string folderName);
        public bool Delete(string filePath);
    }
}
