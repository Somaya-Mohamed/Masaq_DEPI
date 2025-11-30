using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Courses
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string LevelName { get; set; } = null!;   
        public int LevelFK { get; set; }
        public int LessonsCount { get; set; }
    }
}