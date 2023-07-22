﻿using alamapp.Infrastructure.CookieStorage;
using alamapp.ServiceImplementations.ViewModel.Baskets;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace WebAPIApplication.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly ICookieStorageService _cookieStorageService;
        public BaseApiController(ICookieStorageService cookieStorageService)
        {
            _cookieStorageService = cookieStorageService;
        }


        public BasketSummaryView GetBasketSummary()
        {
            string basketTotal = "";
            int numberOfItems = 0;
            if (!string.IsNullOrEmpty(_cookieStorageService.Retrieve(CookieDataKey.BasketTotal.ToString())))
                basketTotal = _cookieStorageService.Retrieve(CookieDataKey.BasketTotal.ToString());
            

            if(!string.IsNullOrEmpty(_cookieStorageService.Retrieve(CookieDataKey.NumberOfItem.ToString())))
                numberOfItems =int.Parse(_cookieStorageService.Retrieve(CookieDataKey.NumberOfItem.ToString()));
            

            return new BasketSummaryView()
            {
                 BasketTotal = basketTotal,
                 NumberOfItems = numberOfItems
            };

        }
        public Guid GetBasketId()
        {
            string sBasketId = _cookieStorageService
                                      .Retrieve(CookieDataKey.BasketId.ToString());
            Guid basketId = Guid.Empty;

            if (!string.IsNullOrEmpty(sBasketId))
            {
                basketId = new Guid(sBasketId);
            }

            return basketId;
        }
    }
}
