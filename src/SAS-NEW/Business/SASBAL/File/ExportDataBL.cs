﻿using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SASDAL.File;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Reflection;


namespace SASBAL.File
{
    public class ExportDataBL : IExportDataBL
    {
        //List<Sales_Quotation_List> salesquotation;
       // List<SalesQuotationEntity> salesquotation;
        //List<Sales_Order_List> salesorder;
        List<Sales_Invoice_list> salesinvoice;
        //List<Purchase_Quotation_List> purchasequotation;
        //List<Purchase_Order_List> purchaseorder;
        List<Purchase_Invoice_List> purchaseinvoices;
        List<PandS_Sold> pandssold;
        List<Gst_Tax_Collected> gsttaxcollected;
        List<Gst_Tax_Paid> gsttaxpaid;
        List<Credit_Note_List> creditnotelist;
        List<Debit_Note_List> debitnotelist;
        List<Gst_Tax_Summary> gsttaxsummary;
        List<PandS_Purchase> pandspurchase;
        List<Customer_Detail> customerdetail;
        List<Supplier_Detail> supplierdetail;
        List<PandS_Details> pandsdetail;
        List<Account_Detail> accountdetail;
        List<Tax_Codes_and_Rates> taxcodesrates;
        List<TrailBalance_Details> trialbalancedetail;
        List<Profit_and_Loss_Detail> profitandlossdetail;
        List<Balance_Sheet> balancesheetdetail;

        //private readonly DataTable data = new DataTable(Settings.Default.DataTableName, Settings.Default.DataTableNamespace);
        //private readonly string tempDir = Settings.Default.TemporaryDirectory;
        //private readonly string templateFile = Settings.Default.TempateFilePath;
        public bool ExportData(ObservableCollection<TransactionEntity> TransactionList, string FileName)
        {
            IExportDataDAL exportdata = new ExportDataDAL();
            if (TransactionList != null)
            {
                int i = 0;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                foreach (var item in TransactionList)
                {
                    if (item.IsChecked == true)
                    {
                        switch (item.ID)
                        {
                            //case 1:
                            //    salesquotation = exportdata.GetSalesQuotationsList(item.StartDate, item.EndDate);
                            //    dt = ToDataTable(salesquotation);
                            //    i = 0;
                            //    break;
                            //case 2:
                            //    salesorder = exportdata.GetSalesOrdersList(item.StartDate, item.EndDate);
                            //    dt = ToDataTable(salesorder);
                            //    i = 0;
                            //    break;
                            case 3:
                                salesinvoice = exportdata.GetSalesInvoicesList(item.StartDate, item.EndDate);
                                dt = ToDataTable(salesinvoice);
                                i = 0;
                                break;
                            case 4:
                                creditnotelist = exportdata.GetCreditNoteList(item.StartDate, item.EndDate);
                                dt = ToDataTable(creditnotelist);
                                i = 0;
                                break;
                            case 5:
                                purchaseinvoices = exportdata.GetPurchaseInvoicesList(item.StartDate, item.EndDate);
                                dt = ToDataTable(purchaseinvoices);
                                break;
                            case 6:
                                debitnotelist = exportdata.GetDebitNoteList(item.StartDate, item.EndDate);
                                dt = ToDataTable(debitnotelist);
                                i = 0;
                                break;
                            case 7:
                                pandssold = exportdata.GetPandSSoldList(item.StartDate, item.EndDate);
                                dt = ToDataTable(pandssold);
                                i = 0;
                                break;
                            case 8:
                                pandspurchase = exportdata.GetPandSPurchaseList(item.StartDate, item.EndDate);
                                dt = ToDataTable(pandspurchase);
                                i = 0;
                                break;
                            case 9:
                                gsttaxcollected = exportdata.GetGstTaxCollected(item.StartDate, item.EndDate);
                                dt = ToDataTable(gsttaxcollected);
                                i = 0;
                                break;
                            case 10:
                                gsttaxpaid = exportdata.GetGstTaxPaid(item.StartDate, item.EndDate);
                                dt = ToDataTable(gsttaxpaid);
                                i = 0;
                                break;
                            case 11:
                                gsttaxsummary = exportdata.GetGstTaxSummary(item.StartDate, item.EndDate);
                                dt = ToDataTable(gsttaxsummary);
                                i = 0;
                                break;
                                //case 9:
                                //    salesquotation = exportdata.GetCashBankStatement(item.StartDate, item.EndDate);
                                //    break;
                                //case 10:
                                //    salesquotation = exportdata.GetGSTSummary(item.StartDate, item.EndDate);
                                //    break;
                                //case 11:
                                //    salesquotation = exportdata.GetGSTCollectedDetails(item.StartDate, item.EndDate);
                                //    break;
                                //case 12:
                                //    salesquotation = exportdata.GetGSTPaidDetails(item.StartDate, item.EndDate);
                                //    break;
                        }
                        if (i == 0)
                            ds.Tables.Add(dt);
                        i++;
                    }
                }
                if (ds != null)
                {
                    ExportToExcel(ds, FileName);
                }
            }

            //ExportToExcel<Book, Books> s = new ExportToExcel<Book, Books>();
            //ICollectionView view = CollectionViewSource.GetDefaultView(dgBook.ItemsSource);
            //s.dataToPrint = (Books)view.SourceCollection;
            //s.GenerateReport();
            return true;
        }

        public bool ExportDataMaster(ObservableCollection<MasterEntity> masterlist, string FileName)
        {
            IExportDataDAL exportdata = new ExportDataDAL();
            if (masterlist != null)
            {
                int i = 0;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                foreach (var item in masterlist)
                {
                    if (item.IsCheckedMaster == true)
                    {
                        switch (item.ID)
                        {
                            case 1:
                                customerdetail = exportdata.GetCustomerDetailList();
                                dt = ToDataTable(customerdetail);
                                i = 0;
                                break;
                            case 2:
                                supplierdetail = exportdata.GetSupplierDetailList();
                                dt = ToDataTable(supplierdetail);
                                i = 0;
                                break;
                            case 3:
                                pandsdetail = exportdata.GetPandSDetailList();
                                dt = ToDataTable(pandsdetail);
                                i = 0;
                                break;
                            case 4:
                                accountdetail = exportdata.GetAccountDetailList();
                                dt = ToDataTable(accountdetail);
                                i = 0;
                                break;
                            case 5:
                                taxcodesrates = exportdata.GetTaxCodeRatelList();
                                dt = ToDataTable(taxcodesrates);
                                i = 0;
                                break;
                            case 7:
                                trialbalancedetail = exportdata.GetTrialBalanceDetailList();
                                dt = ToDataTable(trialbalancedetail);
                                i = 0;
                                break;
                            case 8:
                                profitandlossdetail = exportdata.GetProfitandLossDetailList();
                                dt = ToDataTable(profitandlossdetail);
                                i = 0;
                                break;
                            case 9:
                                balancesheetdetail = exportdata.GetBalanceSheetDetailList();
                                dt = ToDataTable(balancesheetdetail);
                                i = 0;
                                break;
                        }
                        if (i == 0)
                            ds.Tables.Add(dt);
                        i++;
                    }
                }
                if (ds != null)
                {
                    ExportToExcel(ds, FileName);
                }
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
    }
}
