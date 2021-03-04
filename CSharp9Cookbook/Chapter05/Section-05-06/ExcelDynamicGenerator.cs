using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Section_05_06
{
    public class ExcelDynamicGenerator<TData> : GeneratorBase<TData>
    {
        ApplicationClass excelApp;
        dynamic wkBook;
        Worksheet wkSheet;

        public ExcelDynamicGenerator()
        {
            excelApp = new ApplicationClass();
            excelApp.Visible = true;

            wkBook = excelApp.Workbooks.Add();
            wkSheet = wkBook.ActiveSheet;
        }

        protected override StringBuilder GetTitle()
        {
            wkSheet.Cells[1, 1] = "Report";

            return new StringBuilder("Added Title...\n");
        }

        protected override StringBuilder GetHeaders(
            Dictionary<string, ColumnDetail> details)
        {
            ColumnDetail[] values = details.Values.ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                ColumnDetail detail = values[i];
                wkSheet.Cells[3, i+1] = detail.Attribute.Name;
            }

            return new StringBuilder("Added Header...\n");
        }

        protected override StringBuilder GetRows(
            List<TData> items,
            Dictionary<string, ColumnDetail> details)
        {
            const int DataStartRow = 4;

            int rows = items.Count;
            int cols = details.Count;

            var data = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                List<string> columns =
                    GetColumns(details.Values, items[i]);

                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = columns[j];
                }
            }

            int FirstCol = 'A';
            int LastExcelCol = FirstCol + cols - 1;
            int LastExcelRow = DataStartRow + rows - 1;
            string EndRangeCol = ((char)LastExcelCol).ToString();
            string EndRangeRow = LastExcelRow.ToString();

            string EndRange = EndRangeCol + EndRangeRow;
            string BeginRange = "A" + DataStartRow.ToString();

            var dataRange = wkSheet.get_Range(BeginRange, EndRange);
            dataRange.Value2 = data;

            wkBook.SaveAs(
                "Report.xlsx", 
                XlSaveAsAccessMode.xlShared);

            return new StringBuilder(
                "Added Data...\n" +
                "Excel file created at Report.xlsx");
        }
    }
}
