using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class GetBidResponse
    {
        public BidView Bid { get; set; }
        public IEnumerable<BidView> Bids { get; set; }
        public int TotalBids { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPages { get; set; }
        public int TotalProductByGroup { get; set; }
    }
}
