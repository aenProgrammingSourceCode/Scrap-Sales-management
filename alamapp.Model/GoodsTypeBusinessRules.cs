using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
   public class GoodsTypeBusinessRules
    {
       public static readonly BusinessRule GoodTypeRequired =
          new BusinessRule("Name", "Goods type must be related to a Name.");
    }
}
