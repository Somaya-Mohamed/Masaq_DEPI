using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services.Classes
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtentions = new List<string>() { ".png", ".Jpg", ".Jpeg" , ".jpeg" , ".jpg" , ".PNG" };
        const int maxSize = 2 * 1024 * 1024;
        public string? Upload(IFormFile file, string folderName)
        {
            var extention = Path.GetExtension(file.FileName);
            if (!allowedExtentions.Contains(extention))
            {
                return null;
            }
            if (file.Length > maxSize || file.Length == 0)
            {
                return null;
            }
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload",folderName, "images");
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);
            using FileStream fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);
            return $"upload/{folderName}/images/{fileName}";
        }
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

    }
}
