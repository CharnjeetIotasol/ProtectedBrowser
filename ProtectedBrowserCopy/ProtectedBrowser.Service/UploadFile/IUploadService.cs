using IotasmartBuild.Domain.UploadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotasmartBuild.Service.UploadFile
{
    public interface IUploadService
    {

        long UploadFileInsert(UploadFileModel model);

    }
}
