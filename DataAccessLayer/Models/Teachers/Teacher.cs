using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.IdentityModels;
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


        //[InverseProperty(nameof(Course.Teacher))]
        //public ICollection<Course> Courses { get; set; } = new HashSet<Course>();



        //make a relation between teacher and application user

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


    }
}
