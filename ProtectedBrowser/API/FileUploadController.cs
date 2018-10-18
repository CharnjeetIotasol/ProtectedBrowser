using ProtectedBrowser.Framework.GenericResponse;
using ProtectedBrowser.Framework.ViewModels.Upload;
using ProtectedBrowser.Framework.WebExtensions;
using ProtectedBrowser.Service.FileGroup;
using ProtectedBrowser.Service.Upload;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProtectedBrowser.API
{
    [RoutePrefix("api")]
    public class FileUploadController : ApiController
    {
        private IFileGroupService _fileGroupService;
        private IFileUploadService _fileUploadService;
        private readonly string _uploadPath;
        private readonly MultipartFormDataStreamProvider _streamProvider;
        public FileUploadController(IFileGroupService fileGroupService, IFileUploadService fileUploadService)
        {
            _fileGroupService = fileGroupService;
            _fileUploadService = fileUploadService;
            _uploadPath = UserLocalPath;
            _streamProvider = new MultipartFormDataStreamProvider(_uploadPath);
        }
        private string UserLocalPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("/tempfolder");
                //return the path where you want to upload the file                   
            }
        }
        [Route("file/group/items/upload")]
        [HttpPost]
        public async Task<IEnumerable<FileGroupItemsViewModel>> FileGroupItemsAdd(HttpRequestMessage request)
        {
            var provider = new PhotoMultipartFormDataStreamProvider(_uploadPath);
            await request.Content.ReadAsMultipartAsync(provider);
            var bodylength = request.Content.Headers.ContentLength;
            return _fileUploadService.ProcessDocs(provider.FileData, Convert.ToInt32(bodylength)).Select(x => x.ToViewModel()).ToList();
        }
        [Route("file/group/item/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult FileGroupItemDelete(long? id)
        {
            var userId = User.Identity.GetUserId<long>();
            _fileGroupService.FileGroupItemsDelete(id, userId);
            return Ok("File Deleted".SuccessResponse());
        }
    }
}
