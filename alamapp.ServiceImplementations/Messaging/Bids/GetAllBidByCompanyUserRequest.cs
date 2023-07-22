using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class GetAllBidByCompanyUserRequest
    {
        public string UserIdentityToken { get; set; }
        public int CompanyId { get; set; }
    }
}
