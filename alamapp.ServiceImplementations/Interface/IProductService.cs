using alamapp.ServiceImplementations.Messaging.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface IProductService
    {
        //GetProductByCategoryResponse GetProductByCategory(GetProductByCategoryRequest request);
        //GetProductDetailsResponse GetProductDetails(GetProductDetailsRequest request);
        //GetPackageByCategoryResponse GetPackageByCategory(GetPackageByCategoryRequest request);
        //GetPackageDetailsResponse GetPackageDetailsByPackage(GetPackageDetailsRequest request);
        //CreateProductTitleResponse CreateProductTitle(CreateProductTitleRequest request);
        //void ModifyProductImage(ModifyProductTitleImageRequest request);
        //void AssignProductTitleToProduct(CreateProductRequest request);
        //void ModifyProductTitle(ModifyProductTitleRequest request);
        //int CountLastProductImage();

        //void DeleteProductByProductTitle(DeleteProductTitleRequest request);
        //void DeleteProductByProduct(DeleteProductRequest request);
        GetAllProductResponse GetAllProduct();
       
    }
}
