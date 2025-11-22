using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Enrollment;

namespace Masaq_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController(IServiceManager _serviceManager) : ControllerBase
    {


        [HttpGet("check")]
        public async Task<bool> CheckEnrollment(int studentId, int TargetId)
        {
            var res = await _serviceManager.EnrollmentService.CheckEnrollment(studentId, TargetId);
            return  res;
        }


        [HttpPost("enroll/{studentId:int}")]
        public async Task<IActionResult> EnrollStudent(int studentId, [FromBody] EnrollmentDataDto EnrollmentData)
        {
            var enrollment = await _serviceManager.EnrollmentService.EnrollStudentAsync(studentId, EnrollmentData);
            if (enrollment == null)
            {
                return BadRequest("Enrollment failed. Please check the provided data.");
            }
            return Ok(enrollment);
        }


        [HttpPost("GenerateCodes")]

        public async Task<IActionResult> GenerateCodes([FromBody] CreateCodeDto CreateCodeDto)
        {
            var codes = await _serviceManager.EnrollmentService.GenerateCodeAsync(CreateCodeDto);
            return Ok(codes);
        }


    }
}
