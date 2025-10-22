using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Announcements;
using Shared.DataTransferObjects.Lessons;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetAllLessonsAsync()
        {
            var lessons = await _serviceManager.LessontService.GetAllLessonsAsync();
            return Ok(lessons);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LessonDetailsDTO>> GetLessonByIdAsync(int id)
        {
            var lesson = await _serviceManager.LessontService.GetLessonByIdAsync(id);
            if (lesson is null)
                return NotFound();
            return Ok(lesson);
        }
        public async Task<ActionResult<IEnumerable< AnnouncementDTO>>> GetAllAnnouncementsAsync()
        {
            var announcements = await _serviceManager.LessontService.GetAllAnnouncementAsync();
            return Ok(announcements);
        }
    }
}
