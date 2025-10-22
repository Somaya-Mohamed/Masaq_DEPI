using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Repositories.UnitOfWork;
using Shared.DataTransferObjects.Announcements;
using Shared.DataTransferObjects.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Classes
{
    public class LessonService(IUnitOfWork unitOfWork, IMapper mapper) : ILessonService
    {
        public Task<AnnouncementDTO> GetAllAnnouncementAsync()
        {
            throw new NotImplementedException();
        }
        public Task<AnnouncementDTO?> GetAllComments(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LessonDTO>> GetAllLessonsAsync()
        {
            var repo= unitOfWork.GetRepository<Lesson,int>();
            var lessons =await repo.GetAllAsync();
            return mapper.Map<IEnumerable<Lesson>,IEnumerable<LessonDTO>>(lessons);
        }

        public async Task<LessonDetailsDTO?> GetLessonByIdAsync(int id)
        {
            var repo= unitOfWork.GetRepository<Lesson,int>();
            var lesson =await repo.GetByIdAsync(id);

            if (lesson is not null)
            return mapper.Map<LessonDetailsDTO>(lesson);
            
            return null;
        }
    }
}
