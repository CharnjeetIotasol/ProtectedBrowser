using ProtectedBrowser.Common.Constants;
using ProtectedBrowser.Common.Success;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.ViewModels.PublicHoliday;
using ProtectedBrowser.Service.PublicHoliday;
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
    public class PublicHolidayController : ApiController
    {
        private IPublicHolidayService _publicHolidayService;
        public PublicHolidayController(IPublicHolidayService publicHolidayService)
        {
            _publicHolidayService = publicHolidayService;
        }
        [Route("holiday")]
        [HttpPost]
        [Authorize(Roles = UserRole.Admin)]
        public IHttpActionResult HolidaySave([FromBody] PublicHolidayViewModel model)
        {
            model.CreatedBy = User.Identity.GetUserId<long>();
            long id = _publicHolidayService.PublicHolidayInsert(model.ToModel());
            return Ok(id.SuccessResponse());

        }
        [Route("holiday")]
        [HttpPut]
        [Authorize(Roles = UserRole.Admin)]
        public IHttpActionResult HolidayUpdate([FromBody] PublicHolidayViewModel model)
        {
            model.UpdatedBy = User.Identity.GetUserId<long>();
            _publicHolidayService.PublicHolidayUpdate(model.ToModel());
            return Ok("Updated successfully.".SuccessResponse());
        }
        [Route("holiday")]
        [HttpGet]
        [Authorize(Roles = UserRole.Admin)]
        public IHttpActionResult HolidaysSelect([FromUri] SearchParam param)
        {
            param = param ?? new SearchParam();
            var holidaysList = _publicHolidayService.PublicHolidaysSelect(param).Select(x => x.ToViewModel());
            return Ok(holidaysList.SuccessResponse());

        }
        [Route("holiday/{id}")]
        [HttpGet]
        [Authorize(Roles = UserRole.Admin)]
        public IHttpActionResult HolidaySelectById(long? id)
        {
            SearchParam param = new SearchParam();
            param.Id = id;
            var holiday = _publicHolidayService.PublicHolidaysSelect(param).Select(x => x.ToViewModel());
            return Ok(holiday.SuccessResponse());
        }
    }
}
