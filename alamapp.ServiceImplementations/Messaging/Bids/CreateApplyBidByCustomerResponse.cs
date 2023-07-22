using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class CreateApplyBidByCustomerResponse
    {
        public BidView Bid { get; set; }
        public ApplyToBidView ApplyToBid { get; set; }
    }
}
