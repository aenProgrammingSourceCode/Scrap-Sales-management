using alamapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class GetAllAppliedBidResponse
    {
        public IEnumerable<ApplyToBid> ApplyToBids { get; set; }
    }
}
