using AutoMapper;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Lessons;
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
                           opt => opt.MapFrom(src => src.lessons.Count));

            // Course → CourseDetailsDto (مع الدروس)
            CreateMap<Course, CourseDetailsDto>()
                .ForMember(dest => dest.LevelName,
                           opt => opt.MapFrom(src => src.Level.AcademicYear))
                .ForMember(dest => dest.LessonsCount,
                           opt => opt.MapFrom(src => src.lessons.Count))
                .ForMember(dest => dest.Lessons,
                           opt => opt.MapFrom(src => src.lessons));

            // DTOs → Entity
            CreateMap<CreatAndUpdateCourseDto, Course>();

            // Lesson → LessonDto (للـ CourseDetailsDto)
            CreateMap<Lesson, LessonDTO>()
                .ForMember(dest => dest.CourseName,
                           opt => opt.MapFrom(src => src.course.Title))
                .ForMember(dest => dest.LevelName,
                           opt => opt.MapFrom(src => src.course.Level.AcademicYear));
        }
    }
}