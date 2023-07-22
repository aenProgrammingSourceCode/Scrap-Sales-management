using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.LocalUsers
{
   public class GetLocalUserRequest
    {
        public string UserIdentityToken { get; set; }
        public int IsBlock { get; set; }
    }
}
