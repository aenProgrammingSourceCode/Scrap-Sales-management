using alamapp.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel
{
   public class CustomerResponseForBidView
    {
        public DateTime CreatedDate { get; set; }
        public string BidCode { get; set; }
        public decimal BidPrice { get; set; }
        public decimal Amount { get; set; }
        public string UnitName { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public decimal ProposedPrice { get; set; }
        public bool IsSold { get; set; }
    }
}
