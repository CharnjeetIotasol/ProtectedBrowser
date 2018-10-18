using ProtectedBrowser.Domain.DailyWorkSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.DailyWorkSetting
{
    public interface IDailyWorkSettingService
    {
        int DailyWorkSettingAction(DailyWorkSettingModel model);
        DailyWorkSettingModel DailyWorkSettingSelect();
    }
}
