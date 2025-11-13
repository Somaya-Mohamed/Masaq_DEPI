using Shared.DataTransferObjects.Announcements;
using Shared.DataTransferObjects.Comments;
using Shared.DataTransferObjects.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Courses
{
    public class CourseDetailsDto : CourseDto
    {
        public IEnumerable<LessonDTO> Lessons { get; set; } = [];
    }
}
