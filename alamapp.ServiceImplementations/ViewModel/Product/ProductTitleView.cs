using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Product
{
   public class ProductTitleView
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public string CreatedDate { get; set; }
       public string CategoryName { get; set; }
       public string BrandName { get; set; }
       public string ManufactureName { get; set; }
       public string ProductModelName { get; set; }
       public decimal Price { get; set; }
    }
}
