using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class GetBidRequestModels
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int GoodsTypeId { get; set; }
        public int CompanyId { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
}