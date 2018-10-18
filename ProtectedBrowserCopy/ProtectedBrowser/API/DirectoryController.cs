using ProtectedBrowser.Framework.CustomFilters;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.ViewModels.Directory;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.Directory;
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
    public class DirectoryController : ApiController
    {
        private IDirectoryService _directoryService;
        public DirectoryController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        /// <summary>
        ///  Api use for get all Directory
        /// </summary>
        /// <returns></returns>
        [Route("Directorys")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpGet]
        public IHttpActionResult GetAllDirectorys()
        {
            var directorys = _directoryService.SelectDirectory(null).Select(x => x.ToViewModel()); ;
            return Ok(directorys.SuccessResponse());
        }

 		/// <summary>
        ///  Api use for get all Active Directory with Limit and Offset 
        /// </summary>
        /// <returns></returns>
        [Route("active-directorys/{pageSize:int}/{pageNumber:int}")]
        [HttpGet]
        public IHttpActionResult ActiveDirectorys(int pageSize = 10, int pageNumber = 1)
        {
            var directorys = _directoryService.SelectDirectory(null, true, pageSize, pageNumber).Select(x => x.ToViewModel()); ;
            return Ok(directorys.SuccessResponse());
        }

        /// <summary>
        /// Api use for get directory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("directory/{id:long}")]
        [HttpGet]
        public IHttpActionResult GetDirectory(long id)
        {
            var directory = _directoryService.SelectDirectory(id).FirstOrDefault().ToViewModel();
            return Ok(directory.SuccessResponse());
        }

        /// <summary>
        /// Api use for  save directory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("directory")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpPost]
        public IHttpActionResult SaveDirectory(DirectoryViewModel model)
        {
            model.CreatedBy = User.Identity.GetUserId<long>();
            model.UpdatedBy = User.Identity.GetUserId<long>();
            var responseId = _directoryService.DirectoryInsert(model.ToModel());
            return Ok(responseId.SuccessResponse("Directory save successfully"));
        }

        /// <summary>
        /// Api use for update directory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("directory")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [CustomExceptionFilter]
        [HttpPut]
        public IHttpActionResult UpdateDirectory(DirectoryViewModel model)
        {
            _directoryService.DirectoryUpdate(model.ToModel());
            return Ok("Directory Update successfully".SuccessResponse());
        }

        /// <summary>
        /// Api use for delete directory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("directory/{id:long}")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [CustomExceptionFilter]
        [HttpDelete]
        public IHttpActionResult DeleteDirectory(long id)
        {
            DirectoryViewModel model = new DirectoryViewModel();
            model.Id = id;
            model.IsDeleted = true;
            _directoryService.DirectoryUpdate(model.ToModel());
            return Ok("Directory Deleted successfully".SuccessResponse());
        }
    }
}
