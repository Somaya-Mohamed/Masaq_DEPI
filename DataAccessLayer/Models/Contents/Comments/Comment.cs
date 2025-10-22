using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Contents.Comments
{
    public class Comment:BaseOfAllContentEntities<int>
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string? Image {  get; set; }

        public int StudentIdFK { get; set; }
        [ForeignKey(nameof(StudentIdFK))]
        [InverseProperty(nameof(Student.comments))]
        public Student student { get; set; }

        public int LessonIdFK { get; set; }
        [ForeignKey(nameof(LessonIdFK))]
        [InverseProperty(nameof(Lesson.comments))]
        public Lesson lesson { get; set; }

    }
}
