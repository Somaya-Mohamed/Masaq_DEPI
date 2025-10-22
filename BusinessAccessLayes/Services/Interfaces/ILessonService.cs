using Shared.DataTransferObjects.Announcements;
using Shared.DataTransferObjects.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonDTO>> GetAllLessonsAsync();
        Task<LessonDetailsDTO?> GetLessonByIdAsync(int id);

        Task<AnnouncementDTO> GetAllAnnouncementAsync();
       




    }
}
