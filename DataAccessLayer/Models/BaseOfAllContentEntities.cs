using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BaseOfAllContentEntities<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }//PK
        public int CreatedBy { get; set; }// UserId
        public DateTime? CreatedOn { get; set; }// Date
        public int LastModifiedBy { get; set; }// UserId
        public DateTime LastModifiedOn { get; set; }// Date
        public bool IsDeleted { get; set; }// Soft Delete
    }
}
