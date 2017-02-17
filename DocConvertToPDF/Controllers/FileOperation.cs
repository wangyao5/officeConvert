using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DocConvertToPDF.Controllers
{
    public class FileOperation
    {
        private string _filePath;

        public FileOperation(string filePath)
        {
            _filePath = filePath;
        }

        public void deleteFile()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}