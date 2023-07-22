using alamapp.Model.Baskets;
using alamapp.Model.Orders;
using alamapp.Model.RepositoryInterface.Baskets;
using alamapp.Model.RepositoryInterface.Orders;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Orders;
using alamapp.ServiceImplementations.ViewModel.Orders;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.Infrastructure.UnitOfWorks;
using System.Web;

namespace alamapp.ServiceImplementations.Implementation
{
   public class OrderService:IOrderService
    {
       private IBasketRepository _basketRepository;
       private IOrderRepository _orderRepository;
       private IUnitOfWork _uow;
       public OrderService(IBasketRepository basketRepository, IOrderRepository orderRepository, IUnitOfWork uow)
       {
           _basketRepository = basketRepository;
           _orderRepository = orderRepository;
           _uow = uow;
       }
        public CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            Basket basket = _basketRepository.FindBy(request.BasketId);
            Order order = basket.ConvertToOrder(request);
            
            _orderRepository.Add(order);
            _basketRepository.Delete(basket);
            _uow.Commit();

            response.Order = order.ConvertToOrderView();
            return response;
             
        }


        public GetOrdersByTokenResponse GetOrderByToken(GetOrdersByTokenRequest request)
        {
            GetOrdersByTokenResponse response = new GetOrdersByTokenResponse();
            Order order = _orderRepository.FindBy(request.IdentityToken);
            response.Order = order.ConvertToOrderView();
            return response;
        }
    }
}
