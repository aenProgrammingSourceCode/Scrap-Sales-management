using alamapp.Infrastructure.Domain;
using alamapp.Model.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Customers
{
    public class CustomerResponseForBid : EntityBase<int>, IAggregateRoot
   {
       public CustomerResponseForBid()
        {
           CreatedDate = DateTime.Now;
        }
        public DateTime CreatedDate { get; set; }
        private Bid _bid;
        public Bid Bid
        {
            get { return _bid; }
            set { _bid = value; }
        }
        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        public bool IsSold { get; set; }
        public decimal ProposedPrice { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
