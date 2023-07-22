using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Payments
{
   public class ModifyPaymentRequest
    {
       public ModifyPaymentRequest()
       {
           CompanyToAdd = new List<int>();
       }
        public string PaymentId { get; set; }
        public int CompanyId { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public IList<int> CompanyToAdd { get; set; }
    }
}
