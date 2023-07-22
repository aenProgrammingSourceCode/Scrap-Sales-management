using alamapp.Infrastructure.Querying;
using alamapp.Model.Products;
using alamapp.ServiceImplementations.Messaging.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class ProductSearchGenerateQueryfromReuquest
    {
       public static Query CreateProductQuery(GetProductByCategoryRequest request)
       {
           Query productQuery = new Query();
           Query brandQuery = new Query();
           Query manufactureQuery = new Query();
           Query productModelQuery = new Query();

          /*
           // Brand criteria
           brandQuery.QueryOperator = QueryOperator.Or;
           foreach(int id in request.BrandId)
               brandQuery.Add(Criterion.Create<Product>(p => p.Brand.Id, id,CriteriaOperator.Equel));
           if(brandQuery.Criteria.Count()>0)
               productQuery.AddSubQueries(brandQuery);

           // Manufacture Criteria
           manufactureQuery.QueryOperator = QueryOperator.Or;
           foreach (int id in request.ManufactureId)
               manufactureQuery.Add(Criterion.Create<Product>(p => p.Manufacture.Id, id, CriteriaOperator.Equel));
           if (manufactureQuery.Criteria.Count() > 0)
               productQuery.AddSubQueries(manufactureQuery);
           
           // Product Model criteria
           productModelQuery.QueryOperator = QueryOperator.Or;
           foreach (int id in request.ProductModelId)
               productModelQuery.Add(Criterion.Create<Product>(p => p.ProductModel.Id, id, CriteriaOperator.Equel));
           if (productModelQuery.Criteria.Count() > 0)
               productQuery.AddSubQueries(productModelQuery);
           
        */

          // Category Criteria

           //if (request.ProductModelId == 0 || request.ManufactureId==0 || request.BrandId==0)
           //{
           //    productQuery.Add(Criterion.Create<Product>(p => p.Category.Id, request.CategoryId, CriteriaOperator.Equel));

           //    return productQuery;

           //}
           //else
           //{
           //    brandQuery.Add(Criterion.Create<Product>(p => p.Brand.Id, request.BrandId, CriteriaOperator.Equel));
           //    productQuery.AddSubQueries(brandQuery);

           //    manufactureQuery.Add(Criterion.Create<Product>(p => p.Manufacture.Id, request.ManufactureId, CriteriaOperator.Equel));
           //    productQuery.AddSubQueries(manufactureQuery);


           //    productModelQuery.Add(Criterion.Create<Product>(p => p.ProductModel.Id, request.ProductModelId, CriteriaOperator.Equel));
           //    productQuery.AddSubQueries(productModelQuery);

           //    productQuery.Add(Criterion.Create<Product>(p => p.Category.Id, request.CategoryId, CriteriaOperator.Equel));

           return productQuery;
           //}
       }
    }
}
