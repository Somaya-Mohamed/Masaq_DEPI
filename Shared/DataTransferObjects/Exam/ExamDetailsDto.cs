using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Exam
{
    public class ExamDetailsDto
    {
        public int Duration { get; set; }
        public string? Title { get; set; }
        public ICollection<QuestionDto> questions { get; set; } = new HashSet<QuestionDto>();
    }
}
