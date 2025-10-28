using DataAccessLayer.Models.Contents.Comments;
using DataAccessLayer.Models.IdentityModels;
using DataAccessLayer.Models.Levels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Students
{
    public class Student:HumanBaseEntity
    {



        public string? Government { get; set; }
        [Phone]
        public String PhoneNumber { get; set; } = null!;

        [Phone]
        public String ParentPhoneNumber { get; set; } = null!;
        //public int CreationBy { get; set; }
        //public bool favorite { get; set; }  
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastModified { get; set; }


        [ForeignKey(nameof(level))]
        public int levelFK { get; set; }
        [InverseProperty(nameof(Level.Students))]
        public Level level { get; set; }


        public ICollection<Comment> comments { get; set; } = new HashSet<Comment>();

        public ICollection<StudentExam> studentExams { get; set; } = new HashSet<StudentExam>();
        public ICollection<StudentLesson> studentLessons { get; set; } = new HashSet<StudentLesson>();


        //make a relation between student and application user 
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
