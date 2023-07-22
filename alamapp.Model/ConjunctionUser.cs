using alamapp.Infrastructure.Domain;
using alamapp.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
   public class ConjunctionUser:EntityBase<int>,IAggregateRoot
    {
        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { _company = value; }
        }
        private int _block;
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
