using alamapp.ServiceImplementations.Messaging.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface ICustomerService
    {
       CreateCustomerResponse CreateCustomer(CreateCustomerRequest request);
       ModifyCustomerResponse ModifyCompany(ModifyCustomerRequest request);
       DeleteCustomerResponse DeleteCompany(DeleteCustomerRequest request);
       GetAllCustomerResponse GetAllCustomer();
       GetCustomerResponse GetCustomer(GetCustomerRequest request);

       CreateCustomerResponseForBidResponse CreateCustomerResponseForBid(CreateCustomerResponseForBidRequest request);
       ModifyCustomerResponseForBidResponse CreateCustomerResponseForBid(ModifyCustomerResponseForBidRequest request);
       DeleteCustomerResponseForBidResponse CreateCustomerResponseForBid(DeleteCustomerResponseForBidRequest request);
       GetAllCustomerResponseForBidResponse response();
       

    }
}
