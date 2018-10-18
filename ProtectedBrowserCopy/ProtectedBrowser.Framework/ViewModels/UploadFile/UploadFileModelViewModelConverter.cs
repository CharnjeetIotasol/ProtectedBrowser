using IotasmartBuild.Domain.UploadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.Blog
{
    public static class UploadFileModelViewModelConverter
    {
        public static UploadFileModel ToModel(this UploadFileViewModel x)
        {
            if (x == null) return new UploadFileModel();
            return new UploadFileModel
            {
                Id = x.Id,
                FileName = x.FileName,
                FileUrl = x.FileUrl,
                CreatedOn = x.CreatedOn,
                IsDeleted = x.IsDeleted
            };
        }

        public static UploadFileViewModel ToViewModel(this UploadFileModel x)
        {
            if (x == null) return new UploadFileViewModel();
            return new UploadFileViewModel
            {
                Id = x.Id,
                FileName = x.FileName,
                FileUrl = x.FileUrl,
                CreatedOn = x.CreatedOn,
                IsDeleted = x.IsDeleted
            };
        }
    }
}
