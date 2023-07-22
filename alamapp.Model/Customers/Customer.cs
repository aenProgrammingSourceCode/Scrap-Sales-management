using alamapp.Infrastructure.Domain;
using alamapp.Model.UserAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Customers
{
   public class Customer:EntityBase<int>, IAggregateRoot
    {
        public Customer()
        {
           CreateDate = DateTime.Now.ToString();
        }
        public string Name { get; set; }
        public string CreateDate { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        private AspUser _aspUser;
        public AspUser AspUser
        {
            get { return _aspUser; }
            set { _aspUser = value; }
        }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }

       
    }
}
