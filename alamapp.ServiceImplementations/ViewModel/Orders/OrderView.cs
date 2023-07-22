using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Orders
{
   public class OrderView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<OrderItemView> OrderItemViews { get; set; }
    }
}
