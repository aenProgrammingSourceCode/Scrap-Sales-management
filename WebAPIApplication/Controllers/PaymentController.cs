using alamapp.Infrastructure.CookieStorage;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;
using Microsoft.AspNet.Identity;
using System.Web;

namespace WebAPIApplication.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly ICookieStorageService _cookieStorageService;
        public PaymentController(IPaymentService paymentService,
            ICookieStorageService cookieStorageService)
        {
            _cookieStorageService = cookieStorageService;
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("PostPayment")]
        public void PostPayment(string UserId)
        {
            CreatePaymentRequest createRequest = new CreatePaymentRequest();
            createRequest.PaymentId = RequestContext.Principal.Identity.GetUserId();
            createRequest.Amount = 4800;
            createRequest.CompanyToAdd.Add(2);
            _paymentService.CreatePayment(createRequest);
            
            //else
            //{
            //ModifyPaymentRequest modifyRequest = new ModifyPaymentRequest();
            //modifyRequest.PaymentId = User.Identity.GetUserId();
            //modifyRequest.CompanyToAdd.Add(2);
            //modifyRequest.Amount = 47800;
            //_paymentService.ModifyPayment(modifyRequest);
            //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, modifyResponse);
            //}
        }
         
        [HttpGet]
        public HttpResponseMessage GetAllPaymentList()
        {
            GetAllPaymentResponse response = _paymentService.GetAllPayments();
            HttpResponseMessage httpReponse = Request.CreateResponse(HttpStatusCode.OK, response.Payments);
            return httpReponse;
        }


        public Guid GetPaymentId()
        {
            string sPaymentId = _cookieStorageService.Retrieve(RequestContext.Principal.Identity.GetUserId());
            Guid paymentId = Guid.Empty;

            if (!string.IsNullOrEmpty(sPaymentId))
            {
                paymentId = new Guid(sPaymentId);
            }

            return paymentId;
        }

        public void SavePaymentIdCookie(Guid paymentId)
        {
            _cookieStorageService.Save(CookieDataKey.PaymentId.ToString(), paymentId.ToString(),DateTime.Today);
        }
    }
}
