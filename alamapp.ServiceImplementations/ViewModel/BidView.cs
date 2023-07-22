using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel
{
   public class BidView
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int GoodsTypeId { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string CreatedDate { get; set; }
        public string GoodsTypeName { get; set; }
        public decimal Amount { get; set; }
        public string ProductUnit { get; set; }
        public decimal Qty { get; set; }
        public int ProductId { get; set; }
        public int TotalBidByProduct { get; set; }
        public int TotalBidByGoodsType { get; set; }
        public int BidByProductGroup { get; set; }
        public string AspNetUserId { get; set; }
        public int TotalAppliedCustomer { get; set; }
        public IEnumerable<ApplyToBidView> ApplyToBids { get; set; }
        public int TotalApply { get; set; }
        public string PriceCurrency
        {
            get { return Price.ToString("C", CultureInfo.CreateSpecificCulture("bn-BD")); }
        }
        public string AmountCurrency
        {
            get { return Amount.ToString("C2", CultureInfo.CreateSpecificCulture("bn-BD")); }
        }

       public string QtyDecimal
        {
            get { return String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Qty); }
        }
       public int CountSold { get; set; }
       public string BalanceQty { get; set; }

       //public string BalanceBidQty
       //{
       //    get { return String.Format(CultureInfo.InvariantCulture, "{0:0,0}", BalanceQty); }
       //}
       public string NetQuantity { get; set; }
       //public string NetBidQuantity 
       //{
       //    get { return String.Format(CultureInfo.InvariantCulture, "{0:0,0}", NetQuantity); }
       //}
      
    }
}
