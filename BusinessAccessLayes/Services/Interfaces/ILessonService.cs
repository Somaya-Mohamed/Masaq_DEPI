using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Announcements;
using Shared.DataTransferObjects.Comments;
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

        Task AddLessonAsync(UpdateLessonDTO updateLessonDTO);
       
        //////////
        
        Task UpdateLessonAsync(UpdateLessonDTO updateLessonDTO);

        //////////
        
        public Task DeleteLesson(int id) ;

        //////////

        Task<LessonDetailsDTO?> GetLessonByIdAsync(int id);
        
        //////////

        Task<IEnumerable<LessonDTO>> GetAllLessonsAsync([FromQuery] LessonQueryParams queryParams);
         





    }
}
