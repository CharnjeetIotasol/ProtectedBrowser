using ProtectedBrowser.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.FileGroup
{
    public interface IFileGroupService
    {
        /// <summary>
        /// Save list of attachement image/file
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="galleryId"></param>
        /// <param name="attachmentFileXml"></param>
        void FileGroupItemsInsertXml(long? userId, long? typeId, string attachmentFileXml);
        /// <summary>
        /// Soft Delete image/file from DB 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedBy"></param>
        void FileGroupItemsDelete(long? id, long? updatedBy);
        /// <summary>
        /// Set the target path and move the file from temp folder to target folder
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns>List Attachment file model</returns>
        List<FileGroupItemsModel> SetPathAndMoveFile(List<FileGroupItemsModel> model, long? userId);
        /// <summary>
        /// Save single file in DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long FileGroupItemsInsert(FileGroupItemsModel model);
        /// <summary>
        /// Set the target path and move the single file from temp folder to target folder
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        FileGroupItemsModel SetPathAndMoveSingleFile(FileGroupItemsModel model, long? id);
    }
}
