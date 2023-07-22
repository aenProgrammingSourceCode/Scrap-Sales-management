using alamapp.ServiceImplementations.Messaging.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface IOrderService
    {
       CreateOrderResponse CreateOrder(CreateOrderRequest request);
       GetOrdersByTokenResponse GetOrderByToken(GetOrdersByTokenRequest request);
    }
}
