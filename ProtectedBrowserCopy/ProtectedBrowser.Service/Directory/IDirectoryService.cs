using ProtectedBrowser.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Directory
{
    public interface IDirectoryService
    {
        /// <summary>
        /// used for insertion directory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long DirectoryInsert(DirectoryModel model);
        
        /// <summary>
        /// Method for update directory
        /// </summary>
        /// <param name="model"></param>
        void DirectoryUpdate(DirectoryModel model);

        /// <summary>
        /// use to select all directory or select directory by id 
        /// </summary>
        /// <param name="directoryId"></param>
        /// <param name="isActive"></param>
        /// <param name="next"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        List<DirectoryModel> SelectDirectory(long? directoryId, bool? isActive = null, int? next = null, int? offset = null);
    }
}
