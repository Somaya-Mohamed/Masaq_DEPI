using BusinessAccessLayes.ServiceManagers;
using DataAccessLayer.Models.Contents.Lessons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Announcements;
using Shared.DataTransferObjects.Comments;
using Shared.DataTransferObjects.Lessons;
using System.Threading.Tasks;

namespace Masaq_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public LessonsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetAllLessonsAsync([FromQuery] LessonQueryParams queryParams)
        {
            var lessons = await _serviceManager.LessonService.GetAllLessonsAsync(queryParams);
            return Ok(lessons);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LessonDetailsDTO>> GetLessonByIdAsync(int id)
        {
            var lesson = await _serviceManager.LessonService.GetLessonByIdAsync(id);
            if (lesson is null)
                return NotFound();
            return Ok(lesson);
        }

        [HttpGet("Comment/{id:int}")]
        public async Task<ActionResult<CommentDTO>> GetCommentByIdAsync(int id)
        {
            var comment = await _serviceManager.CommentService.GetCommentByIdAsync(id);
            if (comment is null)
                return NotFound();
            return Ok(comment);
        }

        [AllowAnonymous]
        [HttpGet("announcements")]
        public async Task<ActionResult<IEnumerable<AnnouncementDTO>>> GetAllAnnouncementsAsync()
        {
            var announcements = await _serviceManager.AnnouncementService.GetAllAnnouncementAsync();
            return Ok(announcements);
        }

        [AllowAnonymous]
        [HttpGet("Comments")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllCommentssAsync()
        {
            var comments = await _serviceManager.CommentService.GetAllCommentAsync();
            return Ok(comments);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("announcements/{id:int}")]
        public async Task DeleteAnnouncement(int id)
        {
            
          await  _serviceManager.AnnouncementService.DeleteAnnouncement(id);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task DeleteLesson(int id)
        {
           await _serviceManager.LessonService.DeleteLesson(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Comment/{id:int}")]
        public async Task DeleteComment(int id)
        {
           await _serviceManager.CommentService.DeleteComment(id);

        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("Lesson")]
        public async Task<Lesson> CreateLesson([FromForm] UpdateLessonDTO LessonDTO)
        { 
             var x = await _serviceManager.LessonService.AddLessonAsync(LessonDTO);
            return x;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("announcement")]
       public async Task CreateAnnouncement([FromBody] AnnouncementDTO announcementDTO)
        {
            var lesson = await _serviceManager.LessonService.GetLessonByIdAsync(announcementDTO.LessonId);
            if (lesson is not null)
                await _serviceManager.AnnouncementService.AddAnnouncementAsync(announcementDTO);
            else
            {
                BadRequest($"No lesson exists with ID {announcementDTO.LessonId}.");
            }
        }

        [AllowAnonymous]
        [HttpPost("Comment")]
       public async Task CreateComment([FromBody] CreateCommentDTO commentDTO)
        {
           await _serviceManager.CommentService.AddCommentAsync(commentDTO);
        }


        [AllowAnonymous]
        [HttpGet("course/{courseId:int}")]
        public async Task<IActionResult> GetByCourse(int courseId)
        {
            var lessons = await _serviceManager.LessonService.GetLessonsByCourseAsync(courseId);
            return Ok(lessons);
        }

    }
}
