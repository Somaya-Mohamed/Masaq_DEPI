using AutoMapper;
using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Models.Contents.Comments;
using DataAccessLayer.Models.Contents.Lessons;
using Shared.DataTransferObjects.Announcements;
using Shared.DataTransferObjects.Comments;
using Shared.DataTransferObjects.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Mapping_Profiles
{
    public class LessonProfile:Profile
    {
        public LessonProfile() {

            CreateMap<Lesson, LessonDTO>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.course.Title))
                .ForMember(dest => dest.Announcements, opt => opt.MapFrom(src => src.announcements))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.comments))
                .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.course.Level.AcademicYear))
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom<PictureResolver<LessonDTO>>());

            CreateMap<Lesson, LessonDetailsDTO>()
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom<PictureResolver<LessonDetailsDTO>>());



            CreateMap<Lesson, UpdateLessonDTO>()
              .ReverseMap()
              .ForMember(d => d.announcements, opt => opt.Ignore())
.ForMember(d => d.exams, opt => opt.Ignore())
.ForMember(d => d.comments, opt => opt.Ignore())
.ForMember(d => d.studentLessons, opt => opt.Ignore())
.ForMember(d => d.LessonVideos, opt => opt.Ignore())
.ForMember(dest => dest.course, opt => opt.Ignore());
            //.ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.course.Title))
            //.ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.course.Level.AcademicYear))
            //.ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.LessonVideos.Select(v => v.VideoURL)))

            // **Important:** Map Announcement -> AnnouncementDTO
            CreateMap<Announcement, AnnouncementDTO>()
                .ForMember(dist=>dist.LessonId,option=>option.MapFrom(src=>src.LessonIdFK))
                .ReverseMap();

            // Map Comment -> CommentDTO
            CreateMap<Comment, CommentDTO>();
            CreateMap<Comment, CreateCommentDTO>()
                .ForMember(dist => dist.LessonIdFK, option => option.MapFrom(src => src.LessonIdFK))
                .ForMember(dist => dist.StudentIdFK, option => option.MapFrom(src => src.StudentIdFK))
                .ReverseMap();
        }
    }
}
