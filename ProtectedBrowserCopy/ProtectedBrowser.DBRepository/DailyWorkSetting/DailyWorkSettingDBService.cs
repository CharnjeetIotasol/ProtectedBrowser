using ProtectedBrowser.Domain.DailyWorkSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.DailyWorkSetting
{
    public class DailyWorkSettingDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }
        public int DailyWorkSettingAction(DailyWorkSettingModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.DailyWorkSettingAction(model.Sunday, model.Monday, model.Tuesday, model.Wednesday, model.Thursday, model.Friday, model.Saturday, model.StartTime, model.EndTime, model.StartLunchTime, model.EndLunchTime, model.CreatedBy, model.Id).FirstOrDefault();
                return Convert.ToInt32(id ?? 0);
            }
        }
        public DailyWorkSettingModel DailyWorkSettingSelect()
        {
            using (var dbctx = DbContext)
            {
                return dbctx.DailyWorkSettingSelect().Select(x => new DailyWorkSettingModel
                {
                    CreatedBy = x.CreatedBy,
                    EndLunchTime = x.EndLunchTime,
                    EndTime = x.EndTime,
                    Friday = x.Friday,
                    Id = x.Id,
                    Monday = x.Monday,
                    Saturday = x.Satureday,
                    StartLunchTime = x.StartLunchTime,
                    StartTime = x.StartTime,
                    Sunday = x.Sunday,
                    Thursday = x.Thursday,
                    Tuesday = x.Tuesday,
                    UpdatedBy = x.UpdatedBy,
                    Wednesday = x.Wednesday,
                    UpdatedDate = x.UpdatedDate
                }).FirstOrDefault();
            }
        }
    }
}
