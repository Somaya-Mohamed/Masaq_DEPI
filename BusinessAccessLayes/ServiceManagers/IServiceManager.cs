using BusinessAccessLayes.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.ServiceManagers
{
    public interface IServiceManager
    {
<<<<<<< HEAD
        public ILessonService LessontService { get; }

        public IAuthenticationService AuthenticationService { get; }
=======
        public ILessonService LessonService { get; }

        public IAnncouncementService AnnouncementService { get; }
        public ICommentService CommentService { get; }
        // --- ده الكود المدمج ---
        //public IAuthenticationService AuthenticationService { get; }

>>>>>>> TasneemWork
    }
}
