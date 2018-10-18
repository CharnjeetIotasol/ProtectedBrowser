using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.PublicHoliday
{
    public class PublicHolidayViewModel
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("startHolidayDate")]
        public Nullable<System.DateTimeOffset> StartHolidayDate { get; set; }
        [JsonProperty("endHolidayDate")]
        public Nullable<System.DateTimeOffset> EndHolidayDate { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }
        [JsonProperty("createdBy")]
        public Nullable<long> CreatedBy { get; set; }
        [JsonProperty("updatedBy")]
        public Nullable<long> UpdatedBy { get; set; }
        [JsonProperty("createdDate")]
        public System.DateTimeOffset CreatedDate { get; set; }
        [JsonProperty("updatedDate")]
        public System.DateTimeOffset UpdatedDate { get; set; }
        [JsonProperty("createdByName")]
        public string CreatedByName { get; set; }
        [JsonProperty("updatedByName")]
        public string UpdatedByName { get; set; }
        [JsonProperty("startDate")]
        public Nullable<System.DateTimeOffset> StartDate { get; set; }
        [JsonProperty("endDate")]
        public Nullable<System.DateTimeOffset> EndDate { get; set; }
        [JsonProperty("isOnlyView")]
        public Nullable<bool> IsOnlyView { get; set; }
        [JsonProperty("todayDate")]
        public Nullable<System.DateTimeOffset> TodayDate { get; set; }
    }
}
