using ProtectedBrowser.Common.Constants;
using ProtectedBrowser.Common.Extensions;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.Upload;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.ViewModels.DummyFileUpload;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.DummyFileUpload;
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
    public class DummyTableForFileController : ApiController
    {
        private IFileGroupService _fileGroupService;
        private IDummyFileUploadService _dummyFileUploadService;
        public DummyTableForFileController(IFileGroupService fileGroupService, IDummyFileUploadService dummyFileUploadService)
        {
            _fileGroupService = fileGroupService;
            _dummyFileUploadService = dummyFileUploadService;
        }
        /// <summary>
        /// Save list of flies
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("dummy/table")]
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpPost]
        public IHttpActionResult DummyTableForFileSave(DummyTableForFileViewModel model)
        {
            if (model == null)
                return Ok("Invalid data.".ErrorResponse());
            var userId = model.CreatedBy = User.Identity.GetUserId<long>();
            //convert view model to model
            //save dummy table data
            var modelConvert = model.ToModel();
            var dummyId = _dummyFileUploadService.DummyTableForFileInsert(modelConvert);
            return Ok("Saved successfully".SuccessResponse());
        }
        /// <summary>
        /// Update list of files
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("dummy/table")]
        [Authorize]
        [HttpPut]
        public IHttpActionResult DummyTableForFileUpdate(DummyTableForFileViewModel model)
        {
            if (model == null)
                return Ok("Invalid data.".ErrorResponse());
            var userId = model.UpdatedBy = User.Identity.GetUserId<long>();
            //convert view model to model
            //save dummy table data
            var modelConvert = model.ToModel();
           _dummyFileUploadService.DummyTableForFileUpdate(modelConvert);
            return Ok("updated successfully".SuccessResponse());
        }
        [Route("dummy/table/singlefile")]
        [Authorize]
        [HttpPost]
        public IHttpActionResult DummyTableForSingleFileSave(DummyTableForFileViewModel model)
        {
            if (model == null)
                return Ok("Invalid data.".ErrorResponse());
            var userId = model.CreatedBy = User.Identity.GetUserId<long>();
            //convert view model to model
            //save dummy table data
            var modelConvert = model.ToModel();
            var dummyId = _dummyFileUploadService.DummyTableForFileInsert(modelConvert);
           
            return Ok("Saved successfully".SuccessResponse());
        }
        /// <summary>
        /// Get all records with list of files
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("dummy/table")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult DummyTableForFileSelect([FromUri] SearchParam param)
        {
            param = param ?? new SearchParam();
            var returnVal = _dummyFileUploadService.DummyTableForFileSelect(param);
            return Ok(returnVal.SuccessResponse());
        }
        /// <summary>
        /// Get by id with list of files 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("dummy/table/{id}")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult DummyTableForFileSelectById(long? id)
        {
            SearchParam param = new SearchParam();
            param.Id = id;
            var returnVal = _dummyFileUploadService.DummyTableForFileSelectById(param);
            return Ok(returnVal.SuccessResponse());
        }
        [Route("dummy/table/singlefile")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult DummyTableForFileSelectBySingleFile(SearchParam param)
        {
            param = param ?? new SearchParam();
            var returnVal = _dummyFileUploadService.DummyTableForFileSelectBySingleFile(param);
            return Ok(returnVal.SuccessResponse());
        }
    }
}
