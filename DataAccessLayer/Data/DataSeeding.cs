using DataAccessLayer.Contracts;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Admin;
using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Exams;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Contents.Questions;
using DataAccessLayer.Models.Levels;
using DataAccessLayer.Models.Students;
using DataAccessLayer.Models.Teachers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class DataSeeding(MasaqDbContext _context) : IDataSeeding
    {
        
        public async Task DataSeed()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
              await  _context.Database.MigrateAsync();
            }
            if (!_context.Admins.Any())
            {
                // --------------------- Seeding Admin ---------------------
                List<Admin> admins = new List<Admin>()
                {
                   new Admin
                   {
                       FName = "Alaa",
                       LName = "Ibrahim",
                       Gender = Gender.Female,
                       email = "alaa.ali@gmail.com"
                   },
                   new Admin
                   {
                       FName = "Somaya",
                       LName = "Mohamed",
                       Gender = Gender.Female,
                       email = "somaya.mohamed@gmail.com",
                   }
                };
               await _context.Admins.AddRangeAsync(admins);

            }

            if (!_context.Teachers.Any())
            {
                // --------------------- Seeding Teacher ---------------------
                var teacher = new Teacher
                {
                    FName = "محمد",
                    LName = "صلاح",
                    Gender = Gender.Male,
                    email = "mohamedSalah@gmail.com",
                    Age = 35,
                    Address = "حي الهرم، الجيزة",
                    City = "الجيزة",
                    LastActive = DateTime.Now,
                    IsDeleted = false,

                };

              await  _context.Teachers.AddAsync(teacher);

            }

            if (!_context.Levels.Any())
            {
                // --------------------- Seeding Levels ---------------------
                List<Level> levels = new List<Level>()
                {
                    new Level
                    {
                        LevelNumber = 1,
                        NumberOfStudents = 0,
                        AcademicYear = "2026-2027",
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = 1,
                        LastModifiedOn = DateTime.Now,
                        IsDeleted = false
                    },
                    new Level
                    {
                        LevelNumber = 2,
                        NumberOfStudents = 0,
                        AcademicYear = "2026-2027",
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = 1,
                        LastModifiedOn = DateTime.Now,
                        IsDeleted = false
                    }
                };
              await  _context.Levels.AddRangeAsync(levels);
            }

            if (!_context.Courses.Any())
            {
                // --------------------- Seeding Courses ---------------------

                // --------------------- Add Courses to level 1 ---------------------
                var level1 =await _context.Levels.FirstOrDefaultAsync(l => l.LevelNumber == 1);
                if (level1 is not null)
                {
                    List<Course> courses = new List<Course>()
                    {
                       new Course
                       {
                           Title = "الترم الأول - أولى ثانوي - الشهر الأول",
                           LevelFK = level1.Id,
                           Level=level1,
                           CreatedBy = 1,
                           CreatedOn = DateTime.Now,
                           LastModifiedBy = 1,
                           LastModifiedOn = DateTime.Now,
                           IsDeleted = false
                       },
                       new Course
                      {
                          Title = "الترم الأول - أولى ثانوي - الشهر الثاني",
                          LevelFK = level1.Id,
                          Level=level1,
                          CreatedBy = 1,
                          CreatedOn = DateTime.Now,
                          LastModifiedBy = 1,
                          LastModifiedOn = DateTime.Now,
                          IsDeleted = false
                      }
                    };
                  await  _context.Courses.AddRangeAsync(courses);
                    // إضافة الـ Courses إلى الـ Level (للعلاقة)
                    level1.Courses.Add(courses[0]);
                    level1.Courses.Add(courses[1]);

                }
                // --------------------- Add Courses to level 2 ---------------------
                var level2 =await _context.Levels.FirstOrDefaultAsync(l => l.LevelNumber == 2);
                if (level2 is not null)
                {
                    var courseTerm1 = new Course
                    {
                        Title = "الترم الأول - تانية ثانوي",
                        LevelFK = level2?.Id ?? 0, // ربط بالمستوى المضاف
                        Level = level2,
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = 1,
                        LastModifiedOn = DateTime.Now,
                        IsDeleted = false
                    };
                   await _context.Courses.AddAsync(courseTerm1);
                    // إضافة الـ Courses إلى الـ Level (للعلاقة)
                    level2.Courses.Add(courseTerm1);

                }
            }

            if (!_context.Lessons.Any())
            {
                // --------------------- Seeding Lessons ---------------------
                // --------------------- Add New Lessons for Course 1 level 1 ---------------------
                var course1 = await _context.Courses.FirstOrDefaultAsync(c => c.Id == 1);
                if (course1 is not null)
                {

                    var videos1 = new List<string> { "https://youtu.be/video1", "https://youtu.be/video2" };
                    var videos2 = new List<string> { "https://youtu.be/video3", "https://youtu.be/video4" };
                    var videos3 = new List<string> { "https://youtu.be/video5", "https://youtu.be/video6" };
                    List<Lesson> lessons = new List<Lesson>()
                    {
                           new Lesson
                           {
                              Title = "كان التامة _ الفرق بين كان الناقصة والتامة في دقايق",
                              Description = "شرح الفرق بين كان الناقصة والتامة",
                              ImageName = "صورة1.jpg",
                              //VideoName = videos1,
                              DocName = null,
                              CourseIdFK = course1.Id,
                              CreatedBy = 1,
                              CreatedOn = DateTime.Now,
                              LastModifiedBy = 1,
                              LastModifiedOn = DateTime.Now,
                              IsDeleted = false
                           },
                           new Lesson
                           {
                              Title = "إعمال اسم الفاعل _ تعلم الإعراب بسهولة",
                              Description = "شرح إعمال اسم الفاعل",
                              ImageName = "صورة2.jpg",
                              //VideoName = videos2,
                              DocName = null,
                              CourseIdFK = course1.Id,
                              CreatedBy = 1,
                              CreatedOn = DateTime.Now,
                              LastModifiedBy = 1,
                              LastModifiedOn = DateTime.Now,
                              IsDeleted = false
                           },
                           new Lesson
                           {
                               Title = "تعلم الإعراب بسهولة - كان وأخواتها",
                               Description = "شرح كان وأخواتها",
                               ImageName = "صورة3.jpg",
                               //VideoName = videos3,
                               DocName = null,
                               CourseIdFK = course1.Id,
                               CreatedBy = 1,
                               CreatedOn = DateTime.Now,
                               LastModifiedBy = 1,
                               LastModifiedOn = DateTime.Now,
                               IsDeleted = false
                           }
                    };

                  await  _context.Lessons.AddRangeAsync(lessons);
                }
                // --------------------- Add New Lessons for Course 2 level 1 ---------------------
                var course2 =await _context.Courses.FirstOrDefaultAsync(c => c.Id == 2);
                if (course2 is not null)
                {
                    var videos4 = new List<string> { "https://youtu.be/QwY1iiEUSLg", "https://youtu.be/nNyWzsPNddk" };
                    var lesson4 = new Lesson
                    {
                        Title = "المصادر",
                        Description = "",
                        ImageName = "محمد صلاح.jpg",
                        //VideoName = videos4,
                        DocName = null,
                        CourseIdFK = course2.Id,
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = 1,
                        LastModifiedOn = DateTime.Now,
                        IsDeleted = false
                    };
                   await _context.Lessons.AddAsync(lesson4);

                }

                // --------------------- Add New Lessons for Course 1 in level 2 ---------------------

                var course =await _context.Courses.FirstOrDefaultAsync(l => l.Title.Contains("الترم الأول - تانية ثانوي"));
                if (course is not null)
                {
                    List<string> Videos1 = new List<string>() {
                    "https://youtu.be/EBzmsWWFQ3Q",
                    "https://youtu.be/glx0RZiuvcM",
                    "https://youtu.be/yNdhG3EGST4"
                   };

                    var lesson1 = new Lesson
                    {
                        Title = "أدوات نصب الفعل المضارع بطريقة ممتعة",
                        Description = "",
                        ImageName = "محمد صلاح.jpg",
                        //VideoName = Videos1,
                        DocName = null,
                        CourseIdFK = course.Id,
                        course = course,
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = 1,
                        LastModifiedOn = DateTime.Now,
                        IsDeleted = false
                    };

                    List<string> Videos2 = new List<string>() {
                    "https://youtu.be/QwY1iiEUSLg",
                    "https://youtu.be/nNyWzsPNddk",
                    };
                    var lesson2 = new Lesson
                    {
                        Title = "المصادر",
                        Description = "",
                        ImageName = "محمد صلاح.jpg",
                        //VideoName = Videos2,
                        DocName = null,
                        CourseIdFK = course.Id,
                        course = course,
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = 1,
                        LastModifiedOn = DateTime.Now,
                        IsDeleted = false
                    };

                   await _context.Lessons.AddRangeAsync(lesson1, lesson2);
                    course.lessons.Add(lesson1);
                    course.lessons.Add(lesson2);

                }
            }

            if (!_context.Students.Any())
            {
                // --------------------- Seeding Students ---------------------
                // --------------------- Add Students level 1 ---------------------
                var level1 =await _context.Levels.FirstOrDefaultAsync(l => l.LevelNumber == 1);
                if (level1 is not null)
                {
                    if (!level1.Students.Any())
                    {
                        var students = new List<Student>
                        {
                           new Student { Age = 14, FName = "ياسر", LName = "حسين", Gender = Gender.Male, email = "yasser.hussein@example.com", Address = "حي النهضة", City = "المنصورة", LastActive = DateTime.Now, IsDeleted = false, Grade = 8, PhoneNumber = "01122334455", ParentPhoneNumber = "01122334456", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 },
                           new Student { Age = 15, FName = "نسرين", LName = "عادل", Gender = Gender.Female, email = "nasreen.adel@example.com", Address = "شارع الجيش", City = "الإسماعيلية", LastActive = DateTime.Now, IsDeleted = false, Grade = 9, PhoneNumber = "01122334457", ParentPhoneNumber = "01122334458", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 },
                           new Student { Age = 16, FName = "طارق", LName = "عزيز", Gender = Gender.Male, email = "tarek.aziz@example.com", Address = "حي الرحاب", City = "القاهرة", LastActive = DateTime.Now, IsDeleted = false, Grade = 10, PhoneNumber = "01122334459", ParentPhoneNumber = "01122334460", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 },
                           new Student { Age = 17, FName = "لينا", LName = "فهمي", Gender = Gender.Female, email = "leena.fahmy@example.com", Address = "شارع المستقبل", City = "السويس", LastActive = DateTime.Now, IsDeleted = false, Grade = 11, PhoneNumber = "01122334461", ParentPhoneNumber = "01122334462", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 },
                           new Student { Age = 14, FName = "خالد", LName = "عبدالرحمن", Gender = Gender.Male, email = "khalid.abdelrahman@example.com", Address = "حي الزهور", City = "المنوفية", LastActive = DateTime.Now, IsDeleted = false, Grade = 8, PhoneNumber = "01122334463", ParentPhoneNumber = "01122334464", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 },
                           new Student { Age = 15, FName = "روان", LName = "إسماعيل", Gender = Gender.Female, email = "rawan.ismail@example.com", Address = "شارع النيل", City = "أسيوط", LastActive = DateTime.Now, IsDeleted = false, Grade = 9, PhoneNumber = "01122334465", ParentPhoneNumber = "01122334466", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 },
                           new Student { Age = 16, FName = "سامي", LName = "نور", Gender = Gender.Male, email = "sami.noor@example.com", Address = "حي السلام", City = "الشرقية", LastActive = DateTime.Now, IsDeleted = false, Grade = 10, PhoneNumber = "01122334467", ParentPhoneNumber = "01122334468", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 },
                           new Student { Age = 17, FName = "سلمى", LName = "شاكر", Gender = Gender.Female, email = "salma.shaker@example.com", Address = "شارع التحرير", City = "الفيوم", LastActive = DateTime.Now, IsDeleted = false, Grade = 11, PhoneNumber = "01122334469", ParentPhoneNumber = "01122334470", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1},
                           new Student { Age = 14, FName = "عادل", LName = "مصطفى", Gender = Gender.Male, email = "adel.mustafa@example.com", Address = "حي الورود", City = "بنها", LastActive = DateTime.Now, IsDeleted = false, Grade = 8, PhoneNumber = "01122334471", ParentPhoneNumber = "01122334472", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 },
                           new Student { Age = 15, FName = "مريم", LName = "زكي", Gender = Gender.Female, email = "marriam.zaki@example.com", Address = "شارع الجزائر", City = "القاهرة", LastActive = DateTime.Now, IsDeleted = false, Grade = 9, PhoneNumber = "01122334473", ParentPhoneNumber = "01122334474", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level1.Id, level = level1 }
                        };

                        level1.NumberOfStudents = _context.Students.Count(s => s.levelFK == level1.Id) + students.Count;
                       await _context.Students.AddRangeAsync(students);
                    }
                    // --------------------- Add Students level 2 ---------------------

                    var level =await _context.Levels.FirstOrDefaultAsync(l => l.LevelNumber == 2);

                    if (level is not null)
                    {

                        var students = new List<Student>
                        {
                             new Student { Age = 15, FName = "أحمد", LName = "محمد", Gender = Gender.Male, email = "ahmed.mohamed@example.com", Address = "شارع المعاهد", City = "القاهرة", LastActive = DateTime.Now, IsDeleted = false, Grade = 9, PhoneNumber = "01234567890", ParentPhoneNumber = "01234567891", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 16, FName = "سارة", LName = "علي", Gender = Gender.Female, email = "sarah.ali@example.com", Address = "حي الزهراء", City = "الإسكندرية", LastActive = DateTime.Now, IsDeleted = false, Grade = 10, PhoneNumber = "01234567892", ParentPhoneNumber = "01234567893", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 17, FName = "محمود", LName = "خالد", Gender = Gender.Male, email = "mahmoud.khaled@example.com", Address = "شارع الهرم", City = "الجيزة", LastActive = DateTime.Now, IsDeleted = false, Grade = 11, PhoneNumber = "01234567894", ParentPhoneNumber = "01234567895", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 15, FName = "ليلى", LName = "عبدالله", Gender = Gender.Female, email = "laila.abdullah@example.com", Address = "حي النصر", City = "القاهرة", LastActive = DateTime.Now, IsDeleted = false, Grade = 9, PhoneNumber = "01234567896", ParentPhoneNumber = "01234567897", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 16, FName = "يوسف", LName = "إبراهيم", Gender = Gender.Male, email = "youssef.ibrahim@example.com", Address = "شارع الجمهورية", City = "الإسكندرية", LastActive = DateTime.Now, IsDeleted = false, Grade = 10, PhoneNumber = "01234567898", ParentPhoneNumber = "01234567899", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 17, FName = "نورا", LName = "حسن", Gender = Gender.Female, email = "nora.hassan@example.com", Address = "حي السلام", City = "القاهرة", LastActive = DateTime.Now, IsDeleted = false, Grade = 11, PhoneNumber = "01234567900", ParentPhoneNumber = "01234567901", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 15, FName = "عمر", LName = "سعيد", Gender = Gender.Male, email = "omar.saeed@example.com", Address = "شارع الهرم", City = "الجيزة", LastActive = DateTime.Now, IsDeleted = false, Grade = 9, PhoneNumber = "01234567902", ParentPhoneNumber = "01234567903", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 16, FName = "هدى", LName = "عادل", Gender = Gender.Female, email = "huda.adel@example.com", Address = "حي الزيتون", City = "القاهرة", LastActive = DateTime.Now, IsDeleted = false, Grade = 10, PhoneNumber = "01234567904", ParentPhoneNumber = "01234567905", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 17, FName = "كريم", LName = "أحمد", Gender = Gender.Male, email = "karim.ahmed@example.com", Address = "شارع السادات", City = "الإسكندرية", LastActive = DateTime.Now, IsDeleted = false, Grade = 11, PhoneNumber = "01234567906", ParentPhoneNumber = "01234567907", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level },
                             new Student { Age = 15, FName = "ريم", LName = "فاروق", Gender = Gender.Female, email = "reem.farouk@example.com", Address = "حي المعادي", City = "القاهرة", LastActive = DateTime.Now, IsDeleted = false, Grade = 9, PhoneNumber = "01234567908", ParentPhoneNumber = "01234567909", CreationBy = 1, CreatedOn = DateTime.Now, LastModified = DateTime.Now, levelFK = level.Id, level = level }
                        };

                        level.NumberOfStudents = _context.Students.Count(s => s.levelFK == level.Id);
                       await _context.Students.AddRangeAsync(students);

                    }
                }
            }
            // --------------------- Add New Announcements for Lesson 1 & 2 in Course 1 ---------------------
            var Lesson1 = _context.Lessons.Include(l => l.announcements).Include(l => l.exams).FirstOrDefault(l => l.Id == 1);
            if (Lesson1 is not null && !Lesson1.announcements.Any())
            {
                var announcements = new List<Announcement>()
                        {
                           new Announcement
                           {
                                Header = "إعلان جديد: بدء الترم",
                                Body = "يرجى حضور الدرس الأول غدًا في الساعة 10 صباحًا.",
                                IsPinned = true,
                                LessonIdFK = Lesson1.Id,
                                CreatedBy = 1,
                                CreatedOn = DateTime.Now,
                                LastModifiedBy = 1,
                                LastModifiedOn = DateTime.Now,
                                IsDeleted = false
                           },
                           new Announcement
                           {
                               Header = "تغيير موعد الامتحان",
                               Body = "تم تغيير موعد الامتحان إلى يوم الإثنين الساعة 2 ظهرًا.",
                               IsPinned = false,
                               LessonIdFK = Lesson1.Id,
                               CreatedBy = 1,
                               CreatedOn = DateTime.Now,
                               LastModifiedBy = 1,
                               LastModifiedOn = DateTime.Now,
                               IsDeleted = false
                           }
                        };
               await _context.Announcements.AddRangeAsync(announcements);
            }

            var Lesson2 = _context.Lessons.Include(l => l.announcements).Include(l => l.exams).FirstOrDefault(l => l.Id == 2);
            if (Lesson2 is not null && !Lesson2.announcements.Any())
            {
                var announcements = new List<Announcement>()
                        {
                           new Announcement
                           {
                                   Header = "دورة تدريبية مجانية",
                                   Body = "سوف نقيم دورة تدريبية حول القواعد يوم السبت.",
                                   IsPinned = true,
                                   LessonIdFK = Lesson2.Id,
                                   CreatedBy = 1,
                                   CreatedOn = DateTime.Now,
                                   LastModifiedBy = 1,
                                   LastModifiedOn = DateTime.Now,
                                   IsDeleted = false
                           },
                           new Announcement
                           {
                               Header = "إعدادات الواجب",
                               Body = "يرجى تقديم الواجب رقم 3 قبل يوم الخميس.",
                               IsPinned = false,
                               LessonIdFK = Lesson2.Id,
                               CreatedBy = 1,
                               CreatedOn = DateTime.Now,
                               LastModifiedBy = 1,
                               LastModifiedOn = DateTime.Now,
                               IsDeleted = false
                           },
                        };
               await _context.Announcements.AddRangeAsync(announcements);
            }


            // --------------------- Add New Exams for Lesson 1 & 2 in Course 1 ---------------------
            if (Lesson1 is not null && !Lesson1.exams.Any())
            {
                var exam = new Exam
                {
                    Duration = 60, // مدة بالدقائق
                    Title = "اختبار أدوات نصب الفعل",
                    Description = "اختبار لدرس أدوات نصب الفعل المضارع.",
                    StartTime = DateTime.Now.AddDays(1), // غدًا
                    EndTime = DateTime.Now.AddDays(1).AddHours(1), // بعد ساعة من البداية
                    IsCompleted = false,
                    Status = null,
                    IsAvaliable = true,
                    LessonId = Lesson1.Id, // ربط بالدرس الأول
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = 1,
                    LastModifiedOn = DateTime.Now,
                    IsDeleted = false
                };
              await  _context.Exams.AddRangeAsync(exam);
            }
            if (Lesson2 is not null && !Lesson2.exams.Any())
            {
                var exam = new Exam
                {
                    Duration = 60, // مدة بالدقائق
                    Title = "اختبار التوكيد",
                    Description = "اختبار التوكيد.",
                    StartTime = DateTime.Now.AddDays(1), // غدًا
                    EndTime = DateTime.Now.AddDays(1).AddHours(1), // بعد ساعة من البداية
                    IsCompleted = false,
                    Status = null,
                    IsAvaliable = true,
                    LessonId = Lesson2.Id, // ربط بالدرس الأول
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = 1,
                    LastModifiedOn = DateTime.Now,
                    IsDeleted = false
                };
              await  _context.Exams.AddRangeAsync(exam);
            }

            // --------------------- Add Questions for exam of lesson 1 ---------------------
            var exam1 =await _context.Exams.Include(e => e.questions).FirstOrDefaultAsync(e => e.Id == 1);
            if (exam1 is not null && !exam1.questions.Any())
            {
                var questions = new List<Question>()
                        {
                           new Question
                           {
                               Header = "ما هي أدوات نصب الفعل؟",
                               Body = "حدد جميع أدوات نصب الفعل المضارع.",
                               Mark = 5,
                               Type = QuestionType.MCQ,
                               ExamId = exam1.Id, // ربط بالاختبار الأول
                               CreatedBy = 1,
                               CreatedOn = DateTime.Now,
                               LastModifiedBy = 1,
                               LastModifiedOn = DateTime.Now,
                               IsDeleted = false,
                               Options = new HashSet<QuestionOptions>
                               {
                                   new QuestionOptions { OptionText = "أن", IsCorrect = true },
                                   new QuestionOptions { OptionText = "لن", IsCorrect = false },
                                   new QuestionOptions { OptionText = "كي", IsCorrect = false },
                                   new QuestionOptions { OptionText = "لما", IsCorrect = false },
                                   new QuestionOptions { OptionText = "حتى", IsCorrect = false }
                               }
                           },
                           new Question
                           {
                               Header = "هل الجملة صحيحة؟",
                               Body = "الفعل المضارع ينصب بـ 'أن'.",
                               Mark = 3,
                               Type = QuestionType.TrueFalse, // افتراضي
                               ExamId = exam1.Id, // ربط بالاختبار الأول
                               CreatedBy = 1,
                               CreatedOn = DateTime.Now,
                               LastModifiedBy = 1,
                               LastModifiedOn = DateTime.Now,
                               IsDeleted = false
                           }
                        };
                await _context.Questions.AddRangeAsync(questions);
            }

            // --------------------- Add Questions for exam of lesson 2 ---------------------
            var exam2 =await _context.Exams.Include(e => e.questions).FirstOrDefaultAsync(e => e.Id == 2);
            if (exam2 is not null && !exam2.questions.Any())
            {
                var questions = new List<Question>()
                        {
                           new Question
                           {
                               Header = "ما هي أدوات التوكيد؟",
                               Body = "حدد جميع أدوات التوكيد.",
                               Mark = 5,
                               Type = QuestionType.MCQ, // افتراضي، استبدله حسب enum الخاص بك
                               ExamId = exam2.Id, // ربط بالاختبار الأول
                               CreatedBy = 1,
                               CreatedOn = DateTime.Now,
                               LastModifiedBy = 1,
                               LastModifiedOn = DateTime.Now,
                               IsDeleted = false,
                               Options = new HashSet<QuestionOptions>
                               {
                                   new QuestionOptions { OptionText = "قد", IsCorrect = true },
                                   new QuestionOptions { OptionText = "لن", IsCorrect = false },
                                   new QuestionOptions { OptionText = "إن", IsCorrect = false },
                                   new QuestionOptions { OptionText = "لا", IsCorrect = false },
                                   new QuestionOptions { OptionText = "أكد", IsCorrect = false }
                               }
                           },
                           new Question
                           {
                               Header = "هل الجملة صحيحة؟",
                               Body = "يا اداه توكيد ؟",
                               Mark = 3,
                               Type = QuestionType.TrueFalse, // افتراضي
                               ExamId = exam2.Id, // ربط بالاختبار الأول
                               CreatedBy = 1,
                               CreatedOn = DateTime.Now,
                               LastModifiedBy = 1,
                               LastModifiedOn = DateTime.Now,
                               IsDeleted = false
                           }
                        };
              await  _context.Questions.AddRangeAsync(questions);
            }

          await  _context.SaveChangesAsync();

        }
    }
}