using alamapp.Infrastructure.CookieStorage;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPIApplication.Models;
using WebAPIApplication.Models.JsonDto;


namespace WebAPIApplication.Controllers
{
    public class ProductController : BaseApiController
    {
        private IProductService _productService;
        private ICookieStorageService _cookieStorage;
        public ProductController(IProductService productService, ICookieStorageService cookieStorageService, ICookieStorageService cookieStorage)
            : base(cookieStorageService)
        {
            _productService = productService;
            _cookieStorage = cookieStorage;
        }
        //[HttpGet]
        //public HttpResponseMessage GetBasketSummaries()
        //{
        //    BasketSummaryHome basketSummaryhome = new BasketSummaryHome();
        //    basketSummaryhome.BasketSummary = base.GetBasketSummary();
        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, basketSummaryhome);
        //    return httpResponse;
        //}
        //[HttpGet]
        //public HttpResponseMessage GetProductByCategory(int CategoryId)
        //{
        //    GetProductByCategoryRequest request = GenerateProductByCategoryRequest(CategoryId);
        //    GetProductByCategoryResponse response = _productService.GetProductByCategory(request);

        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);

        //    return httpResponse;
        //}
        //public GetProductByCategoryRequest GenerateProductByCategoryRequest(int CategoryId)
        //{
        //    GetProductByCategoryRequest request = new GetProductByCategoryRequest();
        //    request.CategoryId = CategoryId;
        //    request.SortBy = ProductSort.PriceToLow;
        //    return request;
        //}
        //[HttpPost]
        //public HttpResponseMessage GetProductByProductItems(ProductSearchCriteria productRequest)
        //{
        //    GetProductByCategoryRequest request = GenerateProductByItemRequest(productRequest);
        //    GetProductByCategoryResponse response = _productService.GetProductByCategory(request);

        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);

        //    return httpResponse;
        //}
        //public GetProductByCategoryRequest GenerateProductByItemRequest(ProductSearchCriteria productCriteria)
        //{
        //    GetProductByCategoryRequest request = new GetProductByCategoryRequest();
        //    request.CategoryId = productCriteria.CategoryId;
        //    request.ProductModelId = productCriteria.ProductModelId;
        //    request.ManufactureId = productCriteria.ManufactureId;
        //    request.BrandId = productCriteria.BrandId;
        //    request.SortBy = ProductSort.PriceToLow;
        //    return request;
        //}
        //[HttpGet]
        //public HttpResponseMessage GetProductDetails(int id)
        //{
        //    GetProductDetailsRequest request = new GetProductDetailsRequest() { ProductId = id };
        //    GetProductDetailsResponse response = _productService.GetProductDetails(request);

        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);

        //    return httpResponse;
        //}
        //public void ModifyProductImages(int imageId)
        //{
        //    ModifyProductTitleImageRequest request = new ModifyProductTitleImageRequest();
        //    request.ImageId = imageId;
        //    _productService.ModifyProductImage(request);
        //}
        //[HttpGet]
        //public int GetProductImage()
        //{
        //    return _productService.CountLastProductImage();
        //}
        //[HttpPost]
        //public void AddProductImage()
        //{
        //    int ImageId = GetProductImage() + 1;
        //    string PrimaryImage = ImageId.ToString();
        //    if (HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var httpFileUpload = HttpContext.Current.Request.Files["UploadImage"];
        //        if (httpFileUpload != null)
        //        {
        //            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/ProductImage"), PrimaryImage + ".jpg");
        //            httpFileUpload.SaveAs(fileSavePath);
        //        }
        //    }
        //}
        //[HttpPost]
        //public HttpResponseMessage CreateProductTitleWithAssign(CreateProductTitleRequest request)
        //{
        //    CreateProductTitleResponse response = _productService.CreateProductTitle(request);
        //    CreateProductRequest productRequest = new CreateProductRequest();
        //    productRequest.ProductTitleId = response.ProductTitle.Id;
        //    _productService.AssignProductTitleToProduct(productRequest);
        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.ProductTitle.Id);
        //    return httpResponse;
        //}

        //[HttpPost]
        //public HttpResponseMessage CreateProductTitles(CreateProductTitleRequest request)
        //{
        //    CreateProductTitleResponse response = _productService.CreateProductTitle(request);
        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.ProductTitle.Id);

        //    return httpResponse;
        //}
        //public void ChangePicture(int ImageId)
        //{
        //    string PrimaryImage = ImageId.ToString();
        //    if (HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var httpFileUpload = HttpContext.Current.Request.Files["UploadImage"];
        //        if (httpFileUpload != null)
        //        {
        //            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/ProductImage"), PrimaryImage + ".jpg");
        //            httpFileUpload.SaveAs(fileSavePath);
        //            //FileInfo fileInfo = new FileInfo(fileSavePath);
        //            //fileInfo.Replace(fileSavePath, "lps");
        //        }
        //    }
        //}
        //[HttpPost]
        //public void ModifyProductTitles(int productTitleId, ProductTitleModifyCriteria productCriteria)
        //{
        //    ModifyProductTitleRequest request = new ModifyProductTitleRequest();

        //    request.ProductTitleId = productTitleId;
        //    request.Name = productCriteria.Name;
        //    request.Price = productCriteria.Price;
        //    request.CategoryId = productCriteria.CategoryId;
        //    request.ManufactureId = productCriteria.ManufactureId;
        //    request.BrandId = productCriteria.BrandId;
        //    request.ProductModelId = productCriteria.ProductModelId;
        //    request.Description = productCriteria.Description;

        //    _productService.ModifyProductTitle(request);
        //}

        //[HttpPost]
        //public void AssignProductTitleToProduct(CreateProductRequest request)
        //{
        //    _productService.AssignProductTitleToProduct(request);
        //}

        ////Package method
        //[HttpGet]
        //public HttpResponseMessage GetPackage(int CategoryId)
        //{
        //    GetPackageByCategoryRequest request = new GetPackageByCategoryRequest() { CategoryId = CategoryId };

        //    GetPackageByCategoryResponse response = _productService.GetPackageByCategory(request);

        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);

        //    return httpResponse;

        //}


        //[HttpGet]
        //public HttpResponseMessage GetPackageDetails(int PackageId)
        //{
        //    GetPackageDetailsRequest request = new GetPackageDetailsRequest() { PackageId = PackageId };
        //    GetPackageDetailsResponse response = _productService.GetPackageDetailsByPackage(request);
        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);

        //    return httpResponse;
        //}

        //[HttpPost]
        //public void DeleteproductTitle(int ProductTitleId)
        //{
        //    DeleteProductTitleRequest request = new DeleteProductTitleRequest();
        //    IList<int> ProductTitles = new List<int>();
        //    ProductTitles.Add(ProductTitleId);

        //    request.RemoveToProduct = ProductTitles;
        //    _productService.DeleteProductByProductTitle(request);
        //}

        //[HttpPost]
        //public void DeleteProducts(JsonProductRequests jsonProducts)
        //{
        //    DeleteProductRequest request=new DeleteProductRequest();
        //    request.DeleteProductId=jsonProducts.Products.ConvertToProductRequests();
        //    _productService.DeleteProductByProduct(request);
        //}

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            GetAllProductResponse response = _productService.GetAllProduct();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);

            return httpResponse;
        }
    }
}