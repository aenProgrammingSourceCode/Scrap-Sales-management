using alamapp.Infrastructure.CookieStorage;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
//using Microsoft.Reporting.WebForms;
using Microsoft.AspNet.Identity;

namespace WebAPIApplication.Controllers
{
    public class OrderController : BaseApiController
    {
        private IOrderService _orderService;
        private ICookieStorageService _cookieStorageService;
        public string UserId { get; set; }
        public OrderController(IOrderService orderService, ICookieStorageService cookieStorageService)
               : base(cookieStorageService)
        {
            _orderService = orderService;
            _cookieStorageService = cookieStorageService;
        }


        [HttpPost]
        public HttpResponseMessage PlaceOrder(string userName)
        {
            CreateOrderRequest request = new CreateOrderRequest();
            request.IdentityToken ="aldkfjlksjlasdkfj";
            request.BasketId = base.GetBasketId();
            request.UserName = userName;
            CreateOrderResponse response = _orderService.CreateOrder(request); 
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Order.Id);

            _cookieStorageService.Save("BasketId","BasketId", DateTime.Now);
             _cookieStorageService.Save("NumberOfItem","NumberOfItem", DateTime.Now);
            _cookieStorageService.Save("BasketTotal","BasketTotal", DateTime.Now);

            return httpResponse;
         
        }

        //[HttpGet]
        //public HttpResponseMessage GetOrderByIdentityToken(string UserName)
        //{
        //    GetOrdersByTokenRequest orderRequest = new GetOrdersByTokenRequest() { IdentityToken=Convert.ToInt32(UserName)};
        //    GetOrdersByTokenResponse response = _orderService.GetOrderByToken(orderRequest);
        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
        //    return httpResponse;
        //}
    }
}
