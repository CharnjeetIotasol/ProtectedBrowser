using IotasmartBuild.Framework.ViewModels.Category;
using ProtectedBrowser.Framework.ViewModels.Upload;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotasmartBuild.Framework.ViewModels.Blog
{
    public class BlogViewModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("categoryId")]
        public Nullable<long> CategoryId { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("createdOn")]
        public Nullable<System.DateTimeOffset> CreatedOn { get; set; }

        [JsonProperty("createdBy")]
        public Nullable<long> CreatedBy { get; set; }

        [JsonProperty("updatedOn")]
        public Nullable<System.DateTimeOffset> UpdatedOn { get; set; }

        [JsonProperty("updatedBy")]
        public Nullable<long> UpdatedBy { get; set; }

        [JsonProperty("overall_count")]
        public Nullable<int> overall_count { get; set; }

        [JsonProperty("category")]
        public CategoryViewModel Category { get; set; }

        [JsonProperty("fileGroupItem")]
        public FileGroupItemsViewModel FileGroupItem { get; set; }

        [JsonProperty("fileId")]
        public long? FileId { get; set; }

        [JsonProperty("fileUrl")]
        public string FileUrl { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }


    }
}
