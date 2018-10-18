using IotasmartBuild.DBRepository.UploadFile;
using IotasmartBuild.Domain.UploadFile;
using IotasmartBuild.Service.UploadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iotasolProject.Service.UploadFile
{
    public class UploadFileService:IUploadService
    {

        public UploadFileDbService _uploadFileDBService;
        public UploadFileService()
        {
            _uploadFileDBService = new UploadFileDbService();
        }
        public long UploadFileInsert(UploadFileModel model)
        {
            return _uploadFileDBService.UploadedFileInsert(model);
        }

    }
}
