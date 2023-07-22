using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Company
{
   public class GetAllCompanyResponse
    {
       public CompanyView Company { get; set; }
       public IEnumerable<CompanyView> Companies { get; set; }
    }
}
