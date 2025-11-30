using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using BusinessAccessLayes.Specification.Lessons;
using BusinessLogic.Services.Interfaces;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using Shared.DataTransferObjects.Lessons;

namespace BusinessAccessLayes.Services.Classes
{
    public class LessonService(IUnitOfWork unitOfWork, IMapper mapper , 
        IAttachmentService _attach , MasaqDbContext _dbcontext) : ILessonService
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
        public async Task<Lesson> AddLessonAsync(UpdateLessonDTO updateLessonDTO)
        {
            var repo = unitOfWork.GetRepository<Lesson, int>();
            var lesson = mapper.Map<UpdateLessonDTO, Lesson>(updateLessonDTO);



            if (updateLessonDTO.Videos != null && updateLessonDTO.Videos.Any())
            {
                lesson.LessonVideos = updateLessonDTO.Videos
                    .Select(url => new LessonVideo
                    {
                        VideoURL = url,
                        Lesson = lesson
                    })
                    .ToList();
            }





            lesson.ImageName = _attach.Upload(updateLessonDTO.ImageName, "lects");
            await repo.AddAsync(lesson);
            await unitOfWork.SaveChangesAsync();
            return lesson;
        }



        public async Task<UpdateLessonDTO> UpdateLessonAsync(int id , UpdateLessonDTO updateLessonDTO)
        {
            //var repo = unitOfWork.GetRepository<Lesson, int>();
            var lesson =await _dbcontext.Lessons.Include(l=>l.LessonVideos).FirstAsync(l=>l.Id == id);
            var img = lesson.ImageName;
            if (lesson == null) throw new Exception($"the lesson with this id : {id} is not found ");
            mapper.Map(updateLessonDTO , lesson);
            //lesson.Id = id;

            if(updateLessonDTO.ImageName is null)
            {
                lesson.ImageName = img;
            }


            else
            {
                lesson.ImageName = _attach.Upload(updateLessonDTO.ImageName, "lects");
            }


            if (updateLessonDTO.Videos != null && updateLessonDTO.Videos.Any())
            {
                lesson.LessonVideos = updateLessonDTO.Videos
                    .Select(url => new LessonVideo
                    {
                        VideoURL = url,
                        Lesson = lesson
                    })
                    .ToList();
            }


            _dbcontext.Lessons.Update(lesson);
            _dbcontext.SaveChanges();
            return updateLessonDTO;
        }



        public async Task<LessonDetailsDTO?> GetLessonByIdAsync(int id)
        {
            //var repo = unitOfWork.GetRepository<Lesson, int>();
            //var lesson = await repo.GetByIdAsync(id);
            var lesson = await _dbcontext.Lessons.Include(l=>l.LessonVideos).Include(l=>l.course)
                                                .FirstOrDefaultAsync(l=>l.Id==id);




            LessonDetailsDTO x;
            if (lesson is not null)
            {
                x = mapper.Map<LessonDetailsDTO>(lesson);
                x.Videos = lesson.LessonVideos!.Select(lv => lv.VideoURL).ToList();
                x.CourseIdFK = lesson.CourseIdFK;
                return x;
            }


            return null;
        }



        public async Task<IEnumerable<LessonDTO>> GetLessonsByCourseAsync(int courseId)
        {
            var repo = unitOfWork.GetRepository<Lesson, int>();


            var specification = new LessonsByCourseSpecification(courseId);
            var lessons = await repo.GetAllAsync(specification);

            return mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }

    }
}
