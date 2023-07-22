using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class GetApplyBidByCustomerRequest
    {
        public int BidId { get; set; }
        public int ApplyId { get; set; }
        public string UserIdentityToken { get; set; }
    }
}
