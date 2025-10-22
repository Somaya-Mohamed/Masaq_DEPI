using DataAccessLayer.Models;
using DataAccessLayer.Models.Admin;
using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Models.Contents.Answers;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Exams;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Contents.Questions;
using DataAccessLayer.Models.Levels;
using DataAccessLayer.Models.Notifications;
using DataAccessLayer.Models.Students;
using DataAccessLayer.Models.Teachers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer.Data.Contexts
{
    public class MasaqDbContext : DbContext
    {
        public MasaqDbContext(DbContextOptions<MasaqDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HumanBaseEntity>().UseTpcMappingStrategy();
            modelBuilder.Entity<HumanBaseEntity>()
               .Property(h => h.Id)
               .ValueGeneratedNever();

            // Configure derived types
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");



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
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<LessonVideo> LessonVideos { get; set; }
    }
}
