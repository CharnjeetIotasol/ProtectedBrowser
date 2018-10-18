using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Upload
{
    public class FileGroupItemsModel
    {
        public long? Id { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string Filename { get; set; }
        public string MimeType { get; set; }
        public string Thumbnail { get; set; }
        public long? Size { get; set; }
        public string Path { get; set; }
        public string OriginalName { get; set; }
        public string OnServer { get; set; }
        public string Type { get; set; }
        public long? TypeId { get; set; }
        public int TotalCount { get; set; }
    }
}
