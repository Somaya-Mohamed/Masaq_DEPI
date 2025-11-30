using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Enrollment;
using System.Security.Claims;

namespace Masaq_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController(IServiceManager _serviceManager) : ControllerBase
    {


        [HttpGet("check")]
        public async Task<bool> CheckEnrollment(int TargetId , string TargetType)
                                    {

            var studentIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(studentIdClaim, out var stuId))
                return false;

            var res = await _serviceManager.EnrollmentService.CheckEnrollment(stuId, TargetId , TargetType);
            return  res;
        }


        [HttpPost("enroll")]
        public async Task<IActionResult> EnrollStudent([FromBody] EnrollmentDataDto EnrollmentData)
        {

            var studentIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(studentIdClaim, out var stuId))
                return Unauthorized("Invalid student ID in token");

            var enrollment = await _serviceManager.EnrollmentService.EnrollStudentAsync(stuId, EnrollmentData);
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
