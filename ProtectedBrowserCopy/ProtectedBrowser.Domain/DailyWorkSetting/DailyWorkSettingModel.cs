using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.DailyWorkSetting
{
    public class DailyWorkSettingModel
    {
        public int? Id { get; set; }
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public TimeSpan? StartLunchTime { get; set; }
        public TimeSpan? EndLunchTime { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
