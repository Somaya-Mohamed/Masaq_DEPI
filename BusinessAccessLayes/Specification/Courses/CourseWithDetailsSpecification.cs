using DataAccessLayer.Models.Contents.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Specification.Courses
{
    public class CourseWithDetailsSpecification : BaseSpecification<Course, int>
    {
        public CourseWithDetailsSpecification(int id)
            : base(c => c.Id == id && !c.IsDeleted)
        {
            AddInclude(c => c.Level);
            AddInclude(c => c.lessons);
        }
    }
}