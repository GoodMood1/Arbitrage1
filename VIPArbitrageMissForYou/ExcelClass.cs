using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Collections.ObjectModel;

namespace VIPArbitrageMissForYou
{
    public class ExcelClass
    {
        public void getExcelFile(string path, ObservableCollection<double> _arbres1, ObservableCollection<double> _arbres2, ObservableCollection<string> _arbres3, ObservableCollection<string> _arbres4)
        {
            try {
                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                for (int i = 1; i <= 4; i++)
                {
                    xlRange.Cells[1, i].Font.Bold = true;
                    xlRange.Cells[1, i].Interior.Color = Color.FromArgb(0, 186, 255, 105);
                    xlRange.Cells[1, i].Interior.TintAndShade = 0;
                    xlRange.Cells[1, i].Interior.PatternTintAndShade = 0;
                    xlRange.Columns[i].ColumnWidth = 18;
                }
                xlRange.Cells[1, 1] = "Exchanges";
                xlRange.Cells[1, 2] = "Cryptocurrency";
                xlRange.Cells[1, 3] = "Price";
                xlRange.Cells[1, 4] = "Profit";
                for (int j = 1; _arbres1.Count >= j; j++)
                {
                    xlRange.Cells[j + 1, 1] = _arbres4[j - 1];
                    xlRange.Cells[j + 1, 2] = _arbres3[j - 1];
                    xlRange.Cells[j + 1, 3] = _arbres2[j - 1];
                    xlRange.Cells[j + 1, 4] = _arbres1[j - 1];
                }
                xlWorkbook.SaveAs(path);
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad
                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);
                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                UpgradeMessageBox box = new UpgradeMessageBox("Excel file created successfully");
                box.Show();
            }
            catch (Exception) {}
            }

    }
}
