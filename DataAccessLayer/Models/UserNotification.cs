using DataAccessLayer.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [PrimaryKey(nameof(HumanBaseEntityId), nameof(NotificationId))]
    public class UserNotification
    {
        public int HumanBaseEntityId { get; set; }
        [ForeignKey(nameof(HumanBaseEntityId))]
       
        public HumanBaseEntity User { get; set; }=null!;

        public int NotificationId { get; set; }
        [ForeignKey(nameof(NotificationId))]
        //[InverseProperty(nameof(Notification.UserNotifications))]
        public Notification notification { get; set; }=null!;


        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
