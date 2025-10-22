using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Models.Contents.Comments;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Exams;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.Contents.Lessons
{
    public class Lesson : BaseOfAllContentEntities<int>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageName { get; set; }
        //public List<string> VideoName { get; set; }
        public string? DocName { get; set; }
        

        [InverseProperty(nameof(Announcement.lesson))]
        public ICollection<Announcement> announcements { get; set; } = new HashSet<Announcement>();


        #region one to many relationship between course(one) and lesson(many)

        public int CourseIdFK { get; set; }
        [ForeignKey(nameof(CourseIdFK))]
        [InverseProperty(nameof(Course.lessons))]
        public Course course { get; set; }

        #endregion

        #region one to many relationship between exam(one) and lesson(many)
        public ICollection<Exam> exams { get; set; } = new HashSet<Exam>();
        #endregion
        [InverseProperty(nameof(Comment.lesson))]
        public ICollection<Comment> comments { get; set; } = new HashSet<Comment>();

        public ICollection<StudentLesson> studentLessons { get; set; } = new HashSet<StudentLesson>();


    }

}
