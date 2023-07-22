using alamapp.ServiceImplementations.ViewModel.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Customer
{
   public class CreateCustomerRequest
    {
       public string CustomerIdentityToken { get; set; }
       public string Name { get; set; }
       public string MobileNo { get; set; }
       public string Address { get; set; }
    }
}
