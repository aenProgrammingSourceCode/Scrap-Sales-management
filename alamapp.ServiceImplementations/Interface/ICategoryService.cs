using alamapp.ServiceImplementations.Messaging.Category;
using alamapp.ServiceImplementations.Messaging.Product;
using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface ICategoryService
   {
       CreateCategoryResponse CreateCategory(CreateCategoryRequest request);
       void SaveCategory(CreateCategoryRequest request);
       void ModifyCategory(ModifyCategoryRequest request);
       GetCategoryResponse GetCategory(GetCategoryRequest request);
       IEnumerable<CategoryView> GetCategoryBySearchCriteria(string searchCriteria);
       GetAllCategoryResponse GetAllCategory();
       int GetLastCategoryFromAllCategory();
       void DeleteCategoryByCategories(DeleteCategoryRequest request);
    
    }
}
