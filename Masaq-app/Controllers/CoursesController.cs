using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Courses;

namespace Masaq_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CoursesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/courses
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllAsync()
        {
            var courses = await _serviceManager.CourseService.GetAllAsync();
            return Ok(courses);
        }

        // GET: api/courses/5
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<CourseDetailsDto>> GetByIdAsync(int id)
        {
            var course = await _serviceManager.CourseService.GetByIdAsync(id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        // GET: api/courses/level/1
        [HttpGet("level/{levelId:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetByLevelAsync(int levelId)
        {
            var courses = await _serviceManager.CourseService.GetByLevelAsync(levelId);
            return Ok(courses);
        }

        // POST: api/courses
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CourseDto>> CreateAsync([FromBody] CreatAndUpdateCourseDto dto)
        {
            var created = await _serviceManager.CourseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = created.Id }, created);
        }

        // PUT: api/courses/5
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreatAndUpdateCourseDto dto)
        {
            var updated = await _serviceManager.CourseService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        // DELETE: api/courses/5
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _serviceManager.CourseService.DeleteAsync(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Cannot delete course: {ex.Message}");
            }
        }
    }
}