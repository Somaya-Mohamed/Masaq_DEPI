using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public abstract class HumanBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [AllowNull]
        public int? Age { get; set; }
        public string FullName { get; set; }
        [AllowNull]
        public Gender? Gender { get; set; }
        [EmailAddress]
        [AllowNull]
        public string? email { get; set; }
        //public string Password { get; set; }

        [AllowNull]
        public string? Address { get; set; }
        [AllowNull]
        public string? City { get; set; } 
        public DateTime LastActive { get; set; }

        public bool IsDeleted { get; set; } = false; //Soft Delete





    }
}
