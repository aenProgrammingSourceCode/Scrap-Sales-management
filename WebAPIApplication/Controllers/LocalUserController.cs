using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.LocalUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web;
using WebAPIApplication.Models;
using alamapp.ServiceImplementations.Messaging.Authentications;
using alamapp.Model.UserAuthentication;


namespace WebAPIApplication.Controllers
{
    public class LocalUserController : ApiController
    {
        private readonly IAspAuthenticationService _aspAuthenticationService;
        private readonly ILocalUserService _localUserService;
        public LocalUserController(ILocalUserService localUserService,IAspAuthenticationService aspAuthenticationService)
        {
            _aspAuthenticationService = aspAuthenticationService;
            _localUserService = localUserService;
        }

        [HttpPost]
        public void Post(LocalUserViewModels localuserVm)
        {
            if (ModelState.IsValid)
            {
                CreateLocalUserRequest request = new CreateLocalUserRequest();
                request.UserIdentityToken = localuserVm.UserIdentityToken;
                request.Email = localuserVm.Email;
                _localUserService.CreateLocalUser(request);
            }
        }

        [HttpGet]
        public string GetUserToken(string userIdentity)
        {
            GetLocalUserRequest request = new GetLocalUserRequest();
            request.UserIdentityToken = userIdentity;
            GetLocalUserResponse response = _localUserService.GetLocalUser(request);
            return response.LocalUser.UserIdentityToken;
        }

        [HttpGet]
        public HttpResponseMessage GetAllRoles()
        {
            GetAllAspRoleResponse response = _aspAuthenticationService.GetAllAspRole();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage GetRole(string roleId)
        {
            GetAspRoleRequest request=new GetAspRoleRequest();
            request.RoleId = roleId;
            GetAspRoleResponse response = _aspAuthenticationService.GetRole(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage GetUserRole(string userId)
        {
            GetAspUserRoleRequest request = new GetAspUserRoleRequest();
            request.UserId = userId;
            GetAspUserRoleResponse response = _aspAuthenticationService.GetUserRole(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        

        [ActionName("Edit")]
        [HttpPost]
        public void Edit(string userId, AspUserRoleViewModels aspUserRoleViewModels)
        {
            ModifyAspUserRoleRequest request = new ModifyAspUserRoleRequest() { UserId=userId};
            request.RoleId =aspUserRoleViewModels.RoleId ;
            _aspAuthenticationService.ModifyRoleByUser(request);
        }
    }
}
