using ProtectedBrowser.Common.Constants;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.ViewModels.Appointment;
using ProtectedBrowser.Service.Appointment;
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
    public class AppointmentController : ApiController
    {
        private IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [Route("appointment")]
        // [Authorize(Roles = UserRole.Admin)]
        [HttpPost]
        public IHttpActionResult SaveAppointment(AppointmentViewModel model)
        {
            var userId = model.CreatedBy = User.Identity.GetUserId<long>();
            var responseId = _appointmentService.AppointmentInsert(model.ToModel());
            return Ok(responseId.SuccessResponse("Appointment saved successfully"));
        }
        [Route("appointment/timeslot")]
        //[Authorize(Roles = UserRole.Admin)]
        [HttpGet]
        public IHttpActionResult AppointmentSlot([FromUri]SearchParam param)
        {
            param = param ?? new SearchParam();
            var timeSlot = _appointmentService.GetUserAppointmentSlot(param.AppointmentDate, param.ToUserId).Select(x => x.ToViewModel());
            return Ok(timeSlot.SuccessResponse());
        }
        [Route("appointment")]
        [Authorize(Roles = UserRole.Admin)]
        [HttpPut]
        public IHttpActionResult UpdateAppointment(AppointmentViewModel model)
        {
            var userId = User.Identity.GetUserId<long>();
            string message = "Appointment Updated successfully";
            _appointmentService.AppointmentUpdate(model.ToModel());
            if (Convert.ToBoolean(model.IsCancel))
            {
                message = "Appointment Cancelled successfully";
            }
            return Ok(message.SuccessResponse());
        }

        [Route("appointments")]
        [Authorize(Roles = UserRole.Admin)]
        public IHttpActionResult GetAllAppointments(SearchParam param)
        {
            param = param ?? new SearchParam();
            var appointments = _appointmentService.AppointmentSelect(param).Select(x => x.ToViewModel());
            return Ok(appointments.SuccessResponse());
        }
        [Route("appointment/{id}")]
        [Authorize(Roles = UserRole.Admin)]
        public IHttpActionResult GetAppointmentById(long? id)
        {
            SearchParam param = new SearchParam();
            param.Id = id;
            var appointment = _appointmentService.AppointmentSelect(param).FirstOrDefault().ToViewModel();
            return Ok(appointment.SuccessResponse());
        }
    }
}
