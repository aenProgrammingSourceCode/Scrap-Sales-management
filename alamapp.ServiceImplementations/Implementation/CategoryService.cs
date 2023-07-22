using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Categories;
using alamapp.Model.RepositoryInterface;
using alamapp.ServiceImplementations.Messaging.Category;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.ViewModel;
using alamapp.Model.RepositoryInterface.Products;


namespace alamapp.ServiceImplementations.Implementation
{
   public class CategoryService :ICategoryService
    {
       private ICategoryRepository _categoryRepository;
       private IUnitOfWork _uow;
     
       public CategoryService(
           ICategoryRepository categoryRepository,
           IUnitOfWork uow)
       {
           _categoryRepository = categoryRepository;
           _uow = uow;
        
       }
 
       public GetAllCategoryResponse GetAllCategory()
       {
           IEnumerable<Category> Categories = _categoryRepository.FindAll();
           GetAllCategoryResponse response = new GetAllCategoryResponse();
           response.Categories = Categories.ConvertToCategoryViews();

           return response;
       }

       public bool CategorySearchCriteria(string searchCriteria)
       {
           GetAllCategoryResponse response = GetAllCategory();
           return false;

           if (searchCriteria != null)
           {
               response.Categories.Any(s => s.Name.Contains(searchCriteria));
               return true;
           }
       }

       public IEnumerable<CategoryView> GetCategoryBySearchCriteria(string searchCriteria)
       {
           GetAllCategoryResponse response = GetAllCategory();
           if (CategorySearchCriteria(searchCriteria))
               return response.Categories.Where(s => s.Name.Contains(searchCriteria));
           else
               return response.Categories;
           
       }
  
       public void ModifyCategory(ModifyCategoryRequest request)
       {
           Category category = _categoryRepository.FindBy(request.Id);
           category.Name = request.Name;
           category.Description = request.Description;
           _categoryRepository.Save(category);
           _uow.Commit();
       }

    
     
       public GetCategoryResponse GetCategory(GetCategoryRequest request)
       {
           GetCategoryResponse response = new GetCategoryResponse();
           Category category = _categoryRepository.FindBy(request.CategoryId);
           response.Category = category.ConvertToCategoryView();
           return response;
          
       }

       // return int
       // from model view
       public int GetLastCategoryFromAllCategory()
       {
           IEnumerable<Category> categories = _categoryRepository.FindAll();
           GetAllCategoryResponse response = new GetAllCategoryResponse();
           response.Categories = categories.ConvertToCategoryViews();
           return response.Categories.Last().Id;
       }


       public void DeleteCategoryByCategories(DeleteCategoryRequest request)
       {
           CategoryForDeleting(request.DeleteRequestId);
       }

       private void CategoryForDeleting(IList<DeleteCategoryRequestId> requestCategoryId)
       {
           foreach (DeleteCategoryRequestId categories in requestCategoryId)
           {
               Category category = _categoryRepository.FindBy(categories.NewCategoryId);
               _categoryRepository.Delete(category);
               _uow.Commit();
           }

       }

      public CreateCategoryResponse CreateCategory(CreateCategoryRequest request)
      {
           CreateCategoryResponse response = new CreateCategoryResponse();
           Category category = new Category();
           category.Name = request.Name;
           category.Description = request.Description;
          
           response.Category = category.ConvertToCategoryView();
           return response;
       }

      public void SaveCategory(CreateCategoryRequest request)
      {
          Category category = new Category();
          category.Name = request.Name;
          category.Description = request.Description;

          _categoryRepository.Add(category);
          _uow.Commit();

      }
    }
}
