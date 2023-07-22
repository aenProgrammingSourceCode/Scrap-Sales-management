using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface.Products;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Products
{
  public  class ProductRepository:Repository<Product,int>, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
        public override void AppendCriteria(ICriteria criteria)
        {
            criteria.CreateAlias("Title", "ProductTitle");
            criteria.CreateAlias("ProductTitle.Category", "Category");
            criteria.CreateAlias("ProductTitle.Brand", "Brand");
            criteria.CreateAlias("ProductTitle.Manufacture", "Manufacture");
            criteria.CreateAlias("ProductTitle.ProductModel", "ProductModel");
        }
    }
}
