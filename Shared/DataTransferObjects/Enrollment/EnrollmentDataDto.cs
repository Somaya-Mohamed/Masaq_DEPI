using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Enrollment
{
    public class EnrollmentDataDto
    {

        //public int studentId { get; set; }

            public Guid codeId { get; set; }

            public int? courseId { get; set; }

            public int? lessonId { get; set; }
        
    }
}
