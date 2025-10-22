using DataAccessLayer.Models.Contents.Exams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configration_classes
{
    internal class ExamConfigrationClass :BaseOfAllEntityConfigrationClass<Exam,int>, IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {

            #region  one to many relationship between ُexam(one) and lesson(many)
            builder.HasOne(e => e.Lesson).WithMany(l => l.exams).HasForeignKey(e => e.LessonId);

            #endregion


            builder.Property(e=>e.Description).HasColumnType("nvarchar(200)").IsRequired(false);
            base.Configure(builder);

        }    }
}
