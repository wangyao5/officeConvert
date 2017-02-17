using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocConvertToPDF.Models
{
    public class DirectoryPath
    {
        private string _directoryPath = "D:\\temp\\";

        public void setPath(string directoryPath)
        {
            _directoryPath = directoryPath;
        }
        public string getPath()
        {
            return _directoryPath;
        }
    }
}