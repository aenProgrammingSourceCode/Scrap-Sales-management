using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
   public class LocalUser:EntityBase<int>, IAggregateRoot
    {
       public LocalUser()
       {
           CreatedDate = DateTime.Now;
       }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string UserIdentityToken { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }

       
    }
}
