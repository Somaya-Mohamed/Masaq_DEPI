using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using BusinessAccessLayes.Specification.Lessons;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Lessons;

namespace BusinessAccessLayes.Services.Classes
{
    public class LessonService(IUnitOfWork unitOfWork, IMapper mapper) : ILessonService
    {


        public async Task DeleteLesson(int id)
        {
            var repo = unitOfWork.GetRepository<Lesson, int>();

            var lesson = await repo.GetByIdAsync(id);
            if (lesson is not null)
            {
                repo.Delete(lesson);
                await unitOfWork.SaveChangesAsync();

            }

        }
        public async Task<IEnumerable<LessonDTO>> GetAllLessonsAsync([FromQuery] LessonQueryParams queryParams)
        {
            var repo = unitOfWork.GetRepository<Lesson, int>();
            var specification = new LessonWithAllDetailsSpecification(queryParams);
            var lessons = await repo.GetAllAsync(specification);
            var lessonDTO = mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDTO>>(lessons);
            return lessonDTO;
        }
        public async Task AddLessonAsync(UpdateLessonDTO updateLessonDTO)
        {
            var repo = unitOfWork.GetRepository<Lesson, int>();
            var lesson = mapper.Map<UpdateLessonDTO, Lesson>(updateLessonDTO);
            await repo.AddAsync(lesson);
            await unitOfWork.SaveChangesAsync();

        }



        public async Task UpdateLessonAsync(UpdateLessonDTO updateLessonDTO)
        {
            var repo = unitOfWork.GetRepository<Lesson, int>();
            var lesson = mapper.Map<UpdateLessonDTO, Lesson>(updateLessonDTO);
            repo.Update(lesson);
            await unitOfWork.SaveChangesAsync();
        }



        public async Task<LessonDetailsDTO?> GetLessonByIdAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Lesson, int>();
            var lesson = await repo.GetByIdAsync(id);

            if (lesson is not null)
                return mapper.Map<LessonDetailsDTO>(lesson);

            return null;
        }


    }
}
