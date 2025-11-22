using DataAccessLayer.Models.Contents.Answers;
using DataAccessLayer.Models.Contents.Exams;
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
    public class StudentExam : BaseOfAllContentEntities<int>
    {
        [Key]
        public int Id { get; set; } // surrogate PK
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        public DateTime SendDate { get; set; }


        public int ExamId { get; set; }

        [ForeignKey(nameof(ExamId))]
        public Exam Exam { get; set; }

        public double? Grade { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public bool? IsSubmitted { get; set; }
        public bool? IsPassed { get; set; }
        public ICollection<StudentAnswer> Answers { get; set; } = new HashSet<StudentAnswer>();

    }
}
