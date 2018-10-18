using ProtectedBrowser.DBRepository.PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.PublicHoliday;

namespace ProtectedBrowser.Service.PublicHoliday
{
    public class PublicHolidayService : IPublicHolidayService
    {
        private PublicHolidayDBService _publicHolidayDBService;
        public PublicHolidayService()
        {
            _publicHolidayDBService = new PublicHolidayDBService();
        }

        public long PublicHolidayInsert(PublicHolidaysModel model)
        {
            return _publicHolidayDBService.PublicHolidayInsert(model);
        }

        public List<PublicHolidaysModel> PublicHolidaysSelect(SearchParam param)
        {
            return _publicHolidayDBService.PublicHolidaysSelect(param);
        }

        public void PublicHolidayUpdate(PublicHolidaysModel model)
        {
            _publicHolidayDBService.PublicHolidayUpdate(model);
        }
    }
}
