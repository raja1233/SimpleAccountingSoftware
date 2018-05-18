﻿using Microsoft.Reporting.WinForms;
using SDN.Purchasing.ViewModel;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SASClient.Reports.ReportsPage
{
    /// <summary>
    /// Interaction logic for PurchaseOrderReportViewer.xaml
    /// </summary>
    public partial class PurchaseOrderReportViewer : UserControl
    {
        private PurchaseOrderViewModel _viewModelSales;
        public PurchaseOrderReportViewer()
        {
            InitializeComponent();
            Type type = typeof(PurchaseOrderViewModel);

            //SalesInvoiceViewModel instance = (SalesInvoiceViewModel)Activator.CreateInstance(type);
            object obj = System.Runtime.Serialization.FormatterServices
             .GetUninitializedObject(type);
            _viewModelSales = (PurchaseOrderViewModel)obj;

            this.DataContext = obj;
        }
        public PurchaseOrderReportViewer(PurchaseOrderViewModel model) : this()
        {
            InitializeComponent();
            this.DataContext = _viewModelSales;
            _viewModelSales = model;

        }
        //public System.Drawing.Image byteArrayToImage(byte[] bytesArr)
        //{
        //    using (var ms = new MemoryStream(bytesArr))
        //    {
        //        return System.Drawing.Image.FromStream(ms);
        //    }
        //}

        private void UserControl_LoadedPurchaseOrder(object sender, RoutedEventArgs e)
        {
            //var a = _viewModel.PrintSalesQuotation();
            PurchaseOrderForm sqf = _viewModelSales.PrintPurchaseOrder();

            // System.Drawing.Image newImage = byteArrayToImage(sqf.Quotation.CompanyLogo);
            // System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(sqf.Quotation.CompanyLogo));


            //this is for table grid

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PandSCode", typeof(string)));
            dt.Columns.Add(new DataColumn("PandSName", typeof(string)));
            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("Discount", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));

            //ReportingDataset ds = new ReportingDataset();


            foreach (var item in sqf.OrderDetails)
            {
                DataRow dr = dt.NewRow();
                dr["PandSCode"] = item.PandSCode;
                dr["PandSName"] = item.PandSName;
                dr["Qty"] = item.POQty;
                dr["Price"] = item.Price.ToString();
                dr["Discount"] = item.PODiscount;
                dr["Amount"] = item.POAmount.ToString();
                dr["Rate"] = item.GSTRate.ToString();
                dt.Rows.Add(dr);
            }



            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "PurchaseOrderDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource.Value = dt;
            // end of product grid code
            DataTable dt4 = new DataTable();
            //for other than table
            dt4.Columns.Add(new DataColumn("TermsAndConditions", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalBeforeTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalAfterTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("PONo", typeof(string)));
            dt4.Columns.Add(new DataColumn("PODate", typeof(string)));
            dt4.Columns.Add(new DataColumn("DeliveryDate", typeof(string)));
            dt4.Columns.Add(new DataColumn("PINo", typeof(string)));


            DataRow dr4 = dt4.NewRow();
            dr4["TermsAndConditions"] = sqf.Order.TermsAndConditions;
            dr4["TotalBeforeTax"] = sqf.Order.TotalAfterTax;
            dr4["TotalTax"] = sqf.Order.TotalTax.ToString();
            dr4["TotalAfterTax"] = sqf.Order.TotalAfterTax.ToString();
            dr4["PONo"] = sqf.Order.OrderNo;
            dr4["PODate"] = sqf.Order.OrderDate.Date.ToString("dd/M/yyyy");
            dr4["DeliveryDate"] = sqf.Order.DeletedDate;
            dr4["PINo"] = sqf.Order.PurchaseInvoiceNo;
            dt4.Rows.Add(dr4);

            ReportDataSource reportDataSource4 = new ReportDataSource();
            reportDataSource4.Name = "PurchaseOrderUniqueRecordDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource4.Value = dt4;
            // company details
            /*****Define column*****/
            DataTable dt1 = new DataTable();
            dt1.Columns.Add(new DataColumn("CompanyName", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyLogo", typeof(byte[])));
            dt1.Columns.Add(new DataColumn("CompanyRegNumber", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyGstNumber", typeof(string)));
            dt1.Columns.Add(new DataColumn("Telephone", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyFax", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyEmail", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyBillToAddressLine1", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyBillToAddressLine2", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyBillToCity", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyBillToState", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyBillToCountary", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyBillToPostCode", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyShipToPostCode", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyShipToLine1", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyShipToLine2", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyShipToCity", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyShipToState", typeof(string)));
            dt1.Columns.Add(new DataColumn("CompanyShipToCountary", typeof(string)));
            /*****End  column*****/
            /*****data part*******/

            DataRow dr1 = dt1.NewRow();
            dr1["CompanyName"] = sqf.Order.CompanyName;
            dr1["CompanyLogo"] = sqf.Order.CompanyLogo;
            dr1["CompanyRegNumber"] = sqf.Order.CompanyRegNumber;
            dr1["CompanyGstNumber"] = sqf.Order.CompanyGstNumber;
            dr1["Telephone"] = sqf.Order.Telephone;
            dr1["CompanyFax"] = sqf.Order.CompanyFax;
            dr1["CompanyEmail"] = sqf.Order.CompanyEmail;
            dr1["CompanyBillToAddressLine1"] = sqf.Order.CompanyBillToAddressLine1;
            dr1["CompanyBillToAddressLine2"] = sqf.Order.CompanyBillToAddressLine2;
            dr1["CompanyBillToCity"] = sqf.Order.CompanyBillToCity;
            dr1["CompanyBillToState"] = sqf.Order.CompanyBillToState;
            dr1["CompanyBillToCountary"] = sqf.Order.CompanyBillToCountary;
            dr1["CompanyBillToPostCode"] = sqf.Order.CompanyBillToPostCode;
            dr1["CompanyShipToLine1"] = sqf.Order.CompanyShipToAddressLine1;
            dr1["CompanyShipToLine2"] = sqf.Order.CompanyShipToAddressLine2;
            dr1["CompanyShipToCity"] = sqf.Order.CompanyShipToCity;
            dr1["CompanyShipToState"] = sqf.Order.CompanyShipToState;
            dr1["CompanyShipToCountary"] = sqf.Order.CompanyShipToCountary;
            dr1["CompanyShipToPostCode"] = sqf.Order.CompanyShipToPostCode;

            dt1.Rows.Add(dr1);
            /*****data part*******/
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "CompanyDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource1.Value = dt1;
            // end of company details

            //Supplier Details 
            /****column defn**/
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("SupplierName", typeof(string)));
            dt2.Columns.Add(new DataColumn("SupplierBillToLine1", typeof(string)));
            dt2.Columns.Add(new DataColumn("SupplierBillToLine2", typeof(string)));
            dt2.Columns.Add(new DataColumn("SupplierBillToCity", typeof(string)));
            dt2.Columns.Add(new DataColumn("SupplierBillToState", typeof(string)));
            dt2.Columns.Add(new DataColumn("SupplierBillToCountary", typeof(string)));
            dt2.Columns.Add(new DataColumn("SupplierBillToPostCode", typeof(string)));
            dt2.Columns.Add(new DataColumn("SupplierTelephone", typeof(string)));

            /****end column defn**/
            /**data****/
            DataRow dr2 = dt2.NewRow();
            dr2["SupplierName"] = sqf.Order.SupplierName;
            dr2["SupplierBillToLine1"] = sqf.Order.SupplierBillAddress1;
            dr2["SupplierBillToLine2"] = sqf.Order.SupplierBillAddress2;
            dr2["SupplierBillToCity"] = sqf.Order.SupplierBillAddressCity;
            dr2["SupplierBillToState"] = sqf.Order.SupplierBillAddressState;
            dr2["SupplierBillToCountary"] = sqf.Order.SupplierBillAddressCountary;
            dr2["SupplierBillToPostCode"] = sqf.Order.SupplierBillPostCode;
            dr2["SupplierTelephone"] = sqf.Order.SupplierTelephone;
            /**end data****/
            dt2.Rows.Add(dr2);
            ReportDataSource reportDataSource2 = new ReportDataSource();
            reportDataSource2.Name = "SupplierDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource2.Value = dt2;
            //End Customer Details 

            //option 
            DataTable dt3 = new DataTable();
            dt3.Columns.Add(new DataColumn("CurrencyCode", typeof(string)));
            DataRow dr3 = dt3.NewRow();
            dr3["CurrencyCode"] = sqf.Order.CurrencyCode;
            dt3.Rows.Add(dr3);

            ReportDataSource reportDataSource3 = new ReportDataSource();
            reportDataSource3.Name = "OptionsDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource3.Value = dt3;
            //end options
            string exefolder = System.Windows.Forms.Application.StartupPath;
            string reportPath = System.IO.Path.Combine(exefolder, @"PurchaseOrder.rdlc");
            reportViewer7.LocalReport.ReportPath = reportPath;
            //D:\DayUser\src\SAS - NEW\Client\SASClient\Reports\ReportsRdlc
            reportViewer7.LocalReport.DataSources.Clear();
            reportViewer7.LocalReport.DataSources.Add(reportDataSource);
            reportViewer7.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer7.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer7.LocalReport.DataSources.Add(reportDataSource3);
            reportViewer7.LocalReport.DataSources.Add(reportDataSource4);
            reportViewer7.RefreshReport();
            // this.reportViewer1.Width = 75;
        }
        private void reportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {

        }
    }
}
