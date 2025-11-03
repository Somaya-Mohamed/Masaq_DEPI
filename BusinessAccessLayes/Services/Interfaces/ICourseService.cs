using Shared.DataTransferObjects.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shared.DataTransferObjects.Courses;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();


        Task<CourseDetailsDto?> GetByIdAsync(int id);


        Task<IEnumerable<CourseDto>> GetByLevelAsync(int levelId);


        Task<CourseDto> CreateAsync(CreatAndUpdateCourseDto dto);


        Task<bool> UpdateAsync(int id, CreatAndUpdateCourseDto dto);


        Task<bool> DeleteAsync(int id);
    }
}