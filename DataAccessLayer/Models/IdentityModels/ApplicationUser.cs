using DataAccessLayer.Models.Students;
using DataAccessLayer.Models.Teachers;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        //public string Role { get; set; }
        public string FullName { get; set; }

        public Student? student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
