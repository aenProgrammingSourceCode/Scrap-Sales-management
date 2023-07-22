using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Customers;
using alamapp.Model.RepositoryInterface.Auth;
using alamapp.Model.RepositoryInterface.Customers;
using alamapp.Model.UserAuthentication;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Mapping;
using alamapp.ServiceImplementations.Messaging.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class CustomerService:ICustomerService
    {
       private ICustomerRepository _customerRepository;
       private readonly IAspUserRepository _aspUserRepository;
       private IUnitOfWork _uow;
       public CustomerService(ICustomerRepository customerRepository, IAspUserRepository aspUserRepository,
           IUnitOfWork uow)
       {
           _uow = uow;
           _aspUserRepository = aspUserRepository;
           _customerRepository = customerRepository;
       }
        public CreateCustomerResponse CreateCustomer(CreateCustomerRequest request)
        {
            CreateCustomerResponse response = new CreateCustomerResponse();
            AspUser aspUser =_aspUserRepository.FindBy(request.CustomerIdentityToken);
            Customer customer = new Customer();
            customer.AspUser = aspUser;
            customer.Name = request.Name;
            customer.MobileNo = request.MobileNo;
            customer.Address = request.Address;
            response.Customer = customer.ConvertToCustomerView();
            _customerRepository.Add(customer);

            _uow.Commit();
            return response;
        }

        public ModifyCustomerResponse ModifyCompany(ModifyCustomerRequest request)
        {
            ModifyCustomerResponse response = new ModifyCustomerResponse();
            return response;
        }

        public DeleteCustomerResponse DeleteCompany(DeleteCustomerRequest request)
        {
            DeleteCustomerResponse response = new DeleteCustomerResponse();
            return response;
        }

        public GetAllCustomerResponse GetAllCustomer()
        {
            GetAllCustomerResponse response = new GetAllCustomerResponse();
            return response;
        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            GetCustomerResponse response = new GetCustomerResponse();

            Customer customer = _customerRepository.FindBy(request.CustomerUserIdentity);
           
            response.Customer = customer.ConvertToCustomerView();
            return response;
        }


        public CreateCustomerResponseForBidResponse CreateCustomerResponseForBid(CreateCustomerResponseForBidRequest request)
        {
           CreateCustomerResponseForBidResponse response = new CreateCustomerResponseForBidResponse();
           return response;
        }

        public ModifyCustomerResponseForBidResponse CreateCustomerResponseForBid(ModifyCustomerResponseForBidRequest request)
        {
            ModifyCustomerResponseForBidResponse response = new ModifyCustomerResponseForBidResponse();
            return response;
        }

        public DeleteCustomerResponseForBidResponse CreateCustomerResponseForBid(DeleteCustomerResponseForBidRequest request)
        {
            DeleteCustomerResponseForBidResponse response = new DeleteCustomerResponseForBidResponse();
            return response;
        }

        public GetAllCustomerResponseForBidResponse response()
        {
            GetAllCustomerResponseForBidResponse response = new GetAllCustomerResponseForBidResponse();
            return response;
        }
    }
}
