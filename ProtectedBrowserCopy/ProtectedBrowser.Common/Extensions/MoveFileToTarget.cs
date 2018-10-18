using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Common.Extensions
{
    public static class MoveFileToTarget
    {
        public static string MoveFile(string sourcePath, string targetPath, string fileName, long? id)
        {

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            Uri myuri = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            string pathQuery = myuri.PathAndQuery;
            string hostName = myuri.ToString().Replace(pathQuery, "");

            // Use Path class to manipulate file and directory paths.
            //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (System.IO.File.Exists(destFile))
            {
                fileName = Guid.NewGuid().ToString() + fileName;
                destFile = System.IO.Path.Combine(targetPath, fileName);
            }
            // To move a file or folder to a new location:
            System.IO.File.Move(sourcePath, destFile);
            targetPath = hostName + "/" + "file/" + id + "/" + fileName;
            return targetPath;
        }
    }
}
