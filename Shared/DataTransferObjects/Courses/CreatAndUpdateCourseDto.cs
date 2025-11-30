using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Courses
{
    public class CreatAndUpdateCourseDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public string? ImgUrl { get; set; }
        public int LevelFK { get; set; }
    }
}
