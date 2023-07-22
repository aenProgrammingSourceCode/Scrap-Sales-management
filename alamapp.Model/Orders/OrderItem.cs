using alamapp.Infrastructure.Domain;
using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Orders
{
   public class OrderItem:EntityBase<int>
    {
        private decimal _price;
        private int _qty;
        private Product _product;
        private Order _order;
        public OrderItem()
        {

        }
        public OrderItem(Orders.Order order, Products.Product product, int qty)
        {
            // TODO: Complete member initialization
            _order = order;
            _product = product;
            _qty = qty;
        }

       
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public bool Contains(Product product)
        {
            return Product == product;
        }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }

      
    }
}
