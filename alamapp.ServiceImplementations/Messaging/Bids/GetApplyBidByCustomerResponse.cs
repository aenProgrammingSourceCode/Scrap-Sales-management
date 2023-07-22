using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class GetApplyBidByCustomerResponse
    {
        public ApplyToBidView ApplyToBid { get; set; }
        public IEnumerable<ApplyToBidView> ApplyToBids { get; set; }
    }
}
