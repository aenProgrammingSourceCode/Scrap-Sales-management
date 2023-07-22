using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Company
{
   public class GetCompanyRequest
    {
        public int Id { get; set; }
        public string UserIdentityToken { get; set; }
    }
}
