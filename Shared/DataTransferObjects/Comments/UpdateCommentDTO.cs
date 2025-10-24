using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Comments
{
    public  class UpdateCommentDTO
    {
        public int id { get; set; }
        public string Body { get; set; }
        public string? Image { get; set; }
    }
}
