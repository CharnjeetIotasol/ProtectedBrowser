using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.Appointment;
using ProtectedBrowser.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.Appointment
{
    public class AppointmentDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }
        public long AppointmentInsert(AppointmentModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.AppointmentInsert(model.CreatedBy, model.AppointmentDate, model.Note, model.StartTime, model.EndTime, model.ToUserId, model.FromUserId, model.Status).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }
        }
        public void AppointmentUpdate(AppointmentModel model)
        {
            using (var dbctx = DbContext)
            {
                dbctx.AppointmentUpdate(model.Id, model.UpdatedBy, model.UpdatedOn, model.IsActive, model.AppointmentDate, model.Note, model.ToUserId, model.FromUserId, model.IsCancel, model.CancellationReason, model.StartTime, model.EndTime, model.isAppointmentDone, model.Status);
            }
        }
        public List<AppointmentModel> AppointmentSelect(SearchParam param)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.AppointmentSelect(param.Id, param.ToUserId, param.FromUserId, param.AppointmentDate, param.StartDate, param.EndDate, param.Next, param.Offset).Select(x => new AppointmentModel
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
                    Status = x.Status,
                    CancellationReason = x.CancellationReason,
                    EndTime = x.EndTime,
                    IsCancel = x.IsCancel,
                    StartTime = x.StartTime,
                    isAppointmentDone = x.isAppointmentDone,
                    TotalCount = x.overall_count.GetValueOrDefault(),
                    ToUserId = x.ToUserId,
                    FromUserId = x.FromUserId,
                    FromUser = new UserModel
                    {
                        Id = x.FromUserId,
                        FirstName = x.FromUserFirstName,
                        LastName = x.FromUserLastName,
                        PhoneNumber = x.FromUserPhoneNumber
                    },
                    ToUser = new UserModel
                    {
                        Id = x.ToUserId,
                        FirstName = x.ToUserFirstName,
                        LastName = x.ToUserLastName,
                        PhoneNumber = x.ToUserPhoneNumber
                    },
                    CreatedUser = new Domain.CreatedUserModel
                    {
                        UserId = x.CreatedBy,
                        FirstName = x.CreatedByFirstName,
                        LastName = x.CreatedByLastName,
                        PhoneNumber = x.CreatedByPhoneNumber
                    },
                    UpdatedUser = new Domain.UpdatedUserModel
                    {
                        UserId = x.UpdatedBy,
                        FirstName = x.UpdatedByFirstName,
                        LastName = x.UpdatedByLastName,
                        PhoneNumber = x.UpdatedByPhoneNumber
                    },
                }).ToList();
            }
        }
    }
}
