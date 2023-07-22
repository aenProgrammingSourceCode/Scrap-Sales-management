using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class CreateApplyBidByCustomerRequest
    {
       public CreateApplyBidByCustomerRequest()
       {
           customerForBid = new List<string>();
       }
        public int CustomerId { get; set; }
        public int BidId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string UserIdentityToken { get; set; }
        public string SoldDate { get; set; }
        public bool IsSold { get; set; }
        public string Msg { get; set; }
        public int AppliedBidId { get; set; }
        public string ProductUnit { get; set; }
        public IList<string> customerForBid { get; set; }
    }
}
