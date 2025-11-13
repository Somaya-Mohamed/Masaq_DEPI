using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using BusinessAccessLayes.Specification.Courses;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Repositories.UnitOfWork;
using Shared.DataTransferObjects.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessAccessLayes.Services.Classes
{
    public class CourseService(IUnitOfWork unitOfWork, IMapper mapper) : ICourseService
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

        public async Task<CourseDto> CreateAsync(CreatAndUpdateCourseDto dto)
        {
            var repo = unitOfWork.GetRepository<Course, int>();
            var entity = mapper.Map<Course>(dto);
            await repo.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<CourseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CreatAndUpdateCourseDto dto)
        {
            var repo = unitOfWork.GetRepository<Course, int>();
            var course = await repo.GetByIdAsync(id);
            if (course == null) return false;

            mapper.Map(dto, course);
            repo.Update(course);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

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
    }
}