using DataAccessLayer.Models.Contents.Lessons;
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

        Task<Lesson> AddLessonAsync(UpdateLessonDTO updateLessonDTO);
       
        //////////
        
        Task<UpdateLessonDTO> UpdateLessonAsync(int id , UpdateLessonDTO updateLessonDTO);

        //////////
        
        public Task DeleteLesson(int id) ;

        //////////

        Task<LessonDetailsDTO?> GetLessonByIdAsync(int id);
        
        //////////

        Task<IEnumerable<LessonDTO>> GetAllLessonsAsync([FromQuery] LessonQueryParams queryParams);

        //////////
        Task<IEnumerable<LessonDTO>> GetLessonsByCourseAsync(int courseId);




    }
}

