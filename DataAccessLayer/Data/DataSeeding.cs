using DataAccessLayer.Contracts;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Exams;
using DataAccessLayer.Models.Contents.Lessons;
using DataAccessLayer.Models.Contents.Questions;
using DataAccessLayer.Models.IdentityModels;
using DataAccessLayer.Models.Levels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class DataSeeding(MasaqDbContext _context, UserManager<ApplicationUser> _usermanager, RoleManager<IdentityRole> _rolemanager) : IDataSeeding
    {

        public async Task DataSeed()
        {


                // --------------------- Seeding Levels ---------------------
            if (!_context.Levels.Any())
            {
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
                    },
                    new Level
                    {
                        LevelNumber = 3,
                        NumberOfStudents = 0,
                        AcademicYear = "2026-2027",
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = 1,
                        LastModifiedOn = DateTime.Now,
                        IsDeleted = false
                    }
                };
                await _context.Levels.AddRangeAsync(levels);
                await _context.SaveChangesAsync();
            }

            // --------------------- Seeding Courses ---------------------
            if (!_context.Courses.Any())
            {
                // --------------------- Seeding Courses ---------------------

                // --------------------- Add Courses to level 1 ---------------------
                var level1 = await _context.Levels.FirstOrDefaultAsync(l => l.LevelNumber == 1);
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
                    await _context.Courses.AddRangeAsync(courses);
                    // إضافة الـ Courses إلى الـ Level (للعلاقة)
                    level1.Courses.Add(courses[0]);
                    level1.Courses.Add(courses[1]);

                }
                // --------------------- Add Courses to level 2 ---------------------
                var level2 = await _context.Levels.FirstOrDefaultAsync(l => l.LevelNumber == 2);
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


            // --------------------- Seeding Lessons ---------------------
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

                    await _context.Lessons.AddRangeAsync(lessons);
                }
                // --------------------- Add New Lessons for Course 2 level 1 ---------------------
                var course2 = await _context.Courses.FirstOrDefaultAsync(c => c.Id == 2);
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

                var course = await _context.Courses.FirstOrDefaultAsync(l => l.Title.Contains("الترم الأول - تانية ثانوي"));
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
                await _context.Exams.AddRangeAsync(exam);
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
                await _context.Exams.AddRangeAsync(exam);
            }

            // --------------------- Add Questions for exam of lesson 1 ---------------------
            var exam1 = await _context.Exams.Include(e => e.questions).FirstOrDefaultAsync(e => e.Id == 1);
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
            var exam2 = await _context.Exams.Include(e => e.questions).FirstOrDefaultAsync(e => e.Id == 2);
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
                await _context.Questions.AddRangeAsync(questions);
            }

            await _context.SaveChangesAsync();

        }
    }
}








//if ((await _context.Database.GetPendingMigrationsAsync()).Any())
//{
//    await _context.Database.MigrateAsync();
//}



//        if (!_rolemanager.Roles.Any())
//        {
//            var role1 = new IdentityRole("Teacher");
//            var role2 = new IdentityRole("Student");
//            await _rolemanager.CreateAsync(role1);
//            await _rolemanager.CreateAsync(role2);

//        }

//        if (!_usermanager.Users.Any()&&!_context.Students.Any())
//        {
//            var leveltake =  await _context.Levels.FirstOrDefaultAsync();
//            if (leveltake is null) throw new Exception("levels not found exception");
//            var user = new ApplicationUser()
//            {
//                UserName = "01558921123",
//                Email = "01558921123@gmail.com",
//                Role = "Student"
//            };
//            var user2 = new ApplicationUser()
//            {
//                UserName = "Admin",
//                Email = "Admin@gmail.com",
//                Role = "Teacher"
//            };

//            await _usermanager.CreateAsync(user, "Pp@1234");
//            await _usermanager.CreateAsync(user2, "Pp@1234");
//            await _usermanager.AddToRoleAsync(user, "Student");
//            await _usermanager.AddToRoleAsync(user2, "Teacher");

