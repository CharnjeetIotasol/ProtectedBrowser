using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.DummyFileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.DummyFileUpload
{
    public interface IDummyFileUploadService
    {
        long DummyTableForFileInsert(DummyTableForFileModel model);
        void DummyTableForFileUpdate(DummyTableForFileModel model);
        List<DummyTableForFileModel> DummyTableForFileSelect(SearchParam param);
        DummyTableForFileModel DummyTableForFileSelectById(SearchParam param);
        List<DummyTableForFileModel> DummyTableForFileSelectBySingleFile(SearchParam param);
    }
}
