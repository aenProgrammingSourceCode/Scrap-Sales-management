using alamapp.Infrastructure.Domain;
using alamapp.Model.Bids;
using alamapp.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
   public class ApplyToBid :EntityBase<int>, IAggregateRoot
    {
       public ApplyToBid()
       {

       }
        public ApplyToBid(Bid bid, Customer customer, decimal price, decimal qty, string msg, string soldDate, bool isSold,string productUnit)
        {
            // TODO: Complete member initialization
            _bid = bid;
            _customer = customer;
            _price = price;
            _qty = qty;
            _msg = msg;
            _soldDate = soldDate;
            _isSold = isSold;
            CreatedDate = DateTime.Now.ToString();
            _productUnit = productUnit;
        }

        private string _productUnit;

        public string ProductUnit
        {
            get { return _productUnit; }
            set { _productUnit = value; }
        }

        public bool ContainCustomer(Customer customer,Bid bid)
        {
            return Customer == customer && Bid==bid;
        }
        
        private string _createdDate;
        public string CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public decimal DifferencePrice 
        { 
           get
           {
               return Bid.Price - Price;
           }
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        private Bid _bid;
        public Bid Bid
        {
            get { return _bid; }
            set { _bid = value; }
        }
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private decimal _qty;
        public decimal Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        private bool _isSold;

        public bool IsSold
        {
            get { return _isSold; }
            set { _isSold = value; }
        }
        private string _soldDate;
        public string SoldDate
        {
            get { return _soldDate; }
            set { _soldDate = value; }
        }
        private string _msg;
      

        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
