using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [PrimaryKey(nameof(StudentId),nameof(LessonId))]
    public class StudentLesson
    {
       
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        public int LessonId { get; set; }
        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }


    }
}
