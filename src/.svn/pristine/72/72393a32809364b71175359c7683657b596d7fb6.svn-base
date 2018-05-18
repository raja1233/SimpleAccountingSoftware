using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SDN.Products.BLInterface;
using SDN.Products.DAL;
using SDN.Products.DALInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BL
{
    public class PandSPurchaseBL : IPandSPurchaseBL
    {
        List<ProductandServicePurchaseEntity> pandSPurchase;
        public List<PandSPurchaseEntity> GetPandSPurchaseList()
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            return pandsPurchaseDAl.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSPurchaseDAL pandsPurchaseBL = new PandSPurchaseDAL();
            return pandsPurchaseBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }


        public List<PandSPurchaseEntity> GetAllSalesInvoice()
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            var Invoicelist = pandsPurchaseDAl.GetAllSalesInvoice();
           
            return Invoicelist;
        }
        public List<PandSPurchaseEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax,bool? IsSummary)
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            var Invoicelist = pandsPurchaseDAl.GetAllSalesInvoiceJson(jsondata, ExcincTax, IsSummary);
           
            return Invoicelist;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            var result = pandsPurchaseDAl.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            var result = pandsPurchaseDAl.GetDateFormat();
            return result;
        }

        private string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Invoice";
            else if (ConvertedToPO == true)
                return "Invoice";
            else
                return "";
        }

        public List<YearEntity> GetYearRange()
        {
            IOptionsDAL YearInfo = new OptionsDAL();
            var StartYear = YearInfo.GetYearStart();
            List<YearEntity> YearRange = new List<YearEntity>();
            YearEntity obj = new YearEntity();
            if (StartYear == 0)
            {
                obj.Year = (DateTime.Today.Year - 1).ToString();
                YearRange.Add(obj);

                obj.Year = DateTime.Today.Year.ToString();
                YearRange.Add(obj);
                return YearRange;
            }
            else
            {
                int diff = DateTime.Now.Year - StartYear;
                for (int i = 0; i <= diff; i++)
                {
                    obj = new YearEntity();
                    obj.Year = StartYear.ToString();
                    obj.ID = i;
                    YearRange.Add(obj);
                    StartYear++;
                }
                return YearRange;
            }
        }

        public TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes().FirstOrDefault();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
        public string getTotalCount(int ScreenId)
        {
            IPandSPurchaseDAL pandsSoldDAl = new PandSPurchaseDAL();
            var result = pandsSoldDAl.getTotalCount(ScreenId);
            return result;
        }
        public List<ProductandServicePurchaseEntity> GetExportDataList(string jsondata, bool? ExcincTax, bool? IsSummary, string FileName)
        {
            IPandSPurchaseDAL exportdata = new PandSPurchaseDAL();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            pandSPurchase = exportdata.GetExportDataList(jsondata, ExcincTax, IsSummary, FileName);
            dt = ToDataTable(pandSPurchase);
            ds.Tables.Add(dt);
            ExportToExcel(ds, FileName);

            return pandSPurchase;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable

            return dataTable;
        }
        public static void ExportToExcel(DataSet ds, string ExcelFilePath = null)
        {
            try
            {
                XSSFWorkbook hssfwb;
                hssfwb = new XSSFWorkbook();
                XSSFSheet sh;
                int sheetcount = 0;
                XSSFFont _style = (XSSFFont)hssfwb.CreateFont();
                _style.Color = NPOI.HSSF.Util.HSSFColor.Red.Index;
                _style.Boldweight = 2;
                foreach (DataTable table in ds.Tables)
                {
                    sh = (XSSFSheet)hssfwb.CreateSheet(ds.Tables[sheetcount].TableName);
                    for (int col = 1; col < table.Columns.Count + 1; col++)
                    {
                        if (col == 1) sh.CreateRow(0);
                        sh.GetRow(0)
                            .CreateCell(col - 1);
                        sh.GetRow(0)
                            .GetCell(col - 1)
                            .SetCellValue(table.Columns[col - 1].ColumnName);
                    }
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        var r = sh.CreateRow(i + 1);
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            sh.GetRow(i + 1)
                                .CreateCell(j);
                            sh.GetRow(i + 1)
                                .GetCell(j)
                                .SetCellValue(table.Rows[i].ItemArray[j].ToString());
                            sh.GetRow(i + 1)
                                .GetCell(j)
                                .SetCellType(CellType.String);
                            //if (coloringrows != null && coloringrows.Count > 0 && coloringrows.Contains(i))
                            //{
                            //    sh.GetRow(i + 1)
                            //        .GetCell(j)
                            //        .CellStyle.SetFont(_style);
                            //    coloringrows.Remove(i);
                            //}
                        }
                    }
                    sheetcount++;
                }
                using (FileStream file = new FileStream(ExcelFilePath, FileMode.Create, FileAccess.Write))
                {
                    hssfwb.Write(file);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
