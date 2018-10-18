using ProtectedBrowser.DBRepository.DummyFileUpload;
using System.Collections.Generic;
using System.Linq;
using ProtectedBrowser.Domain.DummyFileUpload;
using ProtectedBrowser.Service.Xml;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Service.FileGroup;
using ProtectedBrowser.Common.Extensions;

namespace ProtectedBrowser.Service.DummyFileUpload
{
    public class DummyFileUploadService:IDummyFileUploadService
    {
        private DummyFileUploadDBService _dummyFileUploadDBService;
        private IXmlService _xmlService;
        private IFileGroupService _fileGroupService;
        public DummyFileUploadService(IXmlService xmlService, IFileGroupService fileGroupService)
        {
            _xmlService = xmlService;
            _fileGroupService = fileGroupService;
            _dummyFileUploadDBService = new DummyFileUploadDBService();
        }

        public long DummyTableForFileInsert(DummyTableForFileModel model)
        {
            var id= _dummyFileUploadDBService.DummyTableForFileInsert(model);
            if (model.FileGroupItems != null)
            {
                //set target path and move file from target location
                model.FileGroupItems = _fileGroupService.SetPathAndMoveFile(model.FileGroupItems, id);
                //Save list of file in our DB
                _fileGroupService.FileGroupItemsInsertXml(model.CreatedBy, id, model.FileGroupItems.XmlSerialize());
            }
            if (model.FileGroupItem != null)
            {
                //set target path and move file from target location
                model.FileGroupItem = _fileGroupService.SetPathAndMoveSingleFile(model.FileGroupItem, id);
                //Save list of file in our DB
                _fileGroupService.FileGroupItemsInsert(model.FileGroupItem);
            }
            return id;
        }

        public List<DummyTableForFileModel> DummyTableForFileSelect(SearchParam param)
        {
            var DummyTableForFiles = _dummyFileUploadDBService.DummyTableForFileSelect(param);
            DummyTableForFiles.ForEach(x => 
            {
                x.FileGroupItems = _xmlService.GetFileGroupItemsByXml(x.FileGroupItemsXml);
            });
            return DummyTableForFiles;
        }

        public DummyTableForFileModel DummyTableForFileSelectById(SearchParam param)
        {
            var DummyTableForFile = _dummyFileUploadDBService.DummyTableForFileSelect(param).FirstOrDefault();
            DummyTableForFile.FileGroupItem = _xmlService.GetFileGroupItemsByXml(DummyTableForFile.FileGroupItemsXml).FirstOrDefault();
            return DummyTableForFile;
        }

        public void DummyTableForFileUpdate(DummyTableForFileModel model)
        {
            _dummyFileUploadDBService.DummyTableForFileUpdate(model);
            if (model.FileGroupItems != null)
            {
                //set target path and move file from target location
                model.FileGroupItems = _fileGroupService.SetPathAndMoveFile(model.FileGroupItems, model.Id);
                //Save list of file in our DB
                _fileGroupService.FileGroupItemsInsertXml(model.UpdatedBy, model.Id, model.FileGroupItems.XmlSerialize());
            }
            if (model.FileGroupItem != null)
            {
                //set target path and move file from target location
                model.FileGroupItem = _fileGroupService.SetPathAndMoveSingleFile(model.FileGroupItem, model.Id);
                //Save list of file in our DB
                _fileGroupService.FileGroupItemsInsertXml(model.UpdatedBy, model.Id, model.FileGroupItem.XmlSerialize());
            }
        }

        public List<DummyTableForFileModel> DummyTableForFileSelectBySingleFile(SearchParam param)
        {
            var DummyTableForFiles = _dummyFileUploadDBService.DummyTableForFileSelect(param);
            DummyTableForFiles.ForEach(x =>
            {
                x.FileGroupItem = _xmlService.GetFileGroupItemsByXml(x.FileGroupItemsXml).FirstOrDefault();
            });
            return DummyTableForFiles;
        }
    }
}
