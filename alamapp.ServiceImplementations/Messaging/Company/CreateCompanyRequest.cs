using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Company
{
   public class CreateCompanyRequest
    {
        public string Name { get; set; }
        public string AdminUserName { get; set; }
        public string AdminUserPosition { get; set; }
        public string Email { get; set; }
        public string UserIdentity { get; set; }
    }
}
