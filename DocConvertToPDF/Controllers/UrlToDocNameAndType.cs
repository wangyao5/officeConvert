using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocConvertToPDF.Controllers
{
    public class UrlToDocNameAndType
    {
        


        public string urlToDocNameAndType(string fileUrl)
        {
            string docAndtypeName = "";
            docAndtypeName = System.IO.Path.GetFileName(fileUrl);
            return docAndtypeName;
        }
        public string urlToDocName(string docAndtypeName)
        {
            
            string docName = "";

            string[] sArray = docAndtypeName.Split('.');
            for (int i = 0; i < sArray.Length - 1; i++)
            {
                docName = docName + sArray[i] + ".";    //最后多了一个‘.’
            }
            return docName;
        }

        public string urlToTypeName(string docAndtypeName)
        {
            string typeName = "";
            string[] sArray = docAndtypeName.Split('.');
            typeName = sArray[sArray.Length - 1];
            return typeName;
        }
    }
}