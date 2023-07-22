using alamapp.ServiceImplementations.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Product
{
   public class GetProductByCategoryResponse
    {
        public int SelectedCategoryId { get; set; }
        public string SelectedCategoryName { get; set; }
        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }
        public IEnumerable<ProductView> Products { get; set; }
        public int NumberOfTitleFound { get; set; }
    }
}
