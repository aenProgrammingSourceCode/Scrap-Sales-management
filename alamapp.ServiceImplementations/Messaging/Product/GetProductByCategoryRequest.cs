using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class GetProductByCategoryRequest
    {
       public GetProductByCategoryRequest()
       {
           BrandId = 0;
           ManufactureId = 0;
           ProductModelId = 0;
       }
       public int BrandId { get; set; }
       public int ManufactureId { get; set; }
       public int ProductModelId { get; set; }
       public int CategoryId { get; set; }
       public ProductSort SortBy { get; set; }

       

    }
}
