using ProtectedBrowser.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.FileGroup
{
    public class FileGroupDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }

        public void FileGroupItemsInsertXml(long? userId, long? typeId, string attachmentFile)
        {
            using (var dbctx = DbContext)
            {
                dbctx.FileGroupItemsInsertXml(userId, typeId, attachmentFile);
            }
        }
        public long FileGroupItemsInsert(FileGroupItemsModel model)
        {
            using (var dbctx = DbContext)
            {
                var id = dbctx.FileGroupItemInsert(model.CreatedBy, model.Filename, model.MimeType, model.Thumbnail, model.Size, model.Path, model.OriginalName, model.OnServer, model.TypeId, model.Type).FirstOrDefault();
                return Convert.ToInt64(id ?? 0);
            }
        }
        public void FileGroupItemsDelete(long? id, long? updatedBy)
        {
            using (var dbctx = DbContext)
            {
                dbctx.FileGroupItemsDelete(id, updatedBy);
            }
        }
    }
}
