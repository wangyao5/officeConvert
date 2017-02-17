using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace DocConvertToPDF.Controllers
{
    public class PPTConvertToPDF : OfficeConvertToPDF
    {
        private string _sourcePath;
        private string _targetPath;

        public PPTConvertToPDF(string sourcePath, string targetPath)
        {
            _sourcePath = sourcePath;
            _targetPath = targetPath;
        }

        public bool officeConvertToPdf()
        {
            bool result = false;
            PowerPoint.PpSaveAsFileType targetFileType = PowerPoint.PpSaveAsFileType.ppSaveAsPDF;
            object missing = Type.Missing;
            PowerPoint.Application application = null;
            PowerPoint.Presentation persentation = null;
            try
            {
                application = new PowerPoint.Application();
                persentation = application.Presentations.Open(_sourcePath, Microsoft.Office.Core.MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                persentation.SaveAs(_targetPath, targetFileType, Microsoft.Office.Core.MsoTriState.msoTrue);

                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (persentation != null)
                {
                    persentation.Close();
                    persentation = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }
    }
}