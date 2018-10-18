using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.PublicHoliday
{
    public class PublicHolidayDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }
        public long PublicHolidayInsert(PublicHolidaysModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.PublicHolidaysInsert(model.StartHolidayDate, model.EndHolidayDate, model.Description, model.CreatedBy).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }
        }
        public void PublicHolidayUpdate(PublicHolidaysModel model)
        {
            using (var dbctx = DbContext)
            {
                dbctx.PublicHolidaysUpdate(model.StartHolidayDate, model.EndHolidayDate, model.Description, model.UpdatedBy, model.IsDeleted, model.Id);
            }
        }
        public List<PublicHolidaysModel> PublicHolidaysSelect(SearchParam param)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.PublicHolidaysSelect(param.Id, param.ToDayDate, param.StartDate, param.EndDate).Select(x => new PublicHolidaysModel
                {
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    Id = x.Id,
                    IsDeleted = x.IsDeleted,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                    IsOnlyView = x.IsOnlyView,
                    StartHolidayDate = x.StartHoliday,
                    EndHolidayDate = x.EndHoliday
                }).ToList();
            }
        }
    }
}
