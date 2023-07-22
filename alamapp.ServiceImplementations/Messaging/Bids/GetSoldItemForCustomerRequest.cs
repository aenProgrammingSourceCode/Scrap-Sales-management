using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class GetSoldItemForCustomerRequest
    {
        public int Id { get; set; }
        public string IdentityToken { get; set; }
    }
}
