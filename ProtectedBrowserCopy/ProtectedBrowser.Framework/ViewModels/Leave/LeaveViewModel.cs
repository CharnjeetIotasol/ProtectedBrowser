using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.Leave
{
    public class LeaveViewModel
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("createdBy")]
        public long? CreatedBy { get; set; }
        [JsonProperty("updatedBy")]
        public long? UpdatedBy { get; set; }
        [JsonProperty("createdOn")]
        public DateTimeOffset? CreatedOn { get; set; }
        [JsonProperty("updatedOn")]
        public DateTimeOffset? UpdatedOn { get; set; }
        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
        [JsonProperty("startDate")]
        public DateTimeOffset? StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTimeOffset? EndDate { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("userId")]
        public long? UserId { get; set; }

        [JsonProperty("startTime")]
        public TimeSpan? StartTime { get; set; }
        [JsonProperty("endTime")]
        public TimeSpan? EndTime { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
}
