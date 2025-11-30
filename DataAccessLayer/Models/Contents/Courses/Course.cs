using DataAccessLayer.Models.Contents.Exams;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Levels;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.Contents.Courses
{
    public class Course : BaseOfAllContentEntities<int>
    {
        //public int Id { get; set; }
        public string Title { get; set; }

        public string? Description { get; set; }

        public string ImageUrl { get; set; }



        #region  one to many relationship between course(one) and lesson(many)

        [InverseProperty(nameof(Lesson.course))]
        public ICollection<Lesson> lessons { get; set; } = new HashSet<Lesson>();

        #endregion

        #region One-to-Many Relationship between Level and course


        public Level Level { get; set; }
        public int LevelFK { get; set; }







        ///when we want to add more than one teacher in the future
        //[ForeignKey(nameof(TeacherId))]
        //[InverseProperty(nameof(Teacher.Courses))]
        //public Teacher Teacher { get; set; }

        #endregion


        #region  one to many relationship between course(one) and exams(many)
        public ICollection<Exam> exams { get; set; } = new HashSet<Exam>();
        #endregion
    }
}
