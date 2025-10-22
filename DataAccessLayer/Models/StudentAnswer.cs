using DataAccessLayer.Models.Contents.Answers;
using DataAccessLayer.Models.Contents.Questions;
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

    [PrimaryKey(nameof(StudentExamId), nameof(QuestionId))]
    public class StudentAnswer  
    {
        public string? AnswerText { get; set; } // for Essay
        public string? FilePath { get; set; }  // optional for Essay (صورة/ملف)
    
        [Required]

        public int StudentExamId { get; set; }

        [ForeignKey(nameof(StudentExamId))]

        [InverseProperty(nameof(StudentExam.Answers))]
        public StudentExam StudentExam { get; set; }=null!;



        public int QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }=null!;


        public int? AnswerId { get; set; }   // بدل OptionId

        [ForeignKey(nameof(AnswerId))]
        [InverseProperty(nameof(QuestionOptions.StudentAnswers))]
        public QuestionOptions answer { get; set; }
    }
}
