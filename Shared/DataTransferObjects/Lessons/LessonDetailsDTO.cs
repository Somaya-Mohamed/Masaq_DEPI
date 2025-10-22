using Shared.DataTransferObjects.Announcements;
using Shared.DataTransferObjects.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Lessons
{
    public class LessonDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; }= null!;
        public string? ImageName { get; set; }
        public string? DocName { get; set; }

        public string CourseName { get; set; } = null!;
        public string LevelName { get; set; } = null!; // 👈 New field


        public IEnumerable<AnnouncementDTO> Announcements { get; set; } = [];
        public IEnumerable<CommentDTO> Comments { get; set; } = [];
        public IEnumerable<string> Videos { get; set; } = [];



    }
}
