using ProtectedBrowser.Domain.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.Leave
{
    public static class LeaveModelViewModelConverter
    {
        public static LeaveViewModel ToViewModel(this LeaveModel x)
        {
            if (x == null) return new LeaveViewModel();
            return new LeaveViewModel
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
                Description = x.Description,
                UserId = x.UserId,
                TotalCount = x.TotalCount,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Type = x.Type,
                FullName = x.FullName
            };
        }

        public static LeaveModel ToModel(this LeaveViewModel x)
        {
            if (x == null) return new LeaveModel();
            return new LeaveModel
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
                Description = x.Description,
                UserId = x.UserId,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Type = x.Type
            };
        }
    }
}
