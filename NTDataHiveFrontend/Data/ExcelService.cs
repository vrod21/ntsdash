using OfficeOpenXml;
using System.Data;

namespace NTDataHiveFrontend.Data
{
    public class ExcelService
    {
        public byte[] GenerateExcelWorkbook()
        {
            var list = new List<User>()
            {
                new User { UserName = "catcher", Age = 18 },
                new User { UserName = "james", Age = 20 },
            };

            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                workSheet.Cells.LoadFromCollection(list, true);

                return package.GetAsByteArray();
            }
            //public MemoryStream CreateExcel()
            //{
            //    using (ExcelEngine excelEngine = new ExcelEngine())
            //    {
            //        IApplication application = excelEngine.Excel;
            //        application.DefaultVersion = ExcelVersion.Xlsx;

            //        IWorkbook workbook = application.Workbooks.Create(1);
            //        IWorksheet worksheet = workbook.Worksheets[0];

            //        DataTable table = SampleDataTable();

            //        worksheet.ImportDataTable(table, true, 1, 1);

            //        worksheet.UsedRange.AutofitColumns();

            //        using (MemoryStream stream = new MemoryStream())
            //        {
            //            workbook.SaveAs(stream);
            //            return stream;
            //        }
            //    }
            //    return null;
            //}

            //private DataTable SampleDataTable()
            //{
            //    DataTable reports = new DataTable();

            //    reports.Columns.Add("SalesPerson");
            //    reports.Columns.Add("Age", typeof(int));
            //    reports.Columns.Add("Salary", typeof(int));

            //    reports.Rows.Add("Andy Bernard", 21, 30000);
            //    reports.Rows.Add("Jim Halpert", 25, 40000);
            //    reports.Rows.Add("Karen Fillippelli", 30, 50000);
            //    reports.Rows.Add("Phyllis Lapin", 34, 39000);
            //    reports.Rows.Add("Stanley Hudson", 45, 58000);

            //    return reports;
            //}
        }
    }
    public class User
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}

