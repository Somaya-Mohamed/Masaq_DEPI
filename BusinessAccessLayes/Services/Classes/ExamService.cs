using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using BusinessAccessLayes.Specification.ExamSpc;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Contents.Exams;
using DataAccessLayer.Models.Students;
using DataAccessLayer.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Classes
{
    public class ExamService(IUnitOfWork unitOfWork, IMapper mapper , MasaqDbContext context) : IExamService
    {
   


        public async Task<ExamDto?> CreateAsync(CreatAndUpdateExamDto dto)
        {
            var exam = mapper.Map<Exam>(dto);

            var repo = unitOfWork.GetRepository<Exam, int>();
            await repo.AddAsync(exam);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ExamDto>(exam);
       }






        public async Task<bool> DeleteAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Exam, int>();
            var exam = await repo.GetByIdAsync(id);
            if (exam == null) return false;
            repo.Delete(exam);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

   



        public async Task<IEnumerable<ExamDto>> GetAllAsync()
        {
            var repo = unitOfWork.GetRepository<Exam, int>();
            var exams = await repo.GetAllAsync();
            return mapper.Map<IEnumerable<ExamDto>>(exams);
        }










        public async Task<ExamDetailsDto?> GetByIdAsync(int stuid , int id)
        {
            //var repo = unitOfWork.GetRepository<Exam, int>();
            //var specs = new ExamByIdSpecification(id);
            //var exams = await repo.GetAllAsync(specs);
            //var exam = exams.FirstOrDefault();

            var studentExamRepo = unitOfWork.GetRepository<StudentExam, int>();
            var allstudentExams = await studentExamRepo.GetAllAsync();
            var studentExam = allstudentExams.FirstOrDefault(se => se.ExamId == id && se.StudentId == stuid);
            if(studentExam != null)
                throw new Exception("you taked the exam");


            var exam = await context.Exams
         .Include(e => e.questions)
             .ThenInclude(q => q.Options)   
         .FirstOrDefaultAsync(e => e.Id == id);

            return mapper.Map<ExamDetailsDto?>(exam) ?? null;
        }







        public async Task<StudentExamDto> SendStudentExam(int StuId, StudentExamDto StudentExamDto)
        {
            var repo = unitOfWork.GetRepository<Exam, int>();
            var specs = new ExamByIdSpecification(StudentExamDto.ExamId);
            var exams = await repo.GetAllAsync(specs);
            var exam = exams.FirstOrDefault();
            if(exam == null) throw new Exception("Exam not found.");

            var questionNumber = exam.questions.Count;

            var studentExam = mapper.Map<StudentExam>(StudentExamDto);

            //var studentanswers = studentExam.Answers;

            int correctAnswers = 0;

            foreach (var question in exam.questions)
            {
                await context.Entry(question)
                    .Collection(q => q.Options)
                    .LoadAsync();
            }

            foreach (var stuanswer in studentExam.Answers) {

                var ques = exam.questions.FirstOrDefault(q=>q.Id == stuanswer.QuestionId);
                if (ques == null) continue;


                var ans = ques.Options.FirstOrDefault(a => a.IsCorrect);
                if(ans == null) continue;


                if (ans.Id == stuanswer.AnswerId)
                    correctAnswers++;


                
            }

            studentExam.Grade = (double)correctAnswers / questionNumber * 100;

            studentExam.StudentId = StuId;
            var studentExamRepo = unitOfWork.GetRepository<StudentExam, int>();

            await studentExamRepo.AddAsync(studentExam);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<StudentExamDto>(studentExam);
        }







        //public async Task<bool> UpdateAsync(int id, CreatAndUpdateExamDto dto)
        //{
        //    var repo = unitOfWork.GetRepository<Exam, int>();   
        //    var exam = repo.GetByIdAsync(id);

        //    var x = mapper.Map<Exam>(dto);

        //    var newexam = new Exam
        //    {
        //        Id = exam.Result.Id,
        //        Title = x.Title,
        //        IsAvaliable = x.IsAvaliable,
        //        questions = x.questions,
        //        Duration = x.Duration,
        //        StartTime = x.StartTime,
        //        LessonId = x.LessonId,
        //        CourseId = x.CourseId

        //    };

        //    repo.Update(newexam);
        //    await unitOfWork.SaveChangesAsync();

        //    return true;
        //}






        public async Task<bool> UpdateAsync(int id, CreatAndUpdateExamDto dto)
        {
            var repo = unitOfWork.GetRepository<Exam, int>();
            var exam = await repo.GetByIdAsync(id);

            if (exam == null) return false;
           mapper.Map(dto, exam);

           repo.Update(exam);
            await unitOfWork.SaveChangesAsync();

            return true;
        }

    }
}
