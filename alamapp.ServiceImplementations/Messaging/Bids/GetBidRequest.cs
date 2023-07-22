using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class GetBidRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public int GoodsTypeId { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
}
