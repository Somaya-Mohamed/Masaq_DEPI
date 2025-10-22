using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Announcements
{
    public class Announcement:BaseOfAllContentEntities<int>
    { 
        public string Header { get; set; }= null!;
        public string Body { get; set; }= null!;
        public bool IsPinned { get; set; }
       
        //public int TeacherIdFK { get; set; }
        //public Teacher teacher { get; set; }


        public int LessonIdFK { get; set; }
        public Lesson lesson { get; set; }





    }
}
