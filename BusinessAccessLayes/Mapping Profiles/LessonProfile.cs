using AutoMapper;
using DataAccessLayer.Models.Contents.Lessons;
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
        .ForMember(dest => dest.ImageName, opt => opt.MapFrom<PictureResolver<LessonDTO>>());

            CreateMap<Lesson, LessonDetailsDTO>()
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom<PictureResolver<LessonDetailsDTO>>());

        }
    }
}
