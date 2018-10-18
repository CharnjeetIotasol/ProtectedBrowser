using ProtectedBrowser.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.DummyFileUpload
{
    public class DummyTableForFileModel:BaseEntity
    {
        public long? Id { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public string FileGroupItemsXml { get; set; }
        public List<FileGroupItemsModel> FileGroupItems { get; set; }
        public FileGroupItemsModel FileGroupItem { get; set; }
    }
}
