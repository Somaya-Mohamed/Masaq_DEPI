using DataAccessLayer.Models.Contents.Answers;
using DataAccessLayer.Models.Students;
using DataAccessLayer.Models.Teachers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Notifications
{
    public class Notification: BaseOfAllContentEntities<int>

    {

        public string Body { get; set; } = null!;
        public string Header { get; set; }= null!;
       
        //[InverseProperty(nameof(UserNotification.notification))]
        //public ICollection<UserNotification> UserNotifications { get; set; } = new HashSet<UserNotification>();

        public int TeacherFK { get; set; }
        [ForeignKey(nameof(TeacherFK))]
        [InverseProperty(nameof(Teacher.notifications))]
        public Teacher teacher { get; set; } = null!;

        public int StudentFK { get; set; }
        [ForeignKey(nameof(StudentFK))]
        [InverseProperty(nameof(Student.notifications))]
        public Student student { get; set; } = null!;
        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;






    }
}
