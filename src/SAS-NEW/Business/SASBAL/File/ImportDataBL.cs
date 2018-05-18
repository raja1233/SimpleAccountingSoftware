﻿using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SASDAL.File;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SASBAL.File
{
    public class ImportDataBL : IImportDataBL
    {

        public bool ImportData(int ID, string FileName)
        {
            int i = 0;
            List<Customer_Detail> CustomerDetail = new List<Customer_Detail>();
            List<Supplier_Detail> SupplierDetail = new List<Supplier_Detail>();
            List<Tax_Codes_and_Rates> Tax_Codes_and_Rates = new List<Tax_Codes_and_Rates>();
            List<PandS_Details> PandSDetails = new List<PandS_Details>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (ID != 0)
            {


                var x = System.IO.Path.GetDirectoryName(FileName);
                var ext = Path.GetExtension(FileName);
                switch (ID)
                {
                    case 1:
                        var customerdetail = CustomerDetail;
                        dt = ToDataTable(customerdetail);
                        i = 0;
                        //x = x + "\\Customer_Details.xls";
                        break;
                    case 2:
                        var customerdetail1 = SupplierDetail;
                        dt = ToDataTable(customerdetail1);
                        i = 0;
                        //x = x + "\\Customer_Details.xls";
                        break;
                    case 3:
                        var customerdetail3 = PandSDetails;
                        dt = ToDataTable(customerdetail3);
                        i = 0;
                        break;
                    case 4:
                        var customerdetail4 = Tax_Codes_and_Rates;
                        dt = ToDataTable(customerdetail4);
                        i = 0;
                        //x = x + "\\Customer_Details.xls";
                        break;

                }
                if (i == 0)
                    ds.Tables.Add(dt);
                i++;

            }
            if (ds != null)
            {
                ExportToExcel(ds, FileName);
            }

            return true;
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
            //foreach (T item in items)
            //{
            //    var values = new object[Props.Length];
            //    for (int i = 0; i < Props.Length; i++)
            //    {
            //        //inserting property values to datatable rows
            //        values[i] = Props[i].GetValue(item, null);
            //    }
            //    dataTable.Rows.Add(values);
            //}
            ////put a breakpoint here and check datatable

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
            //Read the excel to datatable
            //HSSFWorkbook hssfwb;
            //using (FileStream file = new FileStream(@"c:\test.xls", FileMode.Open, FileAccess.Read))
            //{
            //    hssfwb = new HSSFWorkbook(file);
            //}
            //ISheet sheet = hssfwb.GetSheet("Arkusz1");
            //for (int row = 0; row <= sheet.LastRowNum; row++)
            //{
            //    if (sheet.GetRow(row) != null)
            //    {
            //        // write it in your data table  
            //    }
            //}
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

        //function to import excel data to datatable
        public DataTable ExcelToDataTable(string filepath)
        {
            DataTable dt = new DataTable();
            //XSSFWorkbook hssfworkbook;
            IWorkbook workbook;
            using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
            
                string fileExtension = Path.GetExtension(filepath);
                try
                {
                    //using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    //{
                    if (fileExtension == ".xls")
                    {

                        //workBook = new XSSFWorkbook(file);
                        workbook =  new XSSFWorkbook(file);
                        ISheet sheet = workbook.GetSheetAt(0);
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int j = 0; j < cellCount; j++)
                        {
                            ICell cell = headerRow.GetCell(j);
                            dt.Columns.Add(cell.ToString());
                        }
                        for (
                            int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dt.NewRow();
                            if (row == null)
                            {
                                break;
                            }
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {
                                if (row.GetCell(j) != null)
                                    dataRow[j] = row.GetCell(j).ToString();
                               
                            }
                            dt.Rows.Add(dataRow);

                        }
                        

                    }
                    else if (fileExtension == ".xlxs")
                    {
                        workbook = new XSSFWorkbook(file);
                        ISheet sheet = workbook.GetSheetAt(0);
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int j = 0; j < cellCount; j++)
                        {
                            ICell cell = headerRow.GetCell(j);
                            dt.Columns.Add(cell.ToString());

                        }
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dt.NewRow();
                            if (row == null)
                            {
                                break;
                            }
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {
                                if (row.GetCell(j) != null) {
                                    dataRow[j] = row.GetCell(j).ToString();
                                   

                                }
                                dt.Rows.Add(dataRow);
                            }

                            
                        }
                       
                    }
                   
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                return dt;
            }
        }

        public void DataTableToList(int Id, string filepath,bool RUBool)
        {
            DataTable data = ExcelToDataTable(filepath);
            try
            {
                switch(Id)
                {
                    case 1:

                        List<Customer_Detail> _CustomerDetail = new List<Customer_Detail>();
                        if (RUBool==true)
                        {
                           
                            _CustomerDetail = (from DataRow dr in data.Rows
                                               select new Customer_Detail()
                                               {
                                                   Name = dr["Name"].ToString(),
                                                   Inactive = dr["Inactive"].ToString(),
                                                   Company_Reg_No = dr["Company_Reg_No"].ToString(),
                                                   GST_Reg_No = dr["GST_Reg_No"].ToString(),
                                                   Telephone = dr["Telephone"].ToString(),
                                                   Fax = dr["Fax"].ToString(),
                                                   Email = dr["Email"].ToString(),
                                                   Contact_Person = dr["Contact_Person"].ToString(),
                                                   //Balance = dr["Balance"].ToString(),
                                                   Type = dr["Type"].ToString(),
                                                   Salesman = dr["Salesman"].ToString(),
                                                   Credit_Limit_Amount = dr["Credit_Limit_Amount"].ToString(),
                                                   Credit_Limit_Days = dr["Credit_Limit_Days"].ToString(),
                                                   Discount = dr["Discount"].ToString(),
                                                   Bill_To_City = dr["Bill_To_City"].ToString(),
                                                   Bill_To_Country = dr["Bill_To_Country"].ToString(),
                                                   Bill_To_Line1 = dr["Bill_To_Line1"].ToString(),
                                                   Bill_To_Line2 = dr["Bill_To_Line2"].ToString(),
                                                   Bill_To_Postal_Code = dr["Bill_To_Postal_Code"].ToString(),
                                                   Bill_To_State = dr["Bill_To_State"].ToString(),
                                                   Ship_To_Line1 = dr["Ship_To_Line1"].ToString(),
                                                   Ship_To_Line2 = dr["Ship_To_Line2"].ToString(),
                                                   Ship_To_City = dr["Ship_To_City"].ToString(),
                                                   Ship_To_Country = dr["Ship_To_Country"].ToString(),
                                                   Ship_To_State = dr["Ship_To_State"].ToString(),
                                               }).Distinct().ToList();
                            var duplicateRecord = _CustomerDetail.GroupBy(x => x.Name).Select(x => x.First()).ToList();
                            IImportDataDAL customerList = new ImportDataDAL();
                            customerList.getCustomerList(duplicateRecord,RUBool);
                         
                        }
                        else
                        {
                            _CustomerDetail = (from DataRow dr in data.Rows
                                               select new Customer_Detail()
                                               {
                                                   Name = dr["Name"].ToString(),
                                                   Inactive = dr["Inactive"].ToString(),
                                                   Company_Reg_No = dr["Company_Reg_No"].ToString(),
                                                   GST_Reg_No = dr["GST_Reg_No"].ToString(),
                                                   Telephone = dr["Telephone"].ToString(),
                                                   Fax = dr["Fax"].ToString(),
                                                   Email = dr["Email"].ToString(),
                                                   Contact_Person = dr["Contact_Person"].ToString(),
                                                   //Balance = dr["Balance"].ToString(),
                                                   Type = dr["Type"].ToString(),
                                                   Salesman = dr["Salesman"].ToString(),
                                                   Credit_Limit_Amount = dr["Credit_Limit_Amount"].ToString(),
                                                   Credit_Limit_Days = dr["Credit_Limit_Days"].ToString(),
                                                   Discount = dr["Discount"].ToString(),
                                                   Bill_To_City = dr["Bill_To_City"].ToString(),
                                                   Bill_To_Country = dr["Bill_To_Country"].ToString(),
                                                   Bill_To_Line1 = dr["Bill_To_Line1"].ToString(),
                                                   Bill_To_Line2 = dr["Bill_To_Line2"].ToString(),
                                                   Bill_To_Postal_Code = dr["Bill_To_Postal_Code"].ToString(),
                                                   Bill_To_State = dr["Bill_To_State"].ToString(),
                                                   Ship_To_Line1 = dr["Ship_To_Line1"].ToString(),
                                                   Ship_To_Line2 = dr["Ship_To_Line2"].ToString(),
                                                   Ship_To_City = dr["Ship_To_City"].ToString(),
                                                   Ship_To_Country = dr["Ship_To_Country"].ToString(),
                                                   Ship_To_State = dr["Ship_To_State"].ToString(),
                                               }).Distinct().ToList();
                            var duplicateRecord = _CustomerDetail.GroupBy(x => x.Name).Select(x => x.First()).ToList();
                            IImportDataDAL customerList = new ImportDataDAL();
                            customerList.getCustomerList(duplicateRecord, RUBool);
                        }                   
                        break;
                    case 2:
                        List<Supplier_Detail> _SupplierDetailReject = new List<Supplier_Detail>();
                        if (RUBool== true)
                        {
                            _SupplierDetailReject = (from DataRow dr in data.Rows
                                                     select new Supplier_Detail()
                                                     {
                                                         Name = dr["Name"].ToString(),
                                                         Inactive = dr["Inactive"].ToString(),
                                                         Company_Reg_No = dr["Company_Reg_No"].ToString(),
                                                         GST_Reg_No = dr["GST_Reg_No"].ToString(),
                                                         Telephone = dr["Telephone"].ToString(),
                                                         Fax = dr["Fax"].ToString(),
                                                         Email = dr["Email"].ToString(),
                                                         Contact_Person = dr["Contact_Person"].ToString(),
                                                         //Balance = dr["Balance"].ToString(),
                                                         Credit_Limit_Amount = dr["Credit_Limit_Amount"].ToString(),
                                                         Credit_Limit_Days = dr["Credit_Limit_Days"].ToString(),
                                                         Bill_To_City = dr["Bill_To_City"].ToString(),
                                                         Bill_To_Country = dr["Bill_To_Country"].ToString(),
                                                         Bill_To_Line1 = dr["Bill_To_Line1"].ToString(),
                                                         Bill_To_Line2 = dr["Bill_To_Line2"].ToString(),
                                                         Bill_To_Postal_Code = dr["Bill_To_Postal_Code"].ToString(),
                                                         Bill_To_State = dr["Bill_To_State"].ToString(),
                                                         Ship_To_Line1 = dr["Ship_To_Line1"].ToString(),
                                                         Ship_To_Line2 = dr["Ship_To_Line2"].ToString(),
                                                         Ship_To_City = dr["Ship_To_City"].ToString(),
                                                         Ship_To_Country = dr["Ship_To_Country"].ToString(),
                                                         Ship_To_State = dr["Ship_To_State"].ToString(),
                                                         Ship_To_Postal_Code = dr["Ship_To_Postal_Code"].ToString(),
                                                         Remarks = dr["Remarks"].ToString(),
                                                     }).Distinct().ToList();
                            var duplicateRecord = _SupplierDetailReject.GroupBy(x => x.Name).Select(x=>x.First()).ToList();
                            IImportDataDAL supplierList = new ImportDataDAL();
                            supplierList.getSupplierList(duplicateRecord, RUBool);
                           
                        }
                        else
                        {
                            _SupplierDetailReject = (from DataRow dr in data.Rows
                                                     select new Supplier_Detail()
                                                     {
                                                         Name = dr["Name"].ToString(),
                                                         Inactive = dr["Inactive"].ToString(),
                                                         Company_Reg_No = dr["Company_Reg_No"].ToString(),
                                                         GST_Reg_No = dr["GST_Reg_No"].ToString(),
                                                         Telephone = dr["Telephone"].ToString(),
                                                         Fax = dr["Fax"].ToString(),
                                                         Email = dr["Email"].ToString(),
                                                         Contact_Person = dr["Contact_Person"].ToString(),
                                                         //Balance = dr["Balance"].ToString(),
                                                         Credit_Limit_Amount = dr["Credit_Limit_Amount"].ToString(),
                                                         Credit_Limit_Days = dr["Credit_Limit_Days"].ToString(),
                                                         Bill_To_City = dr["Bill_To_City"].ToString(),
                                                         Bill_To_Country = dr["Bill_To_Country"].ToString(),
                                                         Bill_To_Line1 = dr["Bill_To_Line1"].ToString(),
                                                         Bill_To_Line2 = dr["Bill_To_Line2"].ToString(),
                                                         Bill_To_Postal_Code = dr["Bill_To_Postal_Code"].ToString(),
                                                         Bill_To_State = dr["Bill_To_State"].ToString(),
                                                         Ship_To_Line1 = dr["Ship_To_Line1"].ToString(),
                                                         Ship_To_Line2 = dr["Ship_To_Line2"].ToString(),
                                                         Ship_To_City = dr["Ship_To_City"].ToString(),
                                                         Ship_To_Country = dr["Ship_To_Country"].ToString(),
                                                         Ship_To_State = dr["Ship_To_State"].ToString(),
                                                         Ship_To_Postal_Code = dr["Ship_To_Postal_Code"].ToString(),
                                                         Remarks = dr["Remarks"].ToString(),
                                                     }).Distinct().ToList();
                            var duplicateRecord = _SupplierDetailReject.GroupBy(x => x.Name).Select(x => x.First()).ToList();
                            IImportDataDAL supplierList = new ImportDataDAL();
                            supplierList.getSupplierList(duplicateRecord, RUBool);
                        }
                      
                        break;
                    case 3:
                        List<PandS_Details> _PandSDetails = new List<PandS_Details>();
                        if(RUBool==true)
                        {
                            _PandSDetails = (from DataRow dr in data.Rows
                                             select new PandS_Details()
                                             {
                                                 Product_and_Service_Type = dr["Product_and_Service_Type"].ToString(),
                                                 Isinactive = dr["Isinactive"].ToString(),
                                                 PandS_Code = dr["PandS_Code"].ToString(),
                                                 PandS_Name = dr["PandS_Name"].ToString(),
                                                 Category1 = dr["Category1"].ToString(),
                                                 Category2 = dr["Category2"].ToString(),
                                                 Description = dr["Description"].ToString(),
                                                 Tax_Code = dr["Tax_Code"].ToString(),
                                                 Tax_Rate = dr["Tax_Rate"].ToString(),
                                                 //Std_Sell_Price_bef_Tax = dr["Std_Sell_Price_bef_Tax"].ToString(),
                                                 //Std_Sell_Price_aft_Tax = dr["Std_Sell_Price_aft_Tax"].ToString(),
                                                 //Ave_Sell_Price_bef_Tax = dr["Ave_Sell_Price_bef_Tax"].ToString(),
                                                 //Ave_Sell_Price_aft_Tax = dr["Ave_Sell_Price_aft_Tax"].ToString(),
                                                 //Last_Sold_Price_bef_Tax = dr["Last_Sold_Price_bef_Tax"].ToString(),
                                                 //Last_Sold_Price_aft_Tax = dr["Last_Sold_Price_aft_Tax"].ToString(),
                                                 Std_Cost_Price_bef_Tax = dr["Std_Cost_Price_bef_Tax"].ToString(),
                                                 Std_Cost_Price_aft_Tax = dr["Std_Cost_Price_aft_Tax"].ToString(),
                                                 //Ave_Cost_Price_bef_Tax = dr["Ave_Cost_Price_bef_Tax"].ToString(),
                                                 //Ave_Cost_Price_aft_Tax = dr["Ave_Cost_Price_aft_Tax"].ToString(),
                                                 //Last_Pur_Price_bef_Tax = dr["Last_Pur_Price_bef_Tax"].ToString(),
                                                 //Last_Pur_Price_aft_Tax = dr["Last_Pur_Price_aft_Tax"].ToString(),
                                                 //Minimum_Quantity = dr["Minimum_Quantity"].ToString(),
                                                 //Quantity_in_Stock = dr["Quantity_in_Stock"].ToString(),
                                                 Reserved_for_Sales_Order = dr["Reserved_for_Sales_Order"].ToString(),
                                             }).Distinct().ToList();
                            var duplicateRecord = _PandSDetails.GroupBy(x => x.PandS_Name).Select(x => x.First()).ToList();
                            IImportDataDAL PandSList = new ImportDataDAL();
                            PandSList.getPandsDetailsList(duplicateRecord, RUBool);
                        }
                        else
                        {
                            _PandSDetails = (from DataRow dr in data.Rows
                                             select new PandS_Details()
                                             {
                                                 Product_and_Service_Type = dr["Product_and_Service_Type"].ToString(),
                                                 Isinactive = dr["Isinactive"].ToString(),
                                                 PandS_Code = dr["PandS_Code"].ToString(),
                                                 PandS_Name = dr["PandS_Name"].ToString(),
                                                 Category1 = dr["Category1"].ToString(),
                                                 Category2 = dr["Category2"].ToString(),
                                                 Description = dr["Description"].ToString(),
                                                 Tax_Code = dr["Tax_Code"].ToString(),
                                                 Tax_Rate = dr["Tax_Rate"].ToString(),
                                                 //Std_Sell_Price_bef_Tax = dr["Std_Sell_Price_bef_Tax"].ToString(),
                                                 //Std_Sell_Price_aft_Tax = dr["Std_Sell_Price_aft_Tax"].ToString(),
                                                 //Ave_Sell_Price_bef_Tax = dr["Ave_Sell_Price_bef_Tax"].ToString(),
                                                 //Ave_Sell_Price_aft_Tax = dr["Ave_Sell_Price_aft_Tax"].ToString(),
                                                 //Last_Sold_Price_bef_Tax = dr["Last_Sold_Price_bef_Tax"].ToString(),
                                                 //Last_Sold_Price_aft_Tax = dr["Last_Sold_Price_aft_Tax"].ToString(),
                                                 Std_Cost_Price_bef_Tax = dr["Std_Cost_Price_bef_Tax"].ToString(),
                                                 Std_Cost_Price_aft_Tax = dr["Std_Cost_Price_aft_Tax"].ToString(),
                                                 //Ave_Cost_Price_bef_Tax = dr["Ave_Cost_Price_bef_Tax"].ToString(),
                                                 //Ave_Cost_Price_aft_Tax = dr["Ave_Cost_Price_aft_Tax"].ToString(),
                                                 //Last_Pur_Price_bef_Tax = dr["Last_Pur_Price_bef_Tax"].ToString(),
                                                 //Last_Pur_Price_aft_Tax = dr["Last_Pur_Price_aft_Tax"].ToString(),
                                                 //Minimum_Quantity = dr["Minimum_Quantity"].ToString(),
                                                 //Quantity_in_Stock = dr["Quantity_in_Stock"].ToString(),
                                                 Reserved_for_Sales_Order = dr["Reserved_for_Sales_Order"].ToString(),
                                             }).Distinct().ToList();
                            var duplicateRecord = _PandSDetails.GroupBy(x => x.PandS_Name).Select(x => x.First()).ToList();
                            IImportDataDAL PandSList = new ImportDataDAL();
                            PandSList.getPandsDetailsList(duplicateRecord, RUBool);
                        }
                        break;
                    case 4:
                        List<Tax_Codes_and_Rates> _TaxCodesandRates = new List<Tax_Codes_and_Rates>();
                        if(RUBool==true)
                        {
                            _TaxCodesandRates = (from DataRow dr in data.Rows
                                                 select new Tax_Codes_and_Rates()
                                                 {
                                                     Tax_Name = dr["Tax_Name"].ToString(),
                                                     Tax_Description = dr["Tax_Description"].ToString(),
                                                     Tax_Code = dr["Tax_Code"].ToString(),
                                                     Tax_Rate = dr["Tax_Rate"].ToString(),
                                                     Isinactive = dr["Isinactive"].ToString(),
                                                 }).Distinct().ToList();
                            var duplicateRecord = _TaxCodesandRates.GroupBy(x => x.Tax_Code).Select(x => x.First()).ToList();
                            IImportDataDAL TaxCodesandRatesList = new ImportDataDAL();
                            TaxCodesandRatesList.getTaxCodesandRatesList(duplicateRecord, RUBool);
                        }
                        else
                        {
                            _TaxCodesandRates = (from DataRow dr in data.Rows
                                                 select new Tax_Codes_and_Rates()
                                                 {
                                                     Tax_Name = dr["Tax_Name"].ToString(),
                                                     Tax_Description = dr["Tax_Description"].ToString(),
                                                     Tax_Code = dr["Tax_Code"].ToString(),
                                                     Tax_Rate = dr["Tax_Rate"].ToString(),
                                                     Isinactive = dr["Isinactive"].ToString(),
                                                 }).Distinct().ToList();
                            var duplicateRecord = _TaxCodesandRates.GroupBy(x => x.Tax_Code).Select(x => x.First()).ToList();
                            IImportDataDAL TaxCodesandRatesList = new ImportDataDAL();
                            TaxCodesandRatesList.getTaxCodesandRatesList(duplicateRecord, RUBool);
                        }
                        break;
                }
                
            }
            catch(Exception e)
            {
                throw e;
            }
            

        }
    }
}