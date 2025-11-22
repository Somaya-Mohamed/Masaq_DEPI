using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.code
{
    public class Code
    {
        public Guid Id { get; set; } 
        public int DurationInDays { get; set; }

        public int? CourseId { get; set; }

        public int? LessonId { get; set; }

        public Boolean IsUsed { get; set; } = false;

    }
}
