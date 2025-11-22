using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Lessons
{
    public class UpdateLessonDTO
    {
        //public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IFormFile? ImageName { get; set; }
        public string? DocName { get; set; }

        public int CourseIdFK { get; set; }
        //public string? CourseName { get; set; } = null!;
        //public string LevelName { get; set; } = null!; // 👈 New field
        public IEnumerable<string> Videos { get; set; } = new List<string>();
    }
}
