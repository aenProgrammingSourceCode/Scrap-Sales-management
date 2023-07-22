using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class GetAppliedBidSoldItemRequest
    {
        public int Id { get; set; }
        public bool IsSold { get; set; }
        public string Msg { get; set; }
    }
}
