using IotasmartBuild.Framework.ViewModels.Category;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Framework.CustomFilters;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.Category;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProtectedBrowser.API
{
    [RoutePrefix("api")]
    [CustomExceptionFilter]
    public class CategoryController : ApiController
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        ///  Api use for get all categories
        /// </summary>
        /// <returns></returns>
        [Route("categories")]
        [HttpGet]
        public IHttpActionResult GetAllCategories([FromUri] SearchParam param)
        {
            if (param != null && param.Next != null && param.Offset != null)
            {
                var categoriesInternal = _categoryService.CategorySelect(null, null, param.Next, param.Offset).Select(x => x.ToViewModel());
                return Ok(categoriesInternal.SuccessResponse());
            }
            var categories = _categoryService.CategorySelect(null, null, null, null).Select(x => x.ToViewModel());
            return Ok(categories.SuccessResponse());
        }

        [Route("active-categories/{pageSize:int}/{pageNumber:int}")]
        [HttpGet]
        public IHttpActionResult ActiveCategories(int pageSize = 10, int pageNumber = 1)
        {
            var categories = _categoryService.CategorySelect(null, true, pageSize, pageNumber).Select(x => x.ToViewModel()); ;
            return Ok(categories.SuccessResponse());
        }

        /// <summary>
        /// Api use for get  category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("category/{id:long}")]
        [HttpGet]
        public IHttpActionResult GetCategory(long id)
        {
            var category = _categoryService.CategorySelect(id, null).FirstOrDefault().ToViewModel();
            return Ok(category.SuccessResponse());
        }

        /// <summary>
        /// Api use for  save category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("category")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpPost]
        public IHttpActionResult SaveCategory(CategoryViewModel model)
        {
            model.CreatedBy = User.Identity.GetUserId<long>();
            var categoryId = _categoryService.CategoryInsert(model.ToModel());
            return Ok(categoryId.SuccessResponse("Category save successfully"));
        }

        /// <summary>
        /// Api use for update category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("category")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpPut]
        public IHttpActionResult UpdateCategory(CategoryViewModel model)
        {
            model.UpdatedBy = User.Identity.GetUserId<long>();
            _categoryService.CategoryUpdate(model.ToModel());
            return Ok("Category Update successfully".SuccessResponse());
        }

        /// <summary>
        /// Api use for delete category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("category/{id:long}")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(long id)
        {
            CategoryViewModel model = new CategoryViewModel();
            model.CategoryId = id;
            model.IsDeleted = true;
            model.UpdatedBy = User.Identity.GetUserId<long>();
            _categoryService.CategoryUpdate(model.ToModel());
            return Ok("Category Deleted successfully".SuccessResponse());
        }

    }
}
