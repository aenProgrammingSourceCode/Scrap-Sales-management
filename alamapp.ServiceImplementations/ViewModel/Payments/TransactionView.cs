using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Payments
{
   public class TransactionView
    {
        public int TransactionId { get; set; }
        public int Balance { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
