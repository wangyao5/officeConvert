using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocConvertToPDF.Models
{
    public class DocPathAndType
    {
        public string fileUrl { get; set; }
        public string sourcePath { get; set; }
        public string targetPath { get; set; }
        public string docType { get; set; }

    }
}