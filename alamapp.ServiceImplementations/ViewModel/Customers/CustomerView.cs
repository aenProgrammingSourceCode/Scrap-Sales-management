using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Customers
{
   public class CustomerView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityToken { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string CreateDate { get; set; }
    }
}
