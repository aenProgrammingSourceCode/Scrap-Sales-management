using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [ActionName("CreateCustomer")]
        [HttpPost]
        public HttpResponseMessage CreateCustomer(CreateCustomerRequest customerModel)
        {
           CreateCustomerRequest customerRequest = new CreateCustomerRequest();
           customerRequest.CustomerIdentityToken = customerModel.CustomerIdentityToken;
           customerRequest.Name = customerModel.Name;
           customerRequest.MobileNo = customerModel.MobileNo;
           customerRequest.Address = customerModel.Address;
           CreateCustomerResponse response= _customerService.CreateCustomer(customerRequest);

           HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Customer.Name);
           return httpResponse;
        }
      
        [ActionName("Get")]
        [HttpGet]
        public HttpResponseMessage Get(string userIdentity)
        {
            GetCustomerRequest request = new GetCustomerRequest() { CustomerUserIdentity=userIdentity };
            GetCustomerResponse response = _customerService.GetCustomer(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
    }
}
