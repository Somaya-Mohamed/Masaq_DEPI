using AutoMapper;
using BusinessAccessLayes.Services.Classes;
using BusinessAccessLayes.Services.Interfaces;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.IdentityModels;
using DataAccessLayer.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.ServiceManagers
{

    public class ServiceManager(IUnitOfWork _unitOfWork,IMapper _mapper , MasaqDbContext _context , UserManager<ApplicationUser> _usermanager , IConfiguration _config) : IServiceManager
    {
        private readonly Lazy<ILessonService> _lazyLessonService = new Lazy<ILessonService>(() => new LessonService(_unitOfWork, _mapper));

        private readonly Lazy<IAuthenticationService> _AuthenticationService = new Lazy<IAuthenticationService>(()=>new Authentication( _usermanager , _context ,_config));

     
        private readonly Lazy<IAnncouncementService> _lazyAnnouncementService = new Lazy<IAnncouncementService>(() => new AnnouncementService(_unitOfWork, _mapper));

        private readonly Lazy<ICommentService> _lazyCommentService = new Lazy<ICommentService>(() => new CommentService(_unitOfWork, _mapper));
    

        public IAuthenticationService AuthenticationService => _AuthenticationService.Value;

        public IAnncouncementService AnnouncementService => _lazyAnnouncementService.Value;
        public ILessonService LessonService => _lazyLessonService.Value;
        public ICommentService CommentService => _lazyCommentService.Value;

    
    }
}
