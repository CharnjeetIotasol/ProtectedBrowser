using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotasmartBuild.Domain.UploadFile
{
    public class UploadFileModel
    {

        public long Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public Nullable<System.DateTimeOffset> CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
