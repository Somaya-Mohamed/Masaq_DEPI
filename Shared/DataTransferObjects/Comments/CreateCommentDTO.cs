using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Comments
{
    public class CreateCommentDTO
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string? Image { get; set; }
        public int StudentIdFK { get; set; }
        public int LessonIdFK { get; set; }
    }
}
