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
        public ILessonService LessontService => _lazyLessonService.Value;
    }
}
