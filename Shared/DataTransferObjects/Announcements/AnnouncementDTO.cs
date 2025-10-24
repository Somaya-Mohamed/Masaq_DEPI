using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Announcements
{
    public class AnnouncementDTO
    {
        public int Id { get; set; }
        public string Header { get; set; } = null!;
        public string Body { get; set; } = null!;
        public bool IsPinned { get; set; }
        public int LessonId { get; set; }
    }
}
