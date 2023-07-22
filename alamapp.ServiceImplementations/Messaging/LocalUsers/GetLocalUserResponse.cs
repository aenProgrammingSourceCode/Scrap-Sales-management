using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.LocalUsers
{
   public class GetLocalUserResponse
    {
        public LocalUserView LocalUser { get; set; }

        public IEnumerable<LocalUserView> LocalUsers { get; set; }
    }
}
