using IotasmartBuild.Framework.ViewModels.Blog;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.Blog;
using ProtectedBrowser.Service.FileGroup;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProtectedBrowser.API
{
    [RoutePrefix("api")]
    public class BlogController : ApiController
    {
        private IBlogService _blogService;
        private IFileGroupService _fileGroupService;
        public BlogController(IBlogService blogService, IFileGroupService fileGroupService)
        {
            _blogService = blogService;
            _fileGroupService = fileGroupService;
        }
        /// <summary>
        ///  Api use for get all blogs
        /// </summary>
        /// <returns></returns>
        [Route("admin/blogs")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpGet]
        public IHttpActionResult GetAllBlogsForAdmin([FromUri]SearchParam param)
        {
            var blogs = _blogService.BlogSelect(null, param.CategoryId, null, param.Next, param.Offset).Select(x => x.ToViewModel());
            return Ok(blogs.SuccessResponse());
        }

        [Route("admin/blog/{id:long}")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpGet]
        public IHttpActionResult GetBlogbyId(long id)
        {
            var blog = _blogService.BlogSelect(id, null).FirstOrDefault().ToViewModel();
            return Ok(blog.SuccessResponse());
        }
        [Route("blogs/{id:long}/category")]
        [HttpGet]
        public IHttpActionResult GetAllBlogsbyCategoryId([FromUri]SearchParam param)
        {
            var blogs = _blogService.BlogSelect(null, param.CategoryId, true, param.Next, param.Offset).Select(x => x.ToViewModel());
            return Ok(blogs.SuccessResponse());
        }
        /// <summary>
        /// Api use for get  blog by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("blog/{id:long}")]
        [HttpGet]
        public IHttpActionResult GetBlogById(long id)
        {
            var blog = _blogService.BlogSelect(id, null).FirstOrDefault().ToViewModel();
            return Ok(blog.SuccessResponse());
        }

        /// <summary>
        /// Api use for  save blog
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("admin/blog")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpPost]
        public IHttpActionResult SaveBlog(BlogViewModel model)
        {
            model.CreatedBy = User.Identity.GetUserId<long>();
            var blogId = _blogService.BlogInsert(model.ToModel());

            var fileGroupsItem = model.FileGroupItem != null ? model.FileGroupItem.ToModel() : null;
            if (fileGroupsItem != null)
            {
                //set target path and move file from target location
                fileGroupsItem = _fileGroupService.SetPathAndMoveSingleFile(fileGroupsItem, blogId);
                //Save list of file in our DB
                _fileGroupService.FileGroupItemsInsert(fileGroupsItem);
            }
            return Ok(blogId.SuccessResponse("Blog save successfully"));
        }

        /// <summary>
        /// Api use for update category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("admin/blog")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpPut]
        public IHttpActionResult UpdateBlog(BlogViewModel model)
        {
            model.UpdatedBy = User.Identity.GetUserId<long>();
            _blogService.BlogUpdate(model.ToModel());
            var fileGroupsItem = model.FileGroupItem != null ? model.FileGroupItem.ToModel() : null;
            if (fileGroupsItem != null && (fileGroupsItem.Id == null || fileGroupsItem.Id == 0))
            {
                //set target path and move file from target location
                fileGroupsItem = _fileGroupService.SetPathAndMoveSingleFile(fileGroupsItem, model.Id);
                //Save list of file in our DB
                _fileGroupService.FileGroupItemsInsert(fileGroupsItem);
            }
            return Ok("Blog Update successfully".SuccessResponse());
        }
        /// <summary>
        /// Api use for delete blog by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("admin/blog/{id:long}")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpDelete]
        public IHttpActionResult DeleteBlog(long id)
        {
            BlogViewModel model = new BlogViewModel();
            model.Id = id;
            model.IsDeleted = true;
            model.UpdatedBy = User.Identity.GetUserId<long>();
            _blogService.BlogUpdate(model.ToModel());
            return Ok("Blog Deleted successfully".SuccessResponse());
        }
    }
}
