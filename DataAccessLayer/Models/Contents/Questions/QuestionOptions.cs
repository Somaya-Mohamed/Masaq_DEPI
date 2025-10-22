using DataAccessLayer.Models.Contents.Answers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Contents.Questions
{
    
    public class QuestionOptions
    {
        public int Id { get; set; }
        public string OptionText { get; set; } = null!;
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty(nameof(Question.Options))]
        public Question Question { get; set; }

        [InverseProperty(nameof(StudentAnswer.answer))]
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new HashSet<StudentAnswer>();
    }
}
