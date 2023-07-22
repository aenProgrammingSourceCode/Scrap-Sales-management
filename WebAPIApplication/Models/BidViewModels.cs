using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class BidViewModels
    {
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
    }
}