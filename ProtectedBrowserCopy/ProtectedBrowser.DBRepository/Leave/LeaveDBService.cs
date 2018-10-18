using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.Leave
{
    public class LeaveDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }
        public long LeaveInsert(LeaveModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.LeaveInsert(model.CreatedBy, model.StartDate, model.EndDate, model.StartTime, model.EndTime, model.Type, model.Description, model.UserId).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }
        }
        public void LeaveUpdate(LeaveModel model)
        {
            using (var dbctx = DbContext)
            {
                dbctx.LeaveUpdate(model.Id, model.UpdatedBy, model.UpdatedOn, model.IsDeleted, model.IsActive, model.StartDate, model.EndDate,  model.StartTime, model.EndTime, model.Type, model.Description, model.UserId);
            }
        }
        public List<LeaveModel> LeaveSelect(SearchParam param)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.LeaveSelect(param.Id, param.UserId, param.AppointmentDate, param.Next, param.Offset).Select(x => new LeaveModel
                {
                    Id = x.Id,
                    CreatedBy = x.CreatedBy,
                    UpdatedBy = x.UpdatedBy,
                    CreatedOn = x.CreatedOn,
                    UpdatedOn = x.UpdatedOn,
                    IsDeleted = x.IsDeleted,
                    IsActive = x.IsActive,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Type = x.Type,
                    Description = x.Description,
                    UserId = x.UserId,
                    TotalCount = x.overall_count.GetValueOrDefault(),
                    FullName = x.FirstName + " " + x.LastName
                }).ToList();
            }
        }
    }
}
