using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Authentication
{
    public class UserResponce
    {
        public string UserName { get; set; }
        public string phonenumber { get; set; }
        public string Token { get; set; }
    }
}
