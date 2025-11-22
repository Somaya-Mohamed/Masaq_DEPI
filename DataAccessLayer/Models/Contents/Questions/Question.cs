using DataAccessLayer.Models.Contents.Answers;
using DataAccessLayer.Models.Contents.Exams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Contents.Questions
{
    public class Question:BaseOfAllContentEntities<int>
    {
        //public string Header { get; set; }
        //public string Body { get; set; }
        //public int Mark { get; set; }
        public string Title { get; set; }

        public string? PicUrl { get; set; }

        //public QuestionType Type { get; set; }
        //--------------------------------------------------------
        public int ExamId { get; set; }   // FK
        [ForeignKey(nameof(ExamId))]
        [InverseProperty(nameof(Exam.questions))]
        public Exam Exam { get; set; }
        //-----------------------------------------------------

        public ICollection<Answer>? Options { get; set; } = new HashSet<Answer>();

        public ICollection<StudentAnswer> studentAnswers { get; set; }=new HashSet<StudentAnswer>();


        //public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        //public ICollection<Answer> Options{ get; set; } = new HashSet<Answer>();
        //public ICollection<Answer> RightAnswers { get; set; } = new HashSet<Answer>();

    }
}
