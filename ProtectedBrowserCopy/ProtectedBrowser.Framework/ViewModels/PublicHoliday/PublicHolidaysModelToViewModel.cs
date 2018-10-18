using ProtectedBrowser.Domain.PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.PublicHoliday
{
    public static class PublicHolidaysModelToViewModel
    {
        public static PublicHolidaysModel ToModel(this PublicHolidayViewModel x)
        {
            if (x == null) return new PublicHolidaysModel();
            return new PublicHolidaysModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                Description = x.Description,
                UpdatedBy = x.UpdatedBy,
                IsDeleted = x.IsDeleted,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                TodayDate = x.TodayDate,
                IsOnlyView = x.IsOnlyView,
                StartHolidayDate = x.StartHolidayDate,
                EndHolidayDate = x.EndHolidayDate

            };
        }

        public static PublicHolidayViewModel ToViewModel(this PublicHolidaysModel x)
        {
            if (x == null) return new PublicHolidayViewModel();
            return new PublicHolidayViewModel
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                Description = x.Description,
                StartHolidayDate = x.StartHolidayDate,
                EndHolidayDate = x.EndHolidayDate,
                UpdatedBy = x.UpdatedBy,
                IsDeleted = x.IsDeleted,
                UpdatedDate = x.UpdatedDate,
                CreatedDate = x.CreatedDate,
                IsOnlyView = x.IsOnlyView
            };
        }
    }
}

