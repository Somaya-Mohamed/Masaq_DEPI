using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Students;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.Levels
{
    public class Level : BaseOfAllContentEntities<int>
    {

        public int LevelNumber { get; set; }
        public int NumberOfStudents { get; set; }
        public string AcademicYear { get; set; }

        #region One to many relationship between level and course


        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();


        #endregion

        #region One-to-Many relationship between students and Course
        [InverseProperty(nameof(Student.level))]
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        #endregion
    }
}
