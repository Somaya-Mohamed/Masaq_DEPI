using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Contents.Answers;
using DataAccessLayer.Models.Contents.Exams;
using DataAccessLayer.Models.Contents.Questions;
using Shared.DataTransferObjects.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Mapping_Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamDto>();
            CreateMap<Exam, ExamDetailsDto>();
            CreateMap<CreatAndUpdateExamDto , Exam>();
            CreateMap<StudentExamDto, StudentExam>().ReverseMap();
            CreateMap<QuestionDto, Question>().ReverseMap();
            CreateMap<AnswerDto , Answer>().ReverseMap();
            CreateMap<StudentAnswerDto, StudentAnswer>().ReverseMap();
        }
    }
}
