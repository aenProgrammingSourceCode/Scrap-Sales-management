using alamapp.ServiceImplementations.ViewModel.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Customer
{
   public class GetAllCustomerResponse
    {
       public IEnumerable<CustomerView> Customers { get; set; }
    }
}
