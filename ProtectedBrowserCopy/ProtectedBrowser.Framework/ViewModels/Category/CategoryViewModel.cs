using Newtonsoft.Json;
using System;

namespace IotasmartBuild.Framework.ViewModels.Category
{
    public class CategoryViewModel
    {
        [JsonProperty("id")]
        public long CategoryId { get; set; }

        [JsonProperty("name")]
        public string CategoryName { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("createdBy")]
        public long? CreatedBy { get; set; }

        [JsonProperty("createdOn")]
        public DateTimeOffset CreateOn { get; set; }

        [JsonProperty("updatedOn")]
        public DateTimeOffset UpdatedOn { get; set; }

        [JsonProperty("overallCount")]
        public int OverAllCount { get; set; }

        [JsonProperty("updatedBy")]
        public long? UpdatedBy { get; set; }
    }
}
