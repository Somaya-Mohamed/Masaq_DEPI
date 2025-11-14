using DataAccessLayer.Models.Contents.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Specification.Courses
{
    public class CoursesByLevelSpecification : BaseSpecification<Course, int>
    {
        public CoursesByLevelSpecification(int levelId)
            : base(c => c.LevelFK == levelId && !c.IsDeleted)
        {
            AddInclude(c => c.Level);
            AddInclude(c => c.lessons);
        }
    }
}