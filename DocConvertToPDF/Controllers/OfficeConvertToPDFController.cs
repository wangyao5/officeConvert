using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DocConvertToPDF.Models;
using DocConvertToPDF.Results;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Web;
using System.Net.Http.Headers;

namespace DocConvertToPDF.Controllers
{
    public class OfficeConvertToPDFController : ApiController
    {
        public HttpResponseMessage Get(string fileUrl) {

            //1.解析url
            UrlToDocNameAndType urlToDocNameAndType = new UrlToDocNameAndType();
            string docAndTypeName = urlToDocNameAndType.urlToDocNameAndType(fileUrl);
            string docName = urlToDocNameAndType.urlToDocName(docAndTypeName);
            string typeName = urlToDocNameAndType.urlToTypeName(docAndTypeName);

            //2.下载文档
            string directoryPath = "";
            DirectoryPath dirPath = new DirectoryPath();
            directoryPath = dirPath.getPath();
            WebClient client = new WebClient();
            client.DownloadFile(fileUrl, directoryPath + docName+typeName);

            //3.文档转换
            string sourcePath = directoryPath + docName + typeName;
            string targetPath = directoryPath + docName + "pdf";
            switch (typeName)
            {
                case "docx":
                case "doc" :
                case "txt" :
                    OfficeConvertToPDF docConvertToPdf = new DOCConvertToPDF(sourcePath,targetPath);
                    docConvertToPdf.officeConvertToPdf();
                    break;
                case "xlsx":
                    OfficeConvertToPDF xlsConvertToPdf = new XLSConvertToPDF(sourcePath,targetPath);
                    xlsConvertToPdf.officeConvertToPdf();
                    break;
                case "pptx":
                case "ppt":
                    OfficeConvertToPDF pptConvertToPdf = new PPTConvertToPDF(sourcePath,targetPath);
                    pptConvertToPdf.officeConvertToPdf();
                    break;
            }

            //4.response

            //var fileInfo = new FileInfo(docPathAndType.targetPath);
            //IHttpActionResult result = !fileInfo.Exists ? (IHttpActionResult)NotFound() : new PDFActionResult(docPathAndType.sourcePath,docPathAndType.targetPath);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(File.ReadAllBytes(targetPath));
            var contentType = MimeMapping.GetMimeMapping(Path.GetExtension(targetPath));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            //5.delete临时文档
            new FileOperation(sourcePath).deleteFile();
            new FileOperation(targetPath).deleteFile();
            
            return result;
        }
    }
}
