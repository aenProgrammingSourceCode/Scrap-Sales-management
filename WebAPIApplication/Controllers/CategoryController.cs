using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Category;
using alamapp.ServiceImplementations.ViewModel;
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
   
    public class CategoryController : ApiController
    {
        private ICategoryService _categoryService;
        IList<string> _getString=new List<string>();
        public string UploadedImage { get; set; }
        public string BaseImageId
        {
            get { return string.Concat(Guid.NewGuid().ToString(), ".jpg");}
        }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public void DeleteCategory(JsonCategoryRequests jsonCategoryRequest)
        {
            DeleteCategoryRequest request=new DeleteCategoryRequest();
            request.DeleteRequestId = jsonCategoryRequest.ConvertToCategoryRequests();
            _categoryService.DeleteCategoryByCategories(request);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateCategoryRequest request)
        {
            CreateCategoryRequest categoryRequest = new CreateCategoryRequest();
            categoryRequest.Name = request.Name;
            categoryRequest.Description = request.Description;
            CreateCategoryResponse response=_categoryService.CreateCategory(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }

        [HttpPost]
        public void Post(CreateCategoryRequest request)
        {
            CreateCategoryRequest categoryRequest = new CreateCategoryRequest();
            categoryRequest.Name = request.Name;
            categoryRequest.Description = request.Description;
            _categoryService.SaveCategory(request);
        }
        public int GetLastCategory()
        {
            return _categoryService.GetLastCategoryFromAllCategory();
        }
        
        [HttpPost]
        public string UploadCategoryNewImage()
        {
            int AdjustImageId = GetLastCategory()+1;
            string ImageId = AdjustImageId.ToString();

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpFileUpload = HttpContext.Current.Request.Files["UploadImage"];
                if (httpFileUpload != null)
                {
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/CategoryImage"), ImageId +".jpg");
                    httpFileUpload.SaveAs(fileSavePath);
                }
            }

            return ImageId;
        }
        
        [HttpPost]
        public void ModifyCategory(int id, CategoryView categoryView)
        {
            ModifyCategoryRequest request = new ModifyCategoryRequest();
            request.Id = id;
            request.Name = categoryView.Name;
            request.Description = categoryView.Description;
            //request.Description = categoryView.ImageId;
            _categoryService.ModifyCategory(request);
 
        }
        public void ModifyUploadedFile(int Id)
        {
            string ImageId = Id.ToString();
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpFileUpload = HttpContext.Current.Request.Files["EditUploadedImage"];
                if (httpFileUpload != null)
                {
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/CategoryImage"), ImageId + ".jpg");
                    httpFileUpload.SaveAs(fileSavePath);
                }
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAllCategories(string id)
        {
            GetAllCategoryResponse response=_categoryService.GetAllCategory();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Categories);
            if (id != null)
            {
                response.Categories = _categoryService.GetCategoryBySearchCriteria(id);
                return httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Categories);
            }
            else
                return httpResponse;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            GetAllCategoryResponse response = _categoryService.GetAllCategory();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response.Categories);
            return httpResponse;
        }


        [HttpGet]
        public HttpResponseMessage GetCategory(int id)
        {
            GetCategoryRequest request = new GetCategoryRequest() { CategoryId = id };
            GetCategoryResponse response = _categoryService.GetCategory(request);
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
        }
       
    }
}
