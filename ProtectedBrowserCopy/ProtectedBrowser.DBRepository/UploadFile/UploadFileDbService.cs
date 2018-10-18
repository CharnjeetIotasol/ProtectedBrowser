using IotasmartBuild.Domain.UploadFile;
using ProtectedBrowser.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotasmartBuild.DBRepository.UploadFile
{
    public class UploadFileDbService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }

        public long UploadedFileInsert(UploadFileModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.UploadedFileInsert(model.FileName, model.FileUrl).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }

        }

    }
}
