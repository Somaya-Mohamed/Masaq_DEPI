using BusinessAccessLayes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.ServiceManagers
{
    public interface IServiceManager
    {
        public ILessonService LessonService { get; }
        public IAnncouncementService AnnouncementService { get; }
        public ICommentService CommentService { get; }  
    }
}
