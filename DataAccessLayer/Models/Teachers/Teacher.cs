using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Teachers
{
    public class Teacher:HumanBaseEntity
    {
        //public ICollection<Announcement> announcements { get; set; } = new HashSet<Announcement>();

        [InverseProperty(nameof(Notification.teacher))]
        public ICollection< Notification> notifications { get; set; } = new HashSet<Notification>();
        //[InverseProperty(nameof(Course.Teacher))]
        //public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
