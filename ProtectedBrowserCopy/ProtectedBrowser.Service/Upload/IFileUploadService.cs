using ProtectedBrowser.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Upload
{
    public interface IFileUploadService
    {
        Task<FileUpload> HandleRequest(HttpRequestMessage request);

        List<FileUpload> ProcessFile(Collection<MultipartFileData> FileData);

        List<FileGroupItemsModel> ProcessDocs(Collection<MultipartFileData> FileData, int length);

    }
}
