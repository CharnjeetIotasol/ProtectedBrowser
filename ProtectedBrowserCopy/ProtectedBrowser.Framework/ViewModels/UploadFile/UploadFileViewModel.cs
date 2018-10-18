using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.Blog
{
    public class UploadFileViewModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("fileUrl")]
        public string FileUrl { get; set; }

        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("createdOn")]
        public Nullable<System.DateTimeOffset> CreatedOn { get; set; }
    }
}
