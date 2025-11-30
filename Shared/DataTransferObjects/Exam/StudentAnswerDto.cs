using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Exam
{
    public class StudentAnswerDto
    {
        //public int StudentExamId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }

    }
}
