using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtectedBrowser.Domain.Upload;

namespace ProtectedBrowser.Domain.Directory
{
    public class DirectoryModel
    {
        public long? Id { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string RootPath { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int TotalCount { get; set; }
    }
    public class RawData
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Ext { get; set; }
    }

    public class GetFilesFolder
    {
        public List<RawData> Files { get; set; }
        public List<RawData> Folders { get; set; }
    }

    public class GetRootPath
    {
        public string RootPath { get; set; }
    }
}
