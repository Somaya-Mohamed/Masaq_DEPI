using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Exam
{
    public class ExamDto
    {

        public int Id { get; set; }
        public int Duration { get; set; }
        public string? Title { get; set; }
        
        public DateTime StartTime { get; set; }
       
        public bool IsAvaliable { get; set; } = true;
    }
}
