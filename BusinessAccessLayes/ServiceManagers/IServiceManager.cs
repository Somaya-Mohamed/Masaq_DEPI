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
        public ILessonService LessontService { get; }
    }
}
