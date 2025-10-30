using AutoMapper;
using BusinessAccessLayes.Services.Classes;
using BusinessAccessLayes.Services.Interfaces;

using DataAccessLayer.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.ServiceManagers
{
    public class ServiceManager(IUnitOfWork _unitOfWork,IMapper _mapper) : IServiceManager
    {
        private readonly Lazy<ILessonService> _lazyLessonService = new Lazy<ILessonService>(() => new LessonService(_unitOfWork, _mapper));
        private readonly Lazy<IAnncouncementService> _lazyAnnouncementService = new Lazy<IAnncouncementService>(() => new AnnouncementService(_unitOfWork, _mapper));
        private readonly Lazy<ICommentService> _lazyCommentService = new Lazy<ICommentService>(() => new CommentService(_unitOfWork, _mapper));
        public ILessonService LessonService => _lazyLessonService.Value;
        public IAnncouncementService AnnouncementService => _lazyAnnouncementService.Value;
        public ICommentService CommentService => _lazyCommentService.Value;

    
    }
}
