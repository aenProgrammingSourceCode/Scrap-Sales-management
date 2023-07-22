using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIApplication.Controllers
{
    public class GoodsTypeController : ApiController
    {
        private readonly IGoodsTypeService _goodsTypeService;
        public GoodsTypeController(IGoodsTypeService goodsTypeService)
        {
            _goodsTypeService = goodsTypeService;
        }

        [HttpPost]
        public HttpResponseMessage Post(CreateGoodsTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            CreateGoodsTypeRequest goodsTypeRequest=new CreateGoodsTypeRequest();
            goodsTypeRequest.Name = request.Name;
            CreateGoodsTypeResponse response = _goodsTypeService.CreateGoodsType(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage GetAll(CreateGoodsTypeRequest request)
        {
            GetAllGoodsTypeResponse response = _goodsTypeService.GetAllGoodsType();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
    }
}
