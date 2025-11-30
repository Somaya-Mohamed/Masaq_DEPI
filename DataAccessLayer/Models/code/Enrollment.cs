using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.code
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? LessonId { get; set; }

        public Guid CodeId { get; set; }

        public DateTime EndDate { get; set; }
        
    }
}
