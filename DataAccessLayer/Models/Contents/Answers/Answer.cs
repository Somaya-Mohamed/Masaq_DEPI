using DataAccessLayer.Models.Contents.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Contents.Answers
{
    public class Answer
    {

        public int Id { get; set; }
        public string? Text { get; set; }

        public bool IsCorrect { get; set; }

        public ICollection<StudentAnswer> Answers { get; set; } = new HashSet<StudentAnswer>();
        //public string? ImageName { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        [InverseProperty(nameof(Question.Options))]
        public Question Question { get; set; }
    }
}
