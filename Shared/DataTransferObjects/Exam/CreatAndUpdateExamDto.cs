using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Exam
{
    public class CreatAndUpdateExamDto
    {
        public int? CourseId { get; set; }
        public int? LessonId { get; set; }
        public int Duration { get; set; }
        public string? Title { get; set; }
        //public string? Description{ get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<QuestionDto> questions { get; set; } = new HashSet<QuestionDto>();
    }
}
