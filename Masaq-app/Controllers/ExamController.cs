using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Exam;
using System.Security.Claims;

namespace Masaq_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController(IServiceManager _iserviceManager) : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamDto>>> GetAllExams()
        {
            var exams = await _iserviceManager.ExamService.GetAllAsync();
            return Ok(exams);
        }


        [HttpGet("{examId:int}")]
        public async Task<ActionResult<ExamDetailsDto>> GetExamDetails(int examId)
        {
            var studentIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(studentIdClaim, out var studentId))
                return Unauthorized("Invalid student ID in token");
            var examDetails = await _iserviceManager.ExamService.GetByIdAsync(studentId,examId);
            if (examDetails == null)
            {
                return NotFound();
            }
            return Ok(examDetails);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteExam(int examId)
        {
            var result = await _iserviceManager.ExamService.DeleteAsync(examId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();

        }



        [HttpPut]

        public async Task<IActionResult> UpdateExam(int examId, [FromBody] CreatAndUpdateExamDto dto)
        {
            var result = await _iserviceManager.ExamService.UpdateAsync(examId, dto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }




        [HttpPost("Create")]
        public async Task<ActionResult<ExamDto>> CreateExam([FromBody] CreatAndUpdateExamDto dto)
        {
            var createdExam = await _iserviceManager.ExamService.CreateAsync(dto);
            return createdExam;
        }



        [HttpPost("SendStudentExam")]
        public async Task<ActionResult<StudentExamDto>> SendStudentExam([FromBody] StudentExamDto studentExamDto)
        {
            var studentIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(studentIdClaim, out var studentId))
                return Unauthorized("Invalid student ID in token");


            var result = await _iserviceManager.ExamService.SendStudentExam(studentId, studentExamDto);
            return Ok(result);
        }
    }
}
