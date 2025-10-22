using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Levels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configration_classes
{
    internal class LevelConfigurationClass
        : BaseOfAllEntityConfigrationClass<Level, int>,  // assuming Level has an int key
          IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.Property(l => l.AcademicYear).HasColumnType("nvarchar(100)");
            base.Configure(builder);

            builder.HasMany(p=>p.Courses).WithOne(p => p.Level).HasForeignKey(p=>p.LevelFK).IsRequired();
        }
    }
}
