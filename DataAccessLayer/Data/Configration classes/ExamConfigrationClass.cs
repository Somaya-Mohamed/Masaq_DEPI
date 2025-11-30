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
            builder.HasOne(e => e.Lesson).WithMany(l => l.exams).HasForeignKey(e => e.LessonId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(e => e.Course).WithMany(l => l.exams).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(e => e.questions).WithOne(q => q.Exam).HasForeignKey(q => q.ExamId).OnDelete(DeleteBehavior.SetNull);

            #endregion


            base.Configure(builder);

        }    }
}
