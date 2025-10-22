using DataAccessLayer.Models.Contents.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Contents.Answers
{
    public class Answer
    {

        public int Id { get; set; }
        public string? Text { get; set; }
        public string? ImageName { get; set; }
        //public Question Question { get; set; }
    }
}
