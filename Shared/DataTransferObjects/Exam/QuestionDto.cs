using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Exam
{
    public class QuestionDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }

        public string? PicUrl { get; set; }

        //public QuestionType Type { get; set; }
        //--------------------------------------------------------
        public int? ExamId { get; set; }
        public ICollection<AnswerDto>? Options { get; set; } = new HashSet<AnswerDto>();
    }
}
