using alamapp.Model.Bids;
using alamapp.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
   public class ApplyBidFactory
    {
       public static ApplyToBid CreateApplyToBid(Bid bid, Customer customer,
           decimal price, decimal qty, string msg, string soldDate, bool isSold, string productUnit)
       {
           return new ApplyToBid(bid, customer, price, qty, msg, soldDate, isSold,productUnit);
       }
    }
}
