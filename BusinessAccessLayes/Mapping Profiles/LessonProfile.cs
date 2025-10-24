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
              .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.course.Title))
              .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.course.Level.AcademicYear))
              .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.LessonVideos.Select(v => v.VideoURL)))
              .ReverseMap();

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
