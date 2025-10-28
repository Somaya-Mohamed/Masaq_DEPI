using DataAccessLayer.Models.Students;
using DataAccessLayer.Models.Teachers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.IdentityModels
{
    public class ApplicationUser:IdentityUser
    {
        public string Role { get; set; }

        public Student? student {  get; set; }
        public Teacher? Teacher { get; set; }
    }
}
