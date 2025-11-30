using DataAccessLayer.Models.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configration_classes
{
    internal class StudentConfigrationClass : HumanBaseEntityConfigrationClass<Student>, IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(15)");
            builder.Property(x => x.ParentPhoneNumber).HasColumnType("nvarchar(15)");
            builder.HasMany(s=>s.studentExams).WithOne(sx=>sx.Student).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.SetNull);
            base.Configure(builder);
        }
    }
}
