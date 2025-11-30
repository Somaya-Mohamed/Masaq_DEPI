using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using BusinessAccessLayes.Specification.Courses;
using BusinessLogic.Services.Interfaces;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Levels;
using DataAccessLayer.Repositories.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObjects.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessAccessLayes.Services.Classes
{
    public class CourseService(IUnitOfWork unitOfWork, IMapper mapper , IAttachmentService _attach , IConfiguration _config) : ICourseService
    {
        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var repo = unitOfWork.GetRepository<Course, int>();
            var spec = new CoursesAllSpecification();
            var courses = await repo.GetAllAsync(spec);
            return mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDetailsDto?> GetByIdAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Course, int>();
            var spec = new CourseWithDetailsSpecification(id);
            var course = await repo.GetAllAsync(spec);
            var result = course.FirstOrDefault();
            return result == null ? null : mapper.Map<CourseDetailsDto>(result);
        }

        public async Task<IEnumerable<CourseDto>> GetByLevelAsync(int levelId)
        {
            var repo = unitOfWork.GetRepository<Course, int>();
            var spec = new CoursesByLevelSpecification(levelId);
            var courses = await repo.GetAllAsync(spec);
            return mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        // CREATE
        public async Task<CourseDto> CreateAsync(CreatAndUpdateCourseDto dto)
        {
            var repo = unitOfWork.GetRepository<Course, int>();
            var entity = mapper.Map<Course>(dto);
            entity.ImageUrl = _attach.Upload(dto.ImageUrl, "courses");
            await repo.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<CourseDto>(entity);
        }

        // UPDATE
        public async Task<bool> UpdateAsync(int id, CreatAndUpdateCourseDto dto)
        {
            var repo = unitOfWork.GetRepository<Course, int>();
            var course = await repo.GetByIdAsync(id);
            if (course == null) return false;

            if (dto.Image != null && dto.Image.Length > 0)
            {
                if (!string.IsNullOrEmpty(course.ImageName))
                {
                    var oldPath = Path.Combine("wwwroot", course.ImageName.TrimStart('/'));
                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
                var filePath = Path.Combine("wwwroot", "images", "courses", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }

                course.ImageName = $"/images/courses/{fileName}";
            }

            mapper.Map(dto, course);
            if(dto.ImgUrl == (_config["Urls:BaseUrl"] + course.ImageUrl) && dto.ImageUrl == null)
            {
                course.ImageUrl = course.ImageUrl;
            }
            else
            {
                course.ImageUrl = _attach.Upload(dto.ImageUrl, "courses");
            }
                repo.Update(course);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Course, int>();
            var course = await repo.GetByIdAsync(id);
            if (course == null) return false;

            course.IsDeleted = true;
            repo.Update(course);
            await unitOfWork.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<Level>> getLevels()
        {
            var repo = unitOfWork.GetRepository<Level, int>();
            var levels = await repo.GetAllAsync();
            return levels;
        }

        public async Task<Level> addLevel(Level level)
        {

            var repo =  unitOfWork.GetRepository<Level, int>();
            await repo.AddAsync(level);
            await unitOfWork.SaveChangesAsync();
            return level;
        }
    }
}


















//namespace BusinessAccessLayes.Services.Classes
//{
//    public class CourseService(IUnitOfWork unitOfWork, IMapper mapper) : ICourseService
//    {
//        public async Task<IEnumerable<CourseDto>> GetAllAsync()
//        {
//            var repo = unitOfWork.GetRepository<Course, int>();
//            var spec = new CoursesAllSpecification(); 
//            var courses = await repo.GetAllAsync(spec);
//            return mapper.Map<IEnumerable<CourseDto>>(courses);
//        }

//        public async Task<CourseDetailsDto?> GetByIdAsync(int id)
//        {
//            var repo = unitOfWork.GetRepository<Course, int>();
//            var spec = new CourseWithDetailsSpecification(id);
//            var course = await repo.GetAllAsync(spec);
//            var result = course.FirstOrDefault();
//            return result == null ? null : mapper.Map<CourseDetailsDto>(result);
//        }

//        public async Task<IEnumerable<CourseDto>> GetByLevelAsync(int levelId)
//        {
//            var repo = unitOfWork.GetRepository<Course, int>();
//            var spec = new CoursesByLevelSpecification(levelId);
//            var courses = await repo.GetAllAsync(spec);
//            return mapper.Map<IEnumerable<CourseDto>>(courses);
//        }

//        public async Task<CourseDto> CreateAsync(CreatAndUpdateCourseDto dto)
//        {
//            var repo = unitOfWork.GetRepository<Course, int>();
//            var entity = mapper.Map<Course>(dto);

//            if (dto.Image != null && dto.Image.Length > 0)
//            {
//                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
//                var filePath = Path.Combine("wwwroot", "images", "courses", fileName);

//                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await dto.Image.CopyToAsync(stream);
//                }

//                entity.ImageName = $"/images/courses/{fileName}"; 
//            }

//            await repo.AddAsync(entity);
//            await unitOfWork.SaveChangesAsync();
//            return mapper.Map<CourseDto>(entity);
//        }



//        public async Task<bool> UpdateAsync(int id, CreatAndUpdateCourseDto dto)
//        {
//            var repo = unitOfWork.GetRepository<Course, int>();
//            var course = await repo.GetByIdAsync(id);
//            if (course == null) return false;

//            mapper.Map(dto, course);
//            repo.Update(course);
//            await unitOfWork.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var repo = unitOfWork.GetRepository<Course, int>();
//            var course = await repo.GetByIdAsync(id);
//            if (course == null) return false;

//            course.IsDeleted = true;
//            repo.Update(course);
//            await unitOfWork.SaveChangesAsync();
//            return true;
//        }
//    }
//}
