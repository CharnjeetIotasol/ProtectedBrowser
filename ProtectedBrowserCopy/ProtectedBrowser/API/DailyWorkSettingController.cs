using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.ViewModels.DailyWorkSetting;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.DailyWorkSetting;
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
    public class DailyWorkSettingController : ApiController
    {
        private IDailyWorkSettingService _dailyWorkSettingService;
        public DailyWorkSettingController(IDailyWorkSettingService dailyWorkSettingService)
        {
            _dailyWorkSettingService = dailyWorkSettingService;
        }

        /// <summary>
        /// Get work setting
        /// </summary>
        /// <returns></returns>
        [Route("daily/work/setting")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult DailyWorkSettingSelect()
        {
            var dailyWorkSetting = _dailyWorkSettingService.DailyWorkSettingSelect().ToViewModel();
            return Ok(dailyWorkSetting.SuccessResponse());

        }

        /// <summary>
        /// Save and update work setting
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("daily/work/setting")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult DailyWorkSettingAction(DailyWorkSettingViewModel model)
        {
            model.CreatedBy = User.Identity.GetUserId<long>();
            long id = _dailyWorkSettingService.DailyWorkSettingAction(model.ToModel());
            if (model.Id == null)
                return Ok(id.SuccessResponse("Work setting saved successfully."));
            else
                return Ok(id.SuccessResponse("Work setting updated successfully."));

        }
    }
}
