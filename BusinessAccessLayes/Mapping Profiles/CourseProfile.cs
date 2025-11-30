using AutoMapper;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Lessons;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObjects.Courses;
using Shared.DataTransferObjects.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Mapping_Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            // Course → CourseDto
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.LevelName,
                           opt => opt.MapFrom(src => src.Level.AcademicYear))
                .ForMember(dest => dest.LessonsCount,
                           opt => opt.MapFrom(src => src.lessons.Count))
                .ForMember(dest => dest.ImageUrl, src => src.MapFrom<PictureCourceResolver<CourseDto>>());

            // Course → CourseDetailsDto 
            CreateMap<Course, CourseDetailsDto>()
                .ForMember(dest => dest.LevelName,
                           opt => opt.MapFrom(src => src.Level.AcademicYear))
                .ForMember(dest => dest.LessonsCount,
                           opt => opt.MapFrom(src => src.lessons.Count))
                .ForMember(dest => dest.Lessons,
                           opt => opt.MapFrom(src => src.lessons))
                 .ForMember(dest => dest.ImageUrl, src => src.MapFrom<PictureCourceResolver<CourseDetailsDto>>()); 

            // DTOs → Entity
            CreateMap<CreatAndUpdateCourseDto, Course>()
                  .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            // Lesson → LessonDto 
            CreateMap<Lesson, LessonDTO>()
                .ForMember(dest => dest.CourseName,
                           opt => opt.MapFrom(src => src.course.Title))
                .ForMember(dest => dest.LevelName,
                           opt => opt.MapFrom(src => src.course.Level.AcademicYear));
        }
    }

    public class PictureCourceResolver<TDestination> : IValueResolver<Course, TDestination, string>
    {
        private readonly IConfiguration _configuration;

        public PictureCourceResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Course source, TDestination destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.ImageUrl))
                return string.Empty;

            return $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.ImageUrl}";
        }
    }
}