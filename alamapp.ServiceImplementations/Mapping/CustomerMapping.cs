using alamapp.Model.Customers;
using alamapp.ServiceImplementations.ViewModel.Customers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class CustomerMapping
    {
       public static CustomerView ConvertToCustomerView(this Customer customer)
       {
           return Mapper.Map<Customer, CustomerView>(customer);
       }

       public static IEnumerable<CustomerView> ConvertToCustomerViews(this IEnumerable<Customer> customers)
       {
           return Mapper.Map <IEnumerable<Customer>, IEnumerable<CustomerView>>(customers);
       }
    }
}
