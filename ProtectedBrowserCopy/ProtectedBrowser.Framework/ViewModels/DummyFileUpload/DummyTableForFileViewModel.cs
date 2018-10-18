using ProtectedBrowser.Framework.ViewModels.Upload;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.DummyFileUpload
{
    public class DummyTableForFileViewModel:BaseViewEntity
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
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("fileGroupItems")]
        public List<FileGroupItemsViewModel> FileGroupItems { get; set; }
        [JsonProperty("fileGroupItem")]
        public FileGroupItemsViewModel FileGroupItem { get; set; }
    }
}
