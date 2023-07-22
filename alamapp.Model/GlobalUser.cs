using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
   public class GlobalUser:EntityBase<string>,IAggregateRoot
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
