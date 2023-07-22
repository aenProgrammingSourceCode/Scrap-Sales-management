using alamapp.Model.Customers;
using alamapp.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class CustomerResponseBidMapping
    {
       public static CustomerResponseForBidView ConvertToCustomerResponseForBidView(this CustomerResponseForBid customerResponseForBid)
        {
            return Mapper.Map<CustomerResponseForBid, CustomerResponseForBidView>(customerResponseForBid);
        }

       public static IEnumerable<CustomerResponseForBidView> ConvertToCustomerResponseForBidViews(this IEnumerable<CustomerResponseForBid> customerResponseForBids)
       {
           return Mapper.Map<IEnumerable<CustomerResponseForBid>, IEnumerable<CustomerResponseForBidView>>(customerResponseForBids);
       }
        
    }
}
