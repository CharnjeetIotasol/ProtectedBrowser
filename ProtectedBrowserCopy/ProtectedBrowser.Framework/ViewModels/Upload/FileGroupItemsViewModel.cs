using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.Upload
{
    public class FileGroupItemsViewModel
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
        [JsonProperty("filename")]
        public string Filename { get; set; }
        [JsonProperty("mimeType")]
        public string MimeType { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("size")]
        public long? Size { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("originalName")]
        public string OriginalName { get; set; }
        [JsonProperty("onServer")]
        public string OnServer { get; set; }
        [JsonProperty("typeId")]
        public long? TypeId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
