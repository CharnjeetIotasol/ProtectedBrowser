using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProtectedBrowser.Domain.Upload;
using System.Web;
using System.IO;
using System.Collections.ObjectModel;

namespace ProtectedBrowser.Service.Upload
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _uploadPath;
        private readonly MultipartFormDataStreamProvider _streamProvider;

        public FileUploadService()
        {
            _uploadPath = UserLocalPath;
            _streamProvider = new MultipartFormDataStreamProvider(_uploadPath);
        }
        public async Task<FileUpload> HandleRequest(HttpRequestMessage request)
        {
            await request.Content.ReadAsMultipartAsync(_streamProvider);
            return null;
        }

        #region Private implementation

        public List<FileUpload> ProcessFile(Collection<MultipartFileData> FileData)
        {
            var photos = new List<FileUpload>();
            Uri myuri = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            string pathQuery = myuri.PathAndQuery;
            string hostName = myuri.ToString().Replace(pathQuery, "");
            foreach (var file in FileData)
            {
                var FileName = Path.GetFileName(file.LocalFileName);
                var FullPath = Path.GetFullPath(file.LocalFileName);
                string lastFolderName = Path.GetFileName(Path.GetDirectoryName(FullPath));
                var localFileInfo = new FileInfo(file.LocalFileName);
                string guidFileName = Guid.NewGuid().ToString() + localFileInfo.Name;
                File.Move(localFileInfo.FullName, Path.Combine(localFileInfo.DirectoryName, guidFileName));

                photos.Add(new FileUpload()
                {
                    //IsComplete = chunkMetaData.IsLastChunk,
                    FileName = guidFileName,
                    LocalFilePath = hostName + "/" + lastFolderName + "/" + guidFileName,
                    //FileMetadata = _streamProvider.FormData
                });
            }
            return photos;
        }

        private FileUpload ProcessChunk(HttpRequestMessage request)
        {
            //use the unique identifier sent from client to identify the file
            FileChunkMetaData chunkMetaData = request.GetChunkMetaData();
            string filePath = Path.Combine(_uploadPath, string.Format("{0}.temp", chunkMetaData.ChunkIdentifier));

            //append chunks to construct original file
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate | FileMode.Append))
            {
                var localFileInfo = new FileInfo(LocalFileName);
                var localFileStream = localFileInfo.OpenRead();

                localFileStream.CopyToAsync(fileStream);
                fileStream.FlushAsync();

                fileStream.Close();
                localFileStream.Close();

                //delete chunk
                localFileInfo.Delete();
            }

            return new FileUpload()
            {
                IsComplete = chunkMetaData.IsLastChunk,
                FileName = OriginalFileName,
                LocalFilePath = chunkMetaData.IsLastChunk ? filePath : null,
                FileMetadata = _streamProvider.FormData
            };

        }

        public List<FileGroupItemsModel> ProcessDocs(Collection<MultipartFileData> FileData, int length)
        {

            var attachment = new List<FileGroupItemsModel>();
            Uri myuri = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            string pathQuery = myuri.PathAndQuery;
            string hostName = myuri.ToString().Replace(pathQuery, "");
            foreach (var file in FileData)
            {
                var FileName = Path.GetFileName(file.LocalFileName);
                var FullPath = Path.GetFullPath(file.LocalFileName);
                string lastFolderName = Path.GetFileName(Path.GetDirectoryName(FullPath));
                var localFileInfo = new FileInfo(file.LocalFileName);
                string guidFileName = Guid.NewGuid().ToString() + localFileInfo.Name;
                File.Move(localFileInfo.FullName, Path.Combine(localFileInfo.DirectoryName, guidFileName));
                string[] fileType = localFileInfo.Name.Split('.');
                attachment.Add(new FileGroupItemsModel()
                {
                    Filename = guidFileName,
                    Path = hostName + "/" + lastFolderName + "/" + guidFileName,
                    MimeType = fileType[fileType.Length - 1],//file.Headers.ContentType.MediaType,
                    Size = length,//file.Headers.ContentLength,
                    OriginalName = localFileInfo.Name
                });
            }
            return attachment;
        }

        #endregion

        #region Properties

        private string LocalFileName
        {
            get
            {
                MultipartFileData fileData = _streamProvider.FileData.FirstOrDefault();
                return fileData.LocalFileName;
            }
        }

        private string OriginalFileName
        {
            get
            {
                MultipartFileData fileData = _streamProvider.FileData.FirstOrDefault();
                return fileData.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            }
        }

        private string UserLocalPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("/tempfolder");
                //return the path where you want to upload the file                   
            }
        }

        #endregion    
    }

    public static class HttpRequestMessageExtensions
    {
        public static bool IsChunkUpload(this HttpRequestMessage request)
        {
            return request.Content.Headers.ContentRange != null;
        }

        public static FileChunkMetaData GetChunkMetaData(this HttpRequestMessage request)
        {
            return new FileChunkMetaData()
            {
                ChunkIdentifier = request.Headers.Contains("X-DS-Identifier") ? request.Headers.GetValues("X-File-Identifier").FirstOrDefault() : null,
                ChunkStart = request.Content.Headers.ContentRange.From,
                ChunkEnd = request.Content.Headers.ContentRange.To,
                TotalLength = request.Content.Headers.ContentRange.Length
            };
        }
    }
}
