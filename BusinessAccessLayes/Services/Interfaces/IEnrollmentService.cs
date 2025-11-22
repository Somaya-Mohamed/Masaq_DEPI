using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.code;
using Shared.DataTransferObjects.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface IEnrollmentService
    {
        public Task<IEnumerable<Code>> GenerateCodeAsync(CreateCodeDto CreateCodeDto);

        public Task<Code?> GetCodeByIdAsync(Guid codeId);


        public Task<Enrollment?> EnrollStudentAsync(int studentId , EnrollmentDataDto EnrollmentData);

        public Task<bool> CheckEnrollment(int studentId, int TargetId);




    }

   
}
