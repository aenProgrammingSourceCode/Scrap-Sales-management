using alamapp.ServiceImplementations.Messaging.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface ICompanyService
    {
       CreateCompanyResponse CreateCompany(CreateCompanyRequest request);
       void SaveCompany(CreateCompanyRequest request);
       GetCompanyResponse GetCompany(GetCompanyRequest request);
       ModifyCompanyResponse ModifyCompany(ModifyCompanyRequest request);
       DeleteCompanyResponse DeleteCompany(DeleteCompanyRequest request);
       GetAllCompanyResponse GetAllCompany();
    }
}
