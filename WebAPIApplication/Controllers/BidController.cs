using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Bids;
using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    //[Authorize(Roles="Customer")]
    public class BidController : ApiController
    {
        private readonly IBidService _bidService;
        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        
        [ActionName("Create")]
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Create(CreateBidRequest bidRequest)
        {
            CreateBidRequest request = new CreateBidRequest();
            request.CompanyId = bidRequest.CompanyId;
            request.ProductId = bidRequest.ProductId;
            request.GoodsTypeId = bidRequest.GoodsTypeId;
            request.Qty = bidRequest.Qty;
            request.Price = bidRequest.Price;
            request.UnitId = bidRequest.UnitId;
            request.UserIdentity = bidRequest.UserIdentity;
            CreateBidResponse response= _bidService.CreateBid(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
        [ActionName("Save")]
        [HttpGet]
        [HttpPost]
        public void Save(CreateBidRequest bidRequest)
        {
            CreateBidRequest request = new CreateBidRequest();
            request.CompanyId = bidRequest.CompanyId;
            request.ProductId = bidRequest.ProductId;
            request.GoodsTypeId = bidRequest.GoodsTypeId;
            request.Qty = bidRequest.Qty;
            request.Price = bidRequest.Price;
            request.UnitId = bidRequest.UnitId;
            request.UserIdentity = bidRequest.UserIdentity;
            _bidService.SaveBid(request);
        }


        [HttpGet]
        public HttpResponseMessage GetBidByProductGroup()
        {
            IEnumerable<BidView> response = _bidService.GetBidPerProduct();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        
        [HttpGet]
        public HttpResponseMessage GetBidByGoodsType()
        {
            IEnumerable<BidView> response = _bidService.GetBidPerType();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [ActionName("GetApplyToBidByBidGroup")]
        [HttpGet]
        public HttpResponseMessage GetApplyToBidByBidGroup()
        {
            IEnumerable<BidView> response = _bidService.CountApplyToBidByBid();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }


        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            GetAllBidResponse response = _bidService.GetAllBid();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage GetBidByBid(int id)
        {
            GetBidRequest request = new GetBidRequest() { Id = id };
            GetBidResponse response = _bidService.GetBidByBidId(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }



        [HttpPost]
        public HttpResponseMessage GetBidByProduct(GetBidRequest request)
        {
            GetBidRequest bidRequest = new GetBidRequest();
            bidRequest.ProductId = request.ProductId;
            GetBidResponse response = _bidService.GetBid(bidRequest);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        //[HttpPost]
        //public HttpResponseMessage GetBidByCriteria(GetBidRequestModels bidRequest)
        //{
        //    GetBidRequest request = new GetBidRequest();
        //    request.ProductId = bidRequest.ProductId;
        //    //request.PageSize =6;
        //    //request.Index = bidRequest.Index;
        //    GetBidResponse response = _bidService.GetBid(request);
        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
        //    return httpResponse;
        //}

        [HttpPost]
        public HttpResponseMessage GetBidByGoodsType(GetBidRequestModels bidRequest)
        {
            GetBidRequest request = new GetBidRequest();
            request.GoodsTypeId = bidRequest.GoodsTypeId;
            GetBidResponse response = _bidService.GetBidByGoodsType(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
        [ActionName("GetAppliedBid")]
        [HttpGet]
        public HttpResponseMessage GetAppliedBid(string idToken)
        {
            GetApplyBidByCustomerRequest appliedBidRequest = new GetApplyBidByCustomerRequest() { UserIdentityToken = idToken };
            GetApplyBidByCustomerResponse response = _bidService.GetApplyToBidByCustomer(appliedBidRequest);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
        [ActionName("GetAllBidByUser")]
        [HttpGet]
        public HttpResponseMessage GetAllBidByUser(string userIdentity)
        {
            GetAllBidByCompanyUserRequest bidRequest = new GetAllBidByCompanyUserRequest() { UserIdentityToken=userIdentity};
            GetAllBidByCompanyUserResponse response = _bidService.GetAllBidByUserOfCompany(bidRequest);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }


        [Route("Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(int id)
        {
            ModifyBidRequest request = new ModifyBidRequest();
            request.Id = id;
            ModifyBidResponse response = _bidService.ModifyBid(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [Route("Delete")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            DeleteBidRequest request = new DeleteBidRequest();
            request.Id = id;
            DeleteBidResponse response = _bidService.DeleteBid(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpPost]
        public HttpResponseMessage CreateApplyToBid(CreateApplyBidByCustomerRequest request)
        {
            CreateApplyBidByCustomerRequest bidApplyRequest = new CreateApplyBidByCustomerRequest();
            bidApplyRequest.BidId = request.BidId;
            bidApplyRequest.Price = request.Price;
            bidApplyRequest.Quantity = request.Quantity;
            bidApplyRequest.customerForBid.Add(request.UserIdentityToken);
            bidApplyRequest.Msg = request.Msg;
            request.SoldDate = DateTime.Now.ToString();
            request.IsSold = false;
            bidApplyRequest.ProductUnit = request.ProductUnit;
            CreateApplyBidByCustomerResponse response= _bidService.ApplyBidByCustomer(request);

            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
            
        }

        [ActionName("GetAllAppliedBidList")]
        [HttpGet]
        public HttpResponseMessage GetAllAppliedBidList(int bidId)
        {
            GetApplyBidByCustomerRequest AppliedBidRequest = new GetApplyBidByCustomerRequest() { BidId=bidId };
            GetApplyBidByCustomerResponse response = _bidService.GetApplyToBidByCompany(AppliedBidRequest);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [ActionName("GetSoldItemForCustomer")]
        [HttpGet]
        public HttpResponseMessage GetSoldItemForCustomer(GetAppliedBidSoldItemRequest request)
        {
            GetAppliedBidSoldItemRequest SoldItemRequest = new GetAppliedBidSoldItemRequest();
            SoldItemRequest.IsSold = true;
            GetAppliedBidSoldItemResponse response = _bidService.GetSoldItemByCustomer(SoldItemRequest);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [ActionName("ModifyAppliedBidByCompany")]
        [HttpPost]
        public void ModifyAppliedBidByCompany(ModifyAppliedBidRequest request,int id)
        {
            ModifyAppliedBidRequest appliedBidRequest = new ModifyAppliedBidRequest() { Id=id};
            appliedBidRequest.IsSold = true;
            appliedBidRequest.Msg = request.Msg;
            _bidService.ModifyApplyToBidByCompany(appliedBidRequest);
        }

        [ActionName("WinBidForCustomer")]
        [HttpGet]
        public HttpResponseMessage WinBidForCustomer(string idToken)
        {
            GetSoldItemForCustomerRequest soldBidRequest = new GetSoldItemForCustomerRequest() { IdentityToken = idToken };
            GetSoldItemForCustomerResponse response = _bidService.GetSoldItemForCustomer(soldBidRequest);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
    }
}
