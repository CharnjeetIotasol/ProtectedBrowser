using ProtectedBrowser.DBRepository.Directory;
using ProtectedBrowser.Domain.Directory;
using ProtectedBrowser.Service.FileGroup;
using ProtectedBrowser.Service.Upload;
using ProtectedBrowser.Service.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Directory
{
    public class DirectoryService : IDirectoryService
    {	
        public DirectoryDBService _directoryDBService;
        private IXmlService _xmlService;
        private IFileGroupService _fileGroupService;
        public DirectoryService(IFileGroupService fileGroupService, IXmlService xmlService)
        {
            _directoryDBService = new DirectoryDBService();
            _fileGroupService = fileGroupService;
            _xmlService = xmlService;
        }
        public long DirectoryInsert(DirectoryModel model)
        {
            var id = _directoryDBService.DirectoryInsert(model);
            return id;
        }

        public void DirectoryUpdate(DirectoryModel model)
        {
            _directoryDBService.DirectoryUpdate(model);
            
        }

        public List<DirectoryModel> SelectDirectory(long? directoryId, bool? isActive = null, int? next = null, int? offset = null)
        {
            var response= _directoryDBService.SelectDirectory(directoryId, isActive, next, offset);
           
			response.ForEach(x =>
            {
            });
            return response;
        }
    }
}
