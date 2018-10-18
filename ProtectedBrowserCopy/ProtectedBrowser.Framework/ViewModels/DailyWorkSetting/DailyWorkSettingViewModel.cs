using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.DailyWorkSetting
{
    public class DailyWorkSettingViewModel
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("sunday")]
        public bool? Sunday { get; set; }
        [JsonProperty("monday")]
        public bool? Monday { get; set; }
        [JsonProperty("tuesday")]
        public bool? Tuesday { get; set; }
        [JsonProperty("wednesday")]
        public bool? Wednesday { get; set; }
        [JsonProperty("thursday")]
        public bool? Thursday { get; set; }
        [JsonProperty("friday")]
        public bool? Friday { get; set; }
        [JsonProperty("saturday")]
        public bool? Saturday { get; set; }
        [JsonProperty("startTime")]
        public TimeSpan? StartTime { get; set; }
        [JsonProperty("endTime")]
        public TimeSpan? EndTime { get; set; }
        [JsonProperty("startLunchTime")]
        public TimeSpan? StartLunchTime { get; set; }
        [JsonProperty("endLunchTime")]
        public TimeSpan? EndLunchTime { get; set; }
        [JsonProperty("createdBy")]
        public long? CreatedBy { get; set; }
        [JsonProperty("updatedBy")]
        public long? UpdatedBy { get; set; }
    }
}
