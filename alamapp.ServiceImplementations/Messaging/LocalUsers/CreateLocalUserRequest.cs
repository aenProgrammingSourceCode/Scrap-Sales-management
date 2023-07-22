using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.LocalUsers
{
   public class CreateLocalUserRequest
    {
        public int LocalUserId { get; set; }
        public string Email { get; set; }
        public string UserIdentityToken { get; set; }
    }
}
