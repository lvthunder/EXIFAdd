using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace EXIFAdd
{
    class Excel
    {
        private Microsoft.Office.Interop.Excel.Application xlApp;
        private Microsoft.Office.Interop.Excel.Workbook xlWorkBook;

        public Excel(string xlsFile)
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = true;
            if (xlsFile == "")
            {
                xlWorkBook = xlApp.Workbooks.Add();
            }
            else
            {
                xlWorkBook = xlApp.Workbooks.Open(xlsFile);
            }
            Worksheet xlWorkSheet;
            xlWorkSheet = xlWorkBook.Sheets["Entry Log"];
            List<Dictionary<string,string>> ToDo = new List<Dictionary<string, string>>();
            for (int a = 1; xlWorkSheet.Cells[a, 1] != ""; a++)
            {
                Dictionary<string, string> Image = new Dictionary<string, string>();
                Image.Add("Name", xlWorkSheet.Cells[a, 1]);
                Image.Add("Title", xlWorkSheet.Cells[a, 6]);
                Image.Add("File", xlWorkSheet.Cells[a, 9]);
                ToDo.Add(Image);
            }

        }
     
    }
}
