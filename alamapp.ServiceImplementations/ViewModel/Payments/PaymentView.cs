using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Payments
{
   public class PaymentView
    {
       public string Id { get; set; }
       public DateTime PaymentDate { get; set; }
       public PaymentView()
       {
           Transactions = new List<TransactionView>();
       }
      
        public IEnumerable<TransactionView> Transactions { get; set; }
    }
}
