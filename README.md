# officeConvert
office文件转换为pdf服务

统一接口：
http://10.154.34.121/api/OfficeConvertToPDF?fileUrl=” ”

参数：
fileUrl ：源文件地址;

示例：
http://10.154.34.121/api/OfficeConvertToPDF?fileUrl=http://10.154.34.121/a.docx


独立接口：

1.	Word转pdf接口：
http://10.154.34.121/api/DocConvertToPDF?fileUrl=“”&fileNameAndType=””

参数：
fileUrl : 源文件地址;
fileNameAndType：源文件名称和类型;
        
        示例：
            http://10.154.34.121/api/DocConvertToPDF?fileUrl=http://10.154.34.121/a.docx &fileNameAndType=a.docx

2.	Excel转pdf接口：
    http://10.154.34.121/api/XLSConvertToPDF?fileUrl=“”&fileNameAndType=””

参数：
fileUrl : 源文件地址;
fileNameAndType：源文件名称和类型;
        
        示例：
            http://10.154.34.121/api/XLSConvertToPDF?fileUrl=http://10.154.34.121/a.xlsx &fileNameAndType=a.xlsx

3.	ppt转pdf接口：
    http://10.154.34.121/api/PPTConvertToPDF?fileUrl=“”&fileNameAndType=””

参数：
fileUrl : 源文件地址;
fileNameAndType：源文件名称和类型;
        
        示例：
            http://10.154.34.121/api/PPTConvertToPDF?fileUrl=http://10.154.34.121/a.pptx &fileNameAndType=a.pptx
4.	pdf转pdf
    http://10.154.34.121/api/PDFConvertToPDF?fileUrl=“”&fileNameAndType=””

参数：
fileUrl : 源文件地址;
fileNameAndType：源文件名称和类型;
        
        示例：
            http://10.154.34.121/api/PDFConvertToPDF?fileUrl=http://10.154.34.121/a.pdf &fileNameAndType=a.pdf


