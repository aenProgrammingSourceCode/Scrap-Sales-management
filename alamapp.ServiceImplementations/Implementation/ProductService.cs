using alamapp.Infrastructure.Querying;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Categories;
using alamapp.Model.Packages;
using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface.Packages;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Mapping;
using alamapp.ServiceImplementations.Messaging.Product;
using alamapp.ServiceImplementations.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IProductTitleRepository _productTitleRepository;
        private IManufactureRepository _manufactureRepository;
        private IBrandRepository _brandRepository;
        private IProductModelRepository _productModelRepository;
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _uow;
        private IPackageRepository _packageRepository;
        private IProductImageRepository _productImageRepository;
        public ProductService(IProductRepository productRepository,
            IProductTitleRepository productTitleRepository,
            IProductModelRepository productModelRepository,
            IBrandRepository brandRepository,
            IManufactureRepository manufactureRepository,
            ICategoryRepository categoryRepository,
            IPackageRepository packageRepository,
            IProductImageRepository productImageRepository,
            IUnitOfWork uow)
        {
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _productModelRepository = productModelRepository;
            _manufactureRepository = manufactureRepository;
            _productTitleRepository = productTitleRepository;
            _productRepository = productRepository;
            _packageRepository = packageRepository;
            _productImageRepository = productImageRepository;
            _uow = uow;
        }

        ////public IEnumerable<Product> GetAllProductBySortingAndQuery(GetProductByCategoryRequest request, Query productQuery)
        ////{
        ////    IEnumerable<Product> productSearchMatching = _productRepository.FindBy(productQuery);
        ////    switch (request.SortBy)
        ////    {
        ////        case ProductSort.PriceToHigh:
        ////            productSearchMatching = productSearchMatching.OrderByDescending(p => p.Title.Price);
        ////            break;
        ////        case ProductSort.PriceToLow:
        ////            productSearchMatching = productSearchMatching.OrderBy(p => p.Title.Price);
        ////            break;
        ////        default:
        ////            break;
        ////    }
        ////    return productSearchMatching;
        ////}
        ////public GetProductByCategoryResponse GetProductByCategory(GetProductByCategoryRequest request)
        ////{
        ////    Query productQuery = ProductSearchGenerateQueryfromReuquest.CreateProductQuery(request);
        ////    IEnumerable<Product> ProductMatchingRefinement = GetAllProductBySortingAndQuery(request, productQuery);
        ////    GetProductByCategoryResponse response = ProductMatchingRefinement.ProductSearchResultForm(request);

        ////    return response;
        ////}
        //public GetProductDetailsResponse GetProductDetails(GetProductDetailsRequest request)
        //{
        //    Product product = _productRepository.FindBy(request.ProductId);
        //    GetProductDetailsResponse response = new GetProductDetailsResponse();
        //    response.Product = product.ConvertToProductView();
        //    return response;
        //}
        //public CreateProductTitleResponse CreateProductTitle(CreateProductTitleRequest request)
        //{
        //    ProductTitle productTitle = new ProductTitle();
        //    productTitle.Name = request.Name;
        //    productTitle.Price = request.Price;
        //    productTitle.Description = request.Description;

        //    Manufacture manufacture = _manufactureRepository.FindBy(request.ManufactureId);
        //    Brand brand = _brandRepository.FindBy(request.BrandId);
        //    ProductModel productModel = _productModelRepository.FindBy(request.ProductModelId);
        //    Category category = _categoryRepository.FindBy(request.CategoryId);

        //    productTitle.Category = category;
        //    productTitle.Manufacture = manufacture;
        //    productTitle.ProductModel = productModel;
        //    productTitle.Brand = brand;

        //    // Method for adding product image
        //    productTitle.AddProductImage();

        //    _productTitleRepository.Add(productTitle);

        //    _uow.Commit();

        //    CreateProductTitleResponse response = new CreateProductTitleResponse();
        //    response.ProductTitle = productTitle.ConvertToProductTitleView();

        //    return response;
        //}
        //public void ModifyProductTitle(ModifyProductTitleRequest request)
        //{
        //    ProductTitle productTitle = _productTitleRepository.FindBy(request.ProductTitleId);
        //    productTitle.Name = request.Name;
        //    productTitle.Price = request.Price;
        //    productTitle.Description = request.Description;

        //    Manufacture manufacture = _manufactureRepository.FindBy(request.ManufactureId);
        //    Brand brand = _brandRepository.FindBy(request.BrandId);
        //    ProductModel productModel = _productModelRepository.FindBy(request.ProductModelId);
        //    Category category = _categoryRepository.FindBy(request.CategoryId);

        //    productTitle.Category = category;
        //    productTitle.Manufacture = manufacture;
        //    productTitle.ProductModel = productModel;
        //    productTitle.Brand = brand;

        //    _productTitleRepository.Save(productTitle);

        //    _uow.Commit();
        //}
        //public int CountLastProductImage()
        //{
        //    IEnumerable<Product> productImage =_productRepository.FindAll();
        //    return productImage.Last().Id;
        //}
        //public void AssignProductTitleToProduct(CreateProductRequest request)
        //{
        //    Product product = new Product();
        //    ProductTitle productTitle = _productTitleRepository.FindBy(request.ProductTitleId);
        //    //product.Title = productTitle;
        //    _productRepository.Add(product);
        //}
        //public void ModifyProductImage(ModifyProductTitleImageRequest request)
        //{
        //    ProductImage productImage = _productImageRepository.FindBy(request.ImageId);
        //    _productImageRepository.Save(productImage);
        //    _uow.Commit();
        //}
        //public Messaging.Product.GetPackageByCategoryResponse GetPackageByCategory(Messaging.Product.GetPackageByCategoryRequest request)
        //{
        //    Package package = _packageRepository.FindBy(request.CategoryId);
        //    GetPackageByCategoryResponse response = new GetPackageByCategoryResponse();
        //    response.Packages = package.ConvertToPackageView();

        //    return response;
        //}
        //public Messaging.Product.GetPackageDetailsResponse GetPackageDetailsByPackage(Messaging.Product.GetPackageDetailsRequest request)
        //{
        //    Package package = _packageRepository.FindBy(request.PackageId);
        //    GetPackageDetailsResponse response = new GetPackageDetailsResponse();
        //    response.Package = package.ConvertToPackageView();

        //    return response;
        //}
        //public void DeleteProductByProductTitle(DeleteProductTitleRequest request)
        //{
        //    RemoveProductTitle(request.RemoveToProduct);
        //    _uow.Commit();
        //}
        //public void RemoveProductTitle(IList<int> RemoveToProductTitle)
        //{
        //    ProductTitle productTitle;
        //    foreach (int productTitleId in RemoveToProductTitle)
        //    {
        //        productTitle = _productTitleRepository.FindBy(productTitleId);
        //        _productTitleRepository.Delete(productTitle);
        //        _uow.Commit();
        //    }
        //}

        //public void DeleteProductByProduct(DeleteProductRequest request)
        //{
        //    RemoveProduct(request.DeleteProductId);
        //}
        //public void RemoveProduct(IList<DeleteProductIdRequest> productToDelete)
        //{
        //    Product product;
        //    foreach (DeleteProductIdRequest productId in productToDelete)
        //    {
        //        product = _productRepository.FindBy(productId.ProductId);
        //        _productRepository.Delete(product);
        //        _uow.Commit();
        //    }
        //}
        public GetAllProductResponse GetAllProduct()
        {
            GetAllProductResponse response = new GetAllProductResponse();
            IEnumerable<Product> products = _productRepository.FindAll();
            response.Products = products.ConvertToProductViews();
            return response;
        }
      
    }
}
