using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.ServiceImplementations.Messaging.Product;
using alamapp.ServiceImplementations.ViewModel.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class ProductMapping
    {
       
       public static  GetProductByCategoryResponse ProductSearchResultForm(this IEnumerable<Product> ProductMatching, 
           GetProductByCategoryRequest request)
       {
           GetProductByCategoryResponse response = new GetProductByCategoryResponse();
           IEnumerable<Product> ProductTitleFound=ProductMatching;
           response.NumberOfTitleFound = ProductTitleFound.Count();
           response.SelectedCategoryId = request.CategoryId;
           response.Products = ProductTitleFound.ConvertToProductViews();
           return response;
       }


       public static IList<RefinementGroup> GenerateAllRefinementProduct(IEnumerable<ProductTitle> ProductFound)
       {
           var brandRefinement = ProductFound.Select(b => b.Brand).Distinct().ToList()
               .ConvertAll<IProductAttribute>(b=>(IProductAttribute)b).ConvertToRefinementGroup(RefinementGrouping.brand);

           var manufactureRefinement = ProductFound.Select(m => m.Manufacture).Distinct().ToList()
               .ConvertAll<IProductAttribute>(m=>(IProductAttribute)m).ConvertToRefinementGroup(RefinementGrouping.manufacture);
           var ProductModelRefinement = ProductFound.Select(pm => pm.ProductModel).Distinct().ToList()
               .ConvertAll<IProductAttribute>(pm=>(IProductAttribute)pm).ConvertToRefinementGroup(RefinementGrouping.productModel);
           
          IList<RefinementGroup> refineGroup = new List<RefinementGroup>();

          refineGroup.Add(brandRefinement);
          refineGroup.Add(manufactureRefinement);
          refineGroup.Add(ProductModelRefinement);

         return refineGroup;
       }

       public static IEnumerable<ProductView> ConvertToProductViews(this IEnumerable<Product> products)
       {
           return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(products);
       }
       public static ProductView ConvertToProductView(this Product product)
       {
           return Mapper.Map<Product, ProductView>(product);
       }
    }
}
