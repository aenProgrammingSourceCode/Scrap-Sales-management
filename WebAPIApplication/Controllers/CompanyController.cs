using alamapp.Model.RepositoryInterface;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;
using Microsoft.AspNet.Identity;
using alamapp.ServiceImplementations.Messaging.LocalUsers;

namespace WebAPIApplication.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ILocalUserService _localUserService;
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService,
            ILocalUserService localUserService)
        {
            _localUserService = localUserService;
            _companyService = companyService;
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateCompanyRequest companyVm)
        {
            CreateCompanyRequest request = new CreateCompanyRequest();
            request.Name = companyVm.Name;
            request.AdminUserName = companyVm.AdminUserName;
            request.AdminUserPosition = companyVm.AdminUserPosition;
            request.UserIdentity = companyVm.UserIdentity;
            CreateCompanyResponse response= _companyService.CreateCompany(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [ActionName("Save")]
        [HttpPost]
        public void Save(CreateCompanyRequest companyVm)
        {
            CreateCompanyRequest request = new CreateCompanyRequest();
            request.Name = companyVm.Name;
            request.AdminUserName = companyVm.AdminUserName;
            request.AdminUserPosition = companyVm.AdminUserPosition;
            request.UserIdentity = companyVm.UserIdentity;
            _companyService.SaveCompany(request);
        }
        
      
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            GetAllCompanyResponse response = _companyService.GetAllCompany();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        
        [HttpGet]
        public HttpResponseMessage Get(string userIdentityToken)
        {
            GetCompanyRequest comRequest = new GetCompanyRequest() { UserIdentityToken = userIdentityToken };
            GetCompanyResponse response = _companyService.GetCompany(comRequest);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
    }
}
