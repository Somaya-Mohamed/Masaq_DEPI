using Shared.DataTransferObjects.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface IExamService
    {
        public Task<IEnumerable<ExamDto>> GetAllAsync();

        public Task<ExamDetailsDto?> GetByIdAsync(int studentId , int id);

        public Task<ExamDto> CreateAsync(CreatAndUpdateExamDto dto);

        public Task<bool> UpdateAsync(int id, CreatAndUpdateExamDto dto);

        public Task<bool> DeleteAsync(int id);

        public Task<StudentExamDto> SendStudentExam(int StuId, StudentExamDto StudentExamDto);
    }
}
