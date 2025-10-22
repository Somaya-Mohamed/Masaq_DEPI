using DataAccessLayer.Models.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configration_classes
{
    internal class TeacherConfigrationClass :HumanBaseEntityConfigrationClass<Teacher>, IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);
            
        }
    }
}
