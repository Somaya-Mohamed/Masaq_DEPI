using BusinessAccessLayes.Services.Interfaces;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.code;
using Shared.DataTransferObjects.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Classes
{
    public class EnrollmentService(MasaqDbContext _dbcontext) : IEnrollmentService
    {
        public async Task<bool> CheckEnrollment(int studentId, int TargetId , string targetType = "course")
        {
            
            if (targetType!= "course")
            {

            var lesson = _dbcontext.Lessons.Where(l=>l.Id == TargetId).FirstOrDefault();
                var IsEnrollment1 = _dbcontext.Enrollments.FirstOrDefault(e => e.StudentId == studentId

           && (e.CourseId == TargetId || e.LessonId == TargetId || (lesson != null && lesson.CourseIdFK == e.CourseId)));

                if (IsEnrollment1 == null)
                {
                    return false;
                }
                return true;
            }


            var IsEnrollment = _dbcontext.Enrollments.FirstOrDefault(e => e.StudentId == studentId 

            && (e.CourseId == TargetId || e.LessonId == TargetId));

            if (IsEnrollment == null) {
                return false;
            }
            return true;
        }

        public async Task<Enrollment?> EnrollStudentAsync(int studentId, EnrollmentDataDto EnrollmentData)
        {

            var studentExists = _dbcontext.Students.Any(s => s.Id == studentId);
            if (!studentExists)
            {
                return null;
            }


            var code = _dbcontext.Codes.FirstOrDefault(c => c.Id == EnrollmentData.codeId && !c.IsUsed);
            if (code == null)
            {
                return null;
            }


            if(code.CourseId != EnrollmentData.courseId)
            {
                return null;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = EnrollmentData.courseId,
                LessonId = EnrollmentData.lessonId,
                CodeId = EnrollmentData.codeId,
                EndDate = DateTime.Now.AddDays(code.DurationInDays) 
            };


            _dbcontext.Enrollments.Add(enrollment);
            code.IsUsed = true;
            await  _dbcontext.SaveChangesAsync();
            return enrollment;
        }

        public async Task<IEnumerable<Code>> GenerateCodeAsync(CreateCodeDto CreateCodeDto)
        {
            var codes = new List<Code>();

            for(int i = 0; i< CreateCodeDto.NumberOfCodes; i++)
            {
                var code = new Code
                {
                    Id = Guid.NewGuid(),
                    DurationInDays = CreateCodeDto.durationInDays,
                    IsUsed = false,
                    CourseId = CreateCodeDto.courseId,
                    LessonId = CreateCodeDto.lessonId
                };
                codes.Add(code);
            }

            _dbcontext.Codes.AddRange(codes);
            _dbcontext.SaveChanges();
            return codes;
        }

        public async Task<Code?> GetCodeByIdAsync(Guid codeId)
        {
            var code = _dbcontext.Codes.FirstOrDefault(c => c.Id == codeId);

            return code;
        }

       
    }
}
