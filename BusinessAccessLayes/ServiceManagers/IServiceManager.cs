using BusinessAccessLayes.Services.Interfaces;

namespace BusinessAccessLayes.ServiceManagers
{
    public interface IServiceManager
    {
        public ILessonService LessonService { get; }
        public IAnncouncementService AnnouncementService { get; }
        public ICommentService CommentService { get; }
        public BusinessAccessLayes.Services.Interfaces.IAuthenticationService AuthenticationService { get; }
        public IUserService UserService { get; }
        public IRoleService RoleService { get; }
        ICourseService CourseService { get; }
        public IExamService ExamService { get; }

        public IEnrollmentService EnrollmentService { get; }

    }
}



