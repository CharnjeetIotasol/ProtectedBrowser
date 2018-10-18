using ProtectedBrowser.Common.Extensions;
using ProtectedBrowser.DBRepository.FileGroup;
using ProtectedBrowser.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProtectedBrowser.Service.FileGroup
{
    public class FileGroupService:IFileGroupService
    {
        public FileGroupDBService _fileGroupDBService;
        public FileGroupService()
        {
            _fileGroupDBService = new FileGroupDBService();
        }

        public void FileGroupItemsDelete(long? id, long? updatedBy)
        {
            _fileGroupDBService.FileGroupItemsDelete(id, updatedBy);
        }

        public long FileGroupItemsInsert(FileGroupItemsModel model)
        {
            return _fileGroupDBService.FileGroupItemsInsert(model);
        }

        public void FileGroupItemsInsertXml(long? userId, long? typeId, string attachmentFileXml)
        {
            _fileGroupDBService.FileGroupItemsInsertXml(userId, typeId, attachmentFileXml);
        }

        public List<FileGroupItemsModel> SetPathAndMoveFile(List<FileGroupItemsModel> model, long? id)
        {
            string path = HttpContext.Current.Server.MapPath("\\file");
            string sourecPath = HttpContext.Current.Server.MapPath("\\tempfolder");
            foreach (var item in model)
            {
                if (item.Id == 0 || item.Id == null)
                {
                    item.Path = MoveFileToTarget.MoveFile(sourecPath + "\\" + item.Filename, path + "\\" + id.ToString(), item.OriginalName, id);
                    item.Filename = item.OriginalName;
                    item.Thumbnail = item.Path;
                }
            }
            return model;
        }
        public FileGroupItemsModel SetPathAndMoveSingleFile(FileGroupItemsModel model, long? id)
        {
            string path = HttpContext.Current.Server.MapPath("\\file");
            string sourecPath = HttpContext.Current.Server.MapPath("\\tempfolder");
            model.Path = MoveFileToTarget.MoveFile(sourecPath + "\\" + model.Filename, path + "\\" + id.ToString(), model.OriginalName, id);
            model.Filename = model.OriginalName;
            model.Thumbnail = model.Path;
            return model;
        }
    }
}
