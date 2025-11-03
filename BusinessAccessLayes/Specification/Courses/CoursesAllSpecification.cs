using DataAccessLayer.Models.Contents.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Specification.Courses
{
    public class CoursesAllSpecification : BaseSpecification<Course, int>
    {
        public CoursesAllSpecification()
            : base(c => !c.IsDeleted)
        {
            AddInclude(c => c.Level);
            AddInclude(c => c.lessons);
        }
    }
}