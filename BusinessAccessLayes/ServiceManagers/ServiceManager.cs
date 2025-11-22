using AutoMapper;
using BusinessAccessLayes.Services.Classes;
using BusinessAccessLayes.Services.Interfaces;
using BusinessLogic.Services.Interfaces;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.IdentityModels;
using DataAccessLayer.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BusinessAccessLayes.ServiceManagers
{

    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper, MasaqDbContext _context, UserManager<ApplicationUser> _usermanager, IConfiguration _config, IEmailService _emailService, RoleManager<IdentityRole> _roleManager , IAttachmentService _attach) : IServiceManager
    {
        private readonly Lazy<ILessonService> _lazyLessonService = new Lazy<ILessonService>(() => new LessonService(_unitOfWork, _mapper , _attach));

        private readonly Lazy<IAuthenticationService> _AuthenticationService = new Lazy<IAuthenticationService>(() => new Authentication(_usermanager, _context, _config, _emailService));


        private readonly Lazy<IAnncouncementService> _lazyAnnouncementService = new Lazy<IAnncouncementService>(() => new AnnouncementService(_unitOfWork, _mapper));
        private readonly Lazy<IEnrollmentService> _lazyEnrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService(_context));

        private readonly Lazy<ICommentService> _lazyCommentService = new Lazy<ICommentService>(() => new CommentService(_unitOfWork, _mapper));
        private readonly Lazy<IUserService> _lazyUserService = new(() => new UserService(_usermanager, _mapper, _context));
        private readonly Lazy<IRoleService> _lazyRoleService = new(() => new RoleService(_roleManager, _mapper));

        private readonly Lazy<ICourseService> _lazyCourseService = new(() => new CourseService(_unitOfWork, _mapper , _attach));

        public IAuthenticationService AuthenticationService => _AuthenticationService.Value;

        public IAnncouncementService AnnouncementService => _lazyAnnouncementService.Value;
        public IEnrollmentService EnrollmentService => _lazyEnrollmentService.Value;
        public ILessonService LessonService => _lazyLessonService.Value;
        public ICommentService CommentService => _lazyCommentService.Value;
        public IUserService UserService => _lazyUserService.Value;
        public IRoleService RoleService => _lazyRoleService.Value;

        public ICourseService CourseService => _lazyCourseService.Value;

        public readonly Lazy<IExamService> _lazyExamService = new Lazy<IExamService>(() => new ExamService(_unitOfWork, _mapper, _context));
        public IExamService ExamService => _lazyExamService.Value;


    }
}
