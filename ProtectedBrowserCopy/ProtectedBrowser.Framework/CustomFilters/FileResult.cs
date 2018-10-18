using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProtectedBrowser.Framework.CustomFilters
{
    public class FileResult : IHttpActionResult
    {
        private readonly string filePath;
        private readonly byte[] fileStream;
        private readonly string contentType;
        readonly string fileName;
        public FileResult(string filePath, string filename = null)
        {
            this.filePath = filePath;
            this.fileName = filename;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                HttpResponseMessage response;
                //if file is returned as file path
                if (!string.IsNullOrEmpty(filePath))
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StreamContent(File.OpenRead(filePath))
                    };
                    var contentType = this.contentType ?? MimeMapping.GetMimeMapping(Path.GetExtension(filePath));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }//else file is returing through byte array
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(fileStream)
                    };
                    response.Content.Headers.ContentType = this.contentType == null ? new MediaTypeHeaderValue("application/pdf") : new MediaTypeHeaderValue(contentType);
                }
                //adding header for custom file name of response
                if (!string.IsNullOrEmpty(fileName))
                {
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };
                }

                return response;
            }, cancellationToken);
        }
    }
}
