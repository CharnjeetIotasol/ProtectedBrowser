using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Upload
{
    public partial class FileUpload
    {
        public bool IsComplete { get; set; }
        public string FileName { get; set; }

        public string LocalFilePath { get; set; }

        public NameValueCollection FileMetadata { get; set; }
        public string FileId { get; set; }
    }
}
