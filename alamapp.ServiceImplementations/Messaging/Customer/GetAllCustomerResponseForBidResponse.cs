using alamapp.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Customer
{
   public class GetAllCustomerResponseForBidResponse
    {
        public IEnumerable<CustomerResponseForBid> CustomerResponseForBid { get; set; }
    }
}
