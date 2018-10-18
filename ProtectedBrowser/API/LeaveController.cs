using ProtectedBrowser.Common.Constants;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.ViewModels.Leave;
using ProtectedBrowser.Service.Leave;
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
    public class LeaveController : ApiController
    {
        private ILeaveService _leaveService;
        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }
        /// <summary>
        ///  Api use for get all Leave
        /// </summary>
        /// <returns></returns>
        [Route("leaves")]
        [Authorize(Roles = UserRole.Admin)]
        [HttpGet]
        public IHttpActionResult GetAllLeaves([FromUri] SearchParam param)
        {
            param = param ?? new SearchParam();
            var leaves = _leaveService.LeaveSelect(param).Select(x => x.ToViewModel()); ;
            return Ok(leaves.SuccessResponse());
        }
        /// <summary>
        /// Api use for get leave by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("leave/{id:long}")]
        [Authorize(Roles = UserRole.Admin)]
        [HttpGet]
        public IHttpActionResult SelectLeave(long id)
        {
            SearchParam param = new SearchParam();
            param.Id = id;
            var leave = _leaveService.LeaveSelect(param).FirstOrDefault().ToViewModel();
            return Ok(leave.SuccessResponse());
        }

        /// <summary>
        /// Api use for  save leave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("leave")]
        [Authorize(Roles = UserRole.Admin)]
        [HttpPost]
        public IHttpActionResult LeaveSave(LeaveViewModel model)
        {
            model.CreatedBy = User.Identity.GetUserId<long>();
            var responseId = _leaveService.LeaveInsert(model.ToModel());
            return Ok(responseId.SuccessResponse("Leave Saved successfully"));
        }
        [Route("leave")]
        [Authorize(Roles = UserRole.Admin)]
        [HttpPut]
        public IHttpActionResult UpdateLeave(LeaveViewModel model)
        {
            _leaveService.LeaveUpdate(model.ToModel());
            return Ok("Leave Updated successfully".SuccessResponse());
        }
    }
}

