using alamapp.Infrastructure.Domain;
using alamapp.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
   public class Block:EntityBase<int>,IAggregateRoot
    {
       private string _blockMethod;
       public string BlockMethod
       {
           get { return _blockMethod; }
           set { _blockMethod = value; }
       }
       
       protected override void Validate()
       {
           throw new NotImplementedException();
       }
    }
}
