using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Contents.Questions;
using DataAccessLayer.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Contents.Exams
{
    public class Exam:BaseOfAllContentEntities<int>
    {

        public int Duration { get; set; }
        public string? Title { get; set; }
        //public string? Description{ get; set; }
        public DateTime StartTime { get; set; }
        //public DateTime EndTime { get; set; }
        //public bool IsCompleted { get; set; }
        //public bool? Status { get; set; }
        public bool IsAvaliable { get; set; } = true;

        #region one to many relationship between ُexam(one) and lesson(many)

        public int? LessonId { get; set; }   // Nullable FK
        [ForeignKey(nameof(LessonId))]
        [InverseProperty(nameof(Lesson.exams))]
        public Lesson? Lesson { get; set; }

        #endregion

        #region one to many relationship between course(one) and exams(many)
        public int? CourseId { get; set; }   // Nullable FK
        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Course.exams))]
        public Course? Course { get; set; }
        #endregion


        public ICollection<StudentExam>? StudentExams { get; set; } = new HashSet<StudentExam>();

        public ICollection<Question> questions { get; set; }=new HashSet<Question>();


    }
}
