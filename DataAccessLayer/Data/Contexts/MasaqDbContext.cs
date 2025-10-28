using DataAccessLayer.Models;
using DataAccessLayer.Models.Admin;
using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Models.Contents.Answers;
using DataAccessLayer.Models.Contents.Comments;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Exams;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Contents.Questions;
using DataAccessLayer.Models.IdentityModels;
using DataAccessLayer.Models.Levels;
using DataAccessLayer.Models.Students;
using DataAccessLayer.Models.Teachers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer.Data.Contexts
{
    public class MasaqDbContext : IdentityDbContext<ApplicationUser>
    {
        public MasaqDbContext(DbContextOptions<MasaqDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HumanBaseEntity>().UseTpcMappingStrategy();
            modelBuilder.Entity<HumanBaseEntity>()
               .Property(h => h.Id)
               .ValueGeneratedOnAdd();

            // Configure derived types
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");


            //make the student and teacher relations with the application user
            modelBuilder.Entity<Student>().HasOne(s => s.User)
                .WithOne(u => u.student)
                .HasForeignKey<Student>(s => s.UserId);



            modelBuilder.Entity<Teacher>().HasOne(t => t.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(t => t.UserId);



            /////////////////////////////////////////////////////////////////////
            ///
            modelBuilder.Entity<Comment>()
    .HasOne(c => c.student)
    .WithMany(s => s.comments)
    .HasForeignKey(c => c.StudentIdFK)
    .OnDelete(DeleteBehavior.Restrict);



            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<StudentExam>()
    .HasOne(se => se.Student)
    .WithMany(s => s.studentExams)
    .HasForeignKey(se => se.StudentId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentLesson>()
                .HasOne(sl => sl.Student)
                .WithMany(s => s.studentLessons)
                .HasForeignKey(sl => sl.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<LessonVideo> LessonVideos { get; set; }

       
    }
}
