using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace NEO.Common.Excel
{
    public class ExcelContext
    {
        private readonly ExcelPackage workbook = null;

        public ExcelContext(string filename)
        {
            var folder = Path.GetDirectoryName(filename);
            if (!Directory.Exists(folder) && !string.IsNullOrEmpty(folder))
            {
                Directory.CreateDirectory(folder);
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File"));
            }

            FileInfo fileinfo = new FileInfo(filename);
            if (fileinfo.Exists)
            {
                fileinfo.Delete();
                fileinfo = new FileInfo(filename);
            }
            workbook = new ExcelPackage(fileinfo);
        }

        public Stream Stream
        {
            get { return workbook.Stream; }
        }

        public void AppendDataTable(DataTable dataTable, string sheetName)
        {
            var worksheet = workbook.Workbook.Worksheets[sheetName];
            if (worksheet == null)
            {
                worksheet = workbook.Workbook.Worksheets.Add(sheetName);
            }
            var x = 1;
            for (int y = 1; y <= dataTable.Columns.Count; y++)
            {
                var column = dataTable.Columns[y - 1];

                if (column.DataType == typeof(DateTime) || column.DataType == typeof(DateTime?))
                {
                    worksheet.Column(y).Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                    worksheet.Column(y).Width = 20;
                }
                worksheet.Column(y).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                worksheet.Cells[x, y].Style.Font.Bold = true;
                worksheet.Cells[x, y].Value = column.ColumnName;
            }
            x++;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var row = dataTable.Rows[i];
                for (int y = 1; y <= dataTable.Columns.Count; y++)
                {
                    var name = dataTable.Columns[y - 1].ColumnName;
                    worksheet.Cells[x, y].Value = row[name];
                }
                x++;
            }

        }

        public void Save()
        {
            workbook.Save();
        }

        public void Save(DataTable dataTable)
        {
            AppendDataTable(dataTable, Guid.NewGuid().ToString("N"));
            Save();
        }
    }
}
