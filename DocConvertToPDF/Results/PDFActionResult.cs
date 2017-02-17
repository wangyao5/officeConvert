using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DocConvertToPDF.Results
{
    public class PDFActionResult:IHttpActionResult
    {
        private readonly string sourcePath;
        private readonly string _filePath;
        private readonly string _contentType;

        public PDFActionResult(string sourcePath, string targetPath, string contentType = null)
        {
            if (targetPath == null) throw new ArgumentNullException("filePath");

            this.sourcePath = sourcePath;
            _filePath = targetPath;
            _contentType = contentType;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(File.OpenRead(_filePath))
            };

            var contentType = _contentType ?? MimeMapping.GetMimeMapping(Path.GetExtension(_filePath));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            Task < HttpResponseMessage > message = Task.FromResult(response);
            message.ContinueWith(task =>
            {
                //del

                if (File.Exists(sourcePath))
                {
                    File.Delete(sourcePath);
                }
                if (File.Exists(_filePath))
                {
                    File.Delete(_filePath);
                }

            });

            return message;
        }
    }
}