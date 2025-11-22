using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Enrollment
{
    public class CreateCodeDto
    {
            public int? courseId { get; set; }
            public int? lessonId { get; set; }
            public int durationInDays { get; set; }

        public int NumberOfCodes { get; set; }
    }
}
