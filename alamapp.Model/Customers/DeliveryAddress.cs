using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Customers
{
   public class DeliveryAddress:EntityBase<int>
    {
       private Customer _customer;
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Relation { get; set; }
      
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
