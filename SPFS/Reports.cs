using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace SPFS
{
    class Reports
    {
        public string Name;
        public enum ReportTypes { Common, Selected, TechPassport };
        public int ReportType;
        public enum ReportFormats { PDF, Excel, Word };
        public int ReportFormat;
        public bool DDD;
        public DateTime DateBegin;
        public DateTime DateEnd;
        public DateTime DateCreate;

        public void Get()
        {

        }

        public void Save(DataGridView DG1,string Address, ReportFormats RF)
        {
            switch (RF)
            {
                case ReportFormats.Excel:
                    ToExcel(DG1).SaveAs(Address);
                    break;
                case ReportFormats.PDF:
                    ToExcel(DG1).ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, new FileInfo(Address).FullName);
                    break;
                case ReportFormats.Word:
                    break;
            };
        }

        public void CreateDiagramm()
        {

        }

        public void Gen(ReportTypes RT)
        {
            switch (RT)
            {
                case ReportTypes.TechPassport:
                    break;
            };
        }

        private Excel._Workbook ToExcel(DataGridView DG1)
        {
            //создаём объект Excel
            Excel._Application excel = new Excel.Application();
            Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "ЭСПО";
                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Обработка по каждой строке и столбцу
                for (int i = 0; i < DG1.Rows.Count; i++)
                {
                    for (int j = 0; j < DG1.Columns.Count; j++)
                    {
                        if (DG1.Columns[j].Visible)
                        {
                            cellColumnIndex = DG1.Columns[j].DisplayIndex + 1;
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            //Если строка Excel=1 то пишем туда заголовок столбца
                            if (cellRowIndex == 1)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = DG1.Columns[j].HeaderText;
                                (worksheet.Cells[cellRowIndex, cellColumnIndex] as Excel.Range).BorderAround(Excel.XlLineStyle.xlContinuous);
                            }

                            int cellRowIndexPlus1 = cellRowIndex + 1;
                            (worksheet.Cells[cellRowIndexPlus1, cellColumnIndex] as Excel.Range).NumberFormat = "@";
                            worksheet.Cells[cellRowIndexPlus1, cellColumnIndex] = DG1.Rows[i].Cells[j].Value.ToString();

                            //DG1.column

                            //цвет
                            if (DG1.Rows[i].Cells[j].Style.BackColor.Name != "0")
                            {
                                (worksheet.Cells[cellRowIndexPlus1, cellColumnIndex] as Excel.Range).Interior.Color = DG1.Rows[i].Cells[j].Style.BackColor;
                            }

                            //бордюры
                            (worksheet.Cells[cellRowIndexPlus1, cellColumnIndex] as Excel.Range).BorderAround(Excel.XlLineStyle.xlContinuous);
                            cellColumnIndex++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                worksheet.PageSetup.LeftMargin = 5;
                worksheet.PageSetup.RightMargin = 5;
                worksheet.PageSetup.BottomMargin = 5;
                worksheet.PageSetup.PrintTitleColumns = "$A:$B";
                //Ширина столбца по содержимому
                worksheet.Columns.EntireColumn.AutoFit();
                //return workbook;
            }
            catch (System.Exception ex)
            {
                Errors.Handle(ex);
                //MessageBox.Show(ex.Message + "\n" + ex.ToString());
            }
            finally
            {
                
                excel.DisplayAlerts = false;
                excel.Quit();
                //workbook = null;
                //excel = null;
            }
            return workbook;
        }


    }
}
