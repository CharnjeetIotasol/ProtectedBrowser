using ProtectedBrowser.Domain.Appointment;
using ProtectedBrowser.Framework.WebExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.Appointment
{
    public static class AppointmentModelViewModelConverter
    {
        public static AppointmentViewModel ToViewModel(this AppointmentModel x)
        {
            if (x == null) return new AppointmentViewModel();
            return new AppointmentViewModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive,
                AppointmentDate = x.AppointmentDate,
                Note = x.Note,
                CancellationReason = x.CancellationReason,
                isAppointmentDone = x.isAppointmentDone,
                EndTime = x.EndTime,
                StartTime = x.StartTime,
                Status = x.Status,
                IsCancel = x.IsCancel,
                ToUserId = x.ToUserId,
                FromUserId = x.FromUserId,
                FromUser = x.FromUser != null ? x.FromUser.ToViewModel() : null,
                ToUser = x.ToUser != null ? x.ToUser.ToViewModel() : null,
                CreatedUser = x.CreatedUser != null ? x.CreatedUser.ToViewModel() : null,
                UpdatedUser = x.UpdatedUser != null ? x.UpdatedUser.ToViewModel() : null,
            };
        }

        public static AppointmentModel ToModel(this AppointmentViewModel x)
        {
            if (x == null) return new AppointmentModel();
            return new AppointmentModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive,
                AppointmentDate = x.AppointmentDate,
                Note = x.Note,
                CancellationReason = x.CancellationReason,
                EndTime = x.EndTime,
                isAppointmentDone = x.isAppointmentDone,
                IsCancel = x.IsCancel,
                StartTime = x.StartTime,
                TotalCount = x.TotalCount,
                FromUserId = x.FromUserId,
                ToUserId = x.ToUserId,
                Status = x.Status
            };
        }
        public static AppointmentTimeSlotViewModel ToViewModel(this AppointmentTimeSlot x)
        {
            if (x == null) return new AppointmentTimeSlotViewModel();
            return new AppointmentTimeSlotViewModel
            {
                StartTime = x.StartTime.HasValue ? x.StartTime.Value.ToString(@"hh\:mm") : null,//x.StartTime.ToString(@"hh\:mm"),
                EndTime = x.EndTime.HasValue ? x.EndTime.Value.ToString(@"hh\:mm") : null, //x.EndTime.ToString(@"hh\:mm"),
                IsBooked = x.IsBooked
            };
        }
    }
}
