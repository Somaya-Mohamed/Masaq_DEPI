using BusinessAccessLayes.Specification;
using DataAccessLayer.Models.Contents.Lessons;
using System.Linq.Expressions;

namespace BusinessAccessLayes.Specification.Lessons
{
    public class LessonsByCourseSpecification : BaseSpecification<Lesson, int>
    {
        public LessonsByCourseSpecification(int courseId)
            : base(l => l.CourseIdFK == courseId) 
        {

            AddInclude(l => l.course);
            AddInclude(l => l.course.Level);
            AddInclude(l => l.announcements);
            AddInclude(l => l.comments);
            AddInclude(l => l.LessonVideos);
        }
    }
}