using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Exam
{
    public class StudentExamDto
    {
        public int? StudentId { get; set; }
        public int ExamId { get; set; }
        public double? Grade { get; set; }

        public DateTime SendDate { get; set; }

        public ICollection<StudentAnswerDto>? Answers { get; set; } = new HashSet<StudentAnswerDto>();
    }
}
