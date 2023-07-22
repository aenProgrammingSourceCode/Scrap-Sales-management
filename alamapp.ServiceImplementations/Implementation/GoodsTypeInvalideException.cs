using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class GoodsTypeInvalideException:Exception
    {
       public GoodsTypeInvalideException(string message):base(message)
       {

       }
    }
}
