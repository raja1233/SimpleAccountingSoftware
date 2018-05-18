using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.CashandBank;
using SASDAL.CashBank;
using System.Data;
using System.Collections.ObjectModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Reflection;
using SDN.UI.Entities.Export;

namespace SASBAL.CashBank
{
    public class CashBankStatementBL : ICashBankStatementBL
    {
        /// <summary>
        /// Give left side list of cashbank statement list
        /// </summary>
        /// <returns></returns>
        List<Cash_and_Bank_Statement> cashandbank;
        public List<CashBankStatementEntity> GetBankAccountList()
        {
            ICashBankStatementDAL AccountList = new CashBankStatementDAL();
            return AccountList.GetBankAccountList();
        }

        /// <summary>
        ///give Account Details List 
        /// </summary>
        /// <param name="CashBankStatementID"></param>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        /// 
        
        public List<CashBankStatementEntity> GetAccountDetailList(int CashBankStatementID, string jsondata)
        {


            ICashBankStatementDAL AccountDetailList = new CashBankStatementDAL();
            return AccountDetailList.GetAccountDetailList(CashBankStatementID, jsondata);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICashBankStatementDAL pDAL = new CashBankStatementDAL();
            return pDAL.GetLastSelectionData(ScreenId);
        }
        public List<Cash_and_Bank_Statement> GetExportDataList(int CashBankStatementID, string jsondata,string FileName)
        {
            ICashBankStatementDAL exportdata = new CashBankStatementDAL();
                    
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                cashandbank = exportdata.GetExportDataList(CashBankStatementID, jsondata, FileName);
                dt = ToDataTable(cashandbank);
                ds.Tables.Add(dt);
                ExportToExcel(ds, FileName);
          
            return cashandbank;
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

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICashBankStatementDAL pBL = new CashBankStatementDAL();
            return pBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
    }
}
