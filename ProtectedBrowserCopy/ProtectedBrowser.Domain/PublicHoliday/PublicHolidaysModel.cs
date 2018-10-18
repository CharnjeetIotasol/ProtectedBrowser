using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.PublicHoliday
{
    public class PublicHolidaysModel
    {
        public long? Id { get; set; }
        public Nullable<System.DateTimeOffset> StartHolidayDate { get; set; }
        public Nullable<System.DateTimeOffset> EndHolidayDate { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public System.DateTimeOffset CreatedDate { get; set; }
        public System.DateTimeOffset UpdatedDate { get; set; }
        public Nullable<System.DateTimeOffset> StartDate { get; set; }
        public Nullable<System.DateTimeOffset> EndDate { get; set; }
        public Nullable<bool> IsOnlyView { get; set; }
        public Nullable<System.DateTimeOffset> TodayDate { get; set; }
    }
}
