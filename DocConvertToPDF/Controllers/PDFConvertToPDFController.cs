using DocConvertToPDF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace DocConvertToPDF.Controllers
{
    public class PDFConvertToPDFController : ApiController
    {       
        public HttpResponseMessage Get(string fileUrl, string fileNameAndType)
        {

            //1.获取文档名和类型名
            UrlToDocNameAndType urlToDocNameAndType = new UrlToDocNameAndType();
            string docName = urlToDocNameAndType.urlToDocName(fileNameAndType);
            string typeName = urlToDocNameAndType.urlToTypeName(fileNameAndType);

            //2.下载文档
            string directoryPath = "";
            DirectoryPath dirPath = new DirectoryPath();
            directoryPath = dirPath.getPath();
            WebClient client = new WebClient();
            client.DownloadFile(fileUrl, directoryPath + docName + typeName);

            //3.文档转换
            //string sourcePath = directoryPath + docName + typeName;
            string targetPath = directoryPath + docName + "pdf";
            //OfficeConvertToPDF xlsConvertToPdf = new XLSConvertToPDF(sourcePath, targetPath);
            //xlsConvertToPdf.officeConvertToPdf();

            //4.response

            //var fileInfo = new FileInfo(docPathAndType.targetPath);
            //IHttpActionResult result = !fileInfo.Exists ? (IHttpActionResult)NotFound() : new PDFActionResult(docPathAndType.sourcePath,docPathAndType.targetPath);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(File.ReadAllBytes(targetPath));
            var contentType = MimeMapping.GetMimeMapping(Path.GetExtension(targetPath));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            //5.delete临时文档
            //new FileOperation(sourcePath).deleteFile();
            new FileOperation(targetPath).deleteFile();

            return result;
        }
    }
}
