using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel
{
   public class ApplyToBidView
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobileNo { get; set; }
        public string CustomerCreateDate { get; set; }
        public string CustomerAddress { get; set; }
        public string BidCompanyName { get; set; }
        public string BidId { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public decimal BidPrice { get; set; }
        public string BidProductName { get; set; }
        public string BidCreatedDate { get; set; }
        public string CreatedDate { get; set; }
        public decimal BidQty { get; set; }
        public decimal DifferencePrice { get; set; }
        public string Msg { get; set; }
        public string SoldDate { get; set; }
        public int TotalAppliedBidByCustomer { get; set; }
    }
}
