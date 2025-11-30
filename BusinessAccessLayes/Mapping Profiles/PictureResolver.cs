using AutoMapper;
using DataAccessLayer.Models.Contents.Courses;
using DataAccessLayer.Models.Contents.Lessons;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObjects.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Mapping_Profiles
{
    public class PictureResolver<TDestination> : IValueResolver<Lesson, TDestination, string>
    {
        private readonly IConfiguration _configuration;

        public PictureResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Lesson source, TDestination destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.ImageName))
                return string.Empty;

            return $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.ImageName}";
        }
    }


}
