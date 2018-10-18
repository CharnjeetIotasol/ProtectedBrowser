using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.PublicHoliday
{
    public interface IPublicHolidayService
    {
        long PublicHolidayInsert(PublicHolidaysModel model);
        void PublicHolidayUpdate(PublicHolidaysModel model);
        List<PublicHolidaysModel> PublicHolidaysSelect(SearchParam param);
    }
}
