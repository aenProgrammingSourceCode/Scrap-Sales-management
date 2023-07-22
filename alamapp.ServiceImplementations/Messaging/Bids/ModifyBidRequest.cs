using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Bids
{
   public class ModifyBidRequest
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int GoodsTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public decimal Amount { get; set; }
        public string UnitId { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string TypeId { get; set; }
    }
}
