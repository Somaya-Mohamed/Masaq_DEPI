using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public abstract class HumanBaseEntity
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FName { get; set; } = null!;
        public string LName { get; set; }= null!;
        public Gender Gender { get; set; }
        [EmailAddress]
        public string email { get; set; } = null!;
        //public string Password { get; set; }
        public string Address { get; set; } = null!;
        public string? City { get; set; } = null!;
        public DateTime LastActive { get; set; }
       public bool IsDeleted { get; set; } //Soft Delete


        [InverseProperty(nameof(UserNotification.User))]

        public ICollection<UserNotification> UserNotifications { get; set; } = new HashSet<UserNotification>();


    }
}
