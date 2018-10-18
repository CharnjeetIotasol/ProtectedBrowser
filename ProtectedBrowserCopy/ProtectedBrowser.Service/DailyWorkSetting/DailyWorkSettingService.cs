using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtectedBrowser.Domain.DailyWorkSetting;
using ProtectedBrowser.DBRepository.DailyWorkSetting;

namespace ProtectedBrowser.Service.DailyWorkSetting
{
    public class DailyWorkSettingService : IDailyWorkSettingService
    {
        private DailyWorkSettingDBService _dailyWorkSettingDBService;
        public DailyWorkSettingService()
        {
            _dailyWorkSettingDBService = new DailyWorkSettingDBService();
        }
        public int DailyWorkSettingAction(DailyWorkSettingModel model)
        {
            return _dailyWorkSettingDBService.DailyWorkSettingAction(model);
        }

        public DailyWorkSettingModel DailyWorkSettingSelect()
        {
            return _dailyWorkSettingDBService.DailyWorkSettingSelect();
        }
    }
}
