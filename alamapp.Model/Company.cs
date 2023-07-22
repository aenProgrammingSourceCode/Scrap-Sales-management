using alamapp.Infrastructure.Domain;
using alamapp.Model.Bids;
using alamapp.Model.UserAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
    public class Company : EntityBase<int>, IAggregateRoot
    {
        public Company()
        {
            CreateDate = DateTime.Now.ToString();
        }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        public string CreateDate { get; set; }
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
