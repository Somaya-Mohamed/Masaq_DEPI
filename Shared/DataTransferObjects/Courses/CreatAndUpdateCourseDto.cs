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
        public int LevelFK { get; set; }
    }
}
