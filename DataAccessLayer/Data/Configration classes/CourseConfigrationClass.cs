using DataAccessLayer.Models.Contents.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configration_classes
{
    internal class CourseConfigrationClass :BaseOfAllEntityConfigrationClass<Course,int>, IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.HasMany(c => c.lessons).WithOne(c => c.course).HasForeignKey(c => c.CourseIdFK);
            base.Configure(builder);
        }
    }
}