//            var student1 = new Student()
//            {
//                levelFK = leveltake.Id,
//                PhoneNumber = "01558921123",
//                ParentPhoneNumber = "01011920192",
//                LastModified = DateTime.UtcNow,
//                CreatedOn = DateTime.UtcNow,
//                UserId = user.Id,
//                Age = 24,
//                FullName = "Ahmed Ashraf",
//                Gender = Gender.Male,
//                email = "01558921123@gmail.com",
//                Address = "menofia Ashmon",
//                City = "Minofia",
//                LastActive = DateTime.UtcNow,
//                Government = "menofia"



//            };

//            _context.Students.Add(student1);
//            await _context.SaveChangesAsync();



//            _context.ChangeTracker.Clear();

//            var existingTeacher = await _context.Teachers.FirstOrDefaultAsync(t => t.UserId == user2.Id);
//            if (existingTeacher == null)
//            {
//                var teacher = new Teacher()
//                {
//                    UserId = user2.Id,
//                    Age = 24,
//                    FullName = "Ahmed Ashraf",
//                    Gender = Gender.Male,
//                    email = "01558921123@gmail.com",
//                    Address = "menofia Ashmon",
//                    City = "Minofia",
//                    LastActive = DateTime.UtcNow,
//                };
//                _context.Teachers.Add(teacher);
//                await _context.SaveChangesAsync();
//                _context.ChangeTracker.Clear();
//            }




//            //add list of students 
//            var studentInfos = new List<(string userName, string email, string phone, string parentPhone)>
//{
//    ("01558921123", "01558921123@gmail.com", "01558921123", "01011920192"),
//    ("01558921124", "01558921124@gmail.com", "01558921124", "01011920193"),
//    ("01558921125", "01558921125@gmail.com", "01558921125", "01011920194"),
//    ("01558921126", "01558921126@gmail.com", "01558921126", "01011920195"),
//    ("01558921127", "01558921127@gmail.com", "01558921127", "01011920196"),
//    ("01558921128", "01558921128@gmail.com", "01558921128", "01011920197")
//};

//            foreach (var (userName, email, phone, parentPhone) in studentInfos)
//            {
//                var appUser = new ApplicationUser
//                {
//                    UserName = userName,
//                    Email = email,
//                    Role = "Student"
//                };

//                var result = await _usermanager.CreateAsync(appUser, "Pp@1234");
//                if (result.Succeeded)
//                {
//                    await _usermanager.AddToRoleAsync(appUser, "Student");

//                    var student = new Student
//                    {
//                        levelFK = leveltake.Id,
//                        PhoneNumber = phone,
//                        ParentPhoneNumber = parentPhone,
//                        LastModified = DateTime.UtcNow,
//                        CreatedOn = DateTime.UtcNow,
//                        UserId = appUser.Id,
//                         Age = 24,
//                        FullName = "Ahmed Ashraf",
//                        Gender = Gender.Male,
//                        email = "01558921123@gmail.com",
//                        Address = "menofia Ashmon",
//                        City = "Minofia",
//                        LastActive = DateTime.UtcNow,
//                    };

//                    _context.Students.Add(student);
//                    await _context.SaveChangesAsync();
//                }
//            }
//        }

//}


//if (!_context.Admins.Any())
//{
//    // --------------------- Seeding Admin ---------------------
//    List<Admin> admins = new List<Admin>()
//    {
//       new Admin
//       {
//           FName = "Alaa",
//           LName = "Ibrahim",
//           Gender = Gender.Female,
//           email = "alaa.ali@gmail.com"
//       },
//       new Admin
//       {
//           FName = "Somaya",
//           LName = "Mohamed",
//           Gender = Gender.Female,
//           email = "somaya.mohamed@gmail.com",
//       }
//    };
//   await _context.Admins.AddRangeAsync(admins);

//}

//if (!_context.Teachers.Any())
//{
//    // --------------------- Seeding Teacher ---------------------
//    var teacher = new Teacher
//    {
//        FName = "محمد",
//        LName = "صلاح",
//        Gender = Gender.Male,
//        email = "mohamedSalah@gmail.com",
//        Age = 35,
//        Address = "حي الهرم، الجيزة",
//        City = "الجيزة",
//        LastActive = DateTime.Now,
//        IsDeleted = false,

//    };

//  await  _context.Teachers.AddAsync(teacher);

//}

