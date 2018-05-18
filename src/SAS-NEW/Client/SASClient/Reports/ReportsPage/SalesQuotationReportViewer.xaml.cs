﻿using Microsoft.Reporting.WinForms;
using SDN.Sales.ViewModel;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    /// Interaction logic for SalesQuotationReportViewer.xaml
    /// </summary>
    /// 

    //public static class BitmapConversion
    //{
    //    public static BitmapSource BitmapToBitmapSource(Bitmap source)
    //    {
    //        return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
    //                      source.GetHbitmap(),
    //                      IntPtr.Zero,
    //                      Int32Rect.Empty,
    //                      BitmapSizeOptions.FromEmptyOptions());
    //    }
     

    //}
    public partial class SalesQuotationReportViewer : UserControl
    {
        private SalesQuotationViewModel _viewModelSales;
       
        public SalesQuotationReportViewer()
        {
             InitializeComponent();
            Type type = typeof(SalesQuotationViewModel);

            //SalesQuotationViewModel instance = (SalesQuotationViewModel)Activator.CreateInstance(type);
            object obj = System.Runtime.Serialization.FormatterServices
             .GetUninitializedObject(type);
            _viewModelSales = (SalesQuotationViewModel)obj;

            this.DataContext = obj;

        }
        public SalesQuotationReportViewer(SalesQuotationViewModel model) : this()
        {
            InitializeComponent();
            this.DataContext = _viewModelSales;
            _viewModelSales = model;

        }

        private void UserControl_LoadedSalesQuotation(object sender, RoutedEventArgs e)
        {
           //var a = _viewModel.PrintSalesQuotation();
            SalesQuotationForm sqf = _viewModelSales.PrintSalesQuotation();

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


            foreach (var item in sqf.QuotationDetails)
            {
                DataRow dr = dt.NewRow();
                dr["PandSCode"] = item.PandSCode;
                dr["PandSName"] = item.PandSName;
                dr["Qty"] = item.SQQty;
                dr["Price"] = item.Price.ToString();
                dr["Discount"] = item.SQDiscount;
                dr["Amount"] = item.SQAmount.ToString();
                dr["Rate"] = item.GSTRate.ToString();
                dt.Rows.Add(dr);
            }
           
           

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "SalesQuotationDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource.Value = dt;
            // end of product grid code
            DataTable dt4 = new DataTable();
            //for other than table
            dt4.Columns.Add(new DataColumn("TAndCondition", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalBeforeTaxStr", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalAfterTaxStr", typeof(string)));
            dt4.Columns.Add(new DataColumn("QuotationNo", typeof(string)));
            dt4.Columns.Add(new DataColumn("QuotationDate", typeof(string)));
            dt4.Columns.Add(new DataColumn("ValidForDays", typeof(int)));

            DataRow dr4 = dt4.NewRow();
            dr4["TAndCondition"] = sqf.Quotation.TermsAndConditions;
            dr4["TotalBeforeTaxStr"] = sqf.Quotation.TotalAfterTax;
            dr4["TotalTax"] = sqf.Quotation.TotalTax.ToString();
            dr4["TotalAfterTaxStr"] = sqf.Quotation.TotalAfterTax.ToString();
            dr4["QuotationNo"] = sqf.Quotation.QuotationNo;
            dr4["QuotationDate"] = sqf.Quotation.QuotationDate.Date.ToString("dd/M/yyyy");
            dr4["ValidForDays"] = sqf.Quotation.ValidForDays;
            dt4.Rows.Add(dr4);

            ReportDataSource reportDataSource4 = new ReportDataSource();
            reportDataSource4.Name = "SalesQuotationUniqueRecordDataSet"; // Name of the DataSet we set in .rdlc
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
            /*****End  column*****/
            /*****data part*******/
          
            DataRow dr1 = dt1.NewRow();
            dr1["CompanyName"] = sqf.Quotation.CompanyName;
            dr1["CompanyLogo"] = sqf.Quotation.CompanyLogo;
            dr1["CompanyRegNumber"] = sqf.Quotation.CompanyRegNumber;
            dr1["CompanyGstNumber"] = sqf.Quotation.CompanyGstNumber;
            dr1["Telephone"] = sqf.Quotation.Telephone;
            dr1["CompanyFax"] = sqf.Quotation.CompanyFax;
            dr1["CompanyEmail"] = sqf.Quotation.CompanyEmail;
            dr1["CompanyBillToAddressLine1"] = sqf.Quotation.CompanyBillToAddressLine1;
            dr1["CompanyBillToAddressLine2"] = sqf.Quotation.CompanyBillToAddressLine2;
            dr1["CompanyBillToCity"] = sqf.Quotation.CompanyBillToCity;
            dr1["CompanyBillToState"] = sqf.Quotation.CompanyBillToState;
            dr1["CompanyBillToCountary"] = sqf.Quotation.CompanyBillToCountary;
            dr1["CompanyBillToPostCode"] = sqf.Quotation.CompanyBillToPostCode;

            dt1.Rows.Add(dr1);
            /*****data part*******/
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "CompanyDetailDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource1.Value = dt1;
            // end of company details

            //Customer Details
            /****column defn**/
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("CustomerName", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerBillAddress1", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerBillAddress2", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerBillAddressCity", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerBillAddressState", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerBillAddressCountary", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerBillPostCode", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerShipAddress1", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerShipAddress2", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerShipAddressCity", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerShipAddressState", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerShipAddressCountary", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerShipPostCode", typeof(string)));
            dt2.Columns.Add(new DataColumn("CustomerTelephone", typeof(string)));
            /****end column defn**/
            /**data****/
            DataRow dr2 = dt2.NewRow();
            dr2["CustomerName"] = sqf.Quotation.CustomerName;
            dr2["CustomerBillAddress1"] = sqf.Quotation.CustomerBillAddress1;
            dr2["CustomerBillAddress2"] = sqf.Quotation.CustomerBillAddress2;
            dr2["CustomerBillAddressCity"] = sqf.Quotation.CustomerBillAddressCity;
            dr2["CustomerBillAddressState"] = sqf.Quotation.CustomerBillAddressState;
            dr2["CustomerBillAddressCountary"] = sqf.Quotation.CustomerBillAddressCountary;
            dr2["CustomerBillPostCode"] = sqf.Quotation.CustomerBillPostCode;
            dr2["CustomerShipAddress1"] = sqf.Quotation.CustomerShipAddress1;
            dr2["CustomerShipAddress2"] = sqf.Quotation.CustomerShipAddress2;
            dr2["CustomerShipAddressCity"] = sqf.Quotation.CustomerShipAddressCity;
            dr2["CustomerShipAddressState"] = sqf.Quotation.CustomerShipAddressState;
            dr2["CustomerShipAddressCountary"] = sqf.Quotation.CustomerShipAddressCountary;
            dr2["CustomerShipPostCode"] = sqf.Quotation.CustomerShipPostCode;
            dr2["CustomerTelephone"] = sqf.Quotation.CustomerTelephone;
            /**end data****/
            dt2.Rows.Add(dr2);
            ReportDataSource reportDataSource2 = new ReportDataSource();
            reportDataSource2.Name = "CustomerDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource2.Value = dt2;
            //End Customer Details 

            //option 
            DataTable dt3 = new DataTable();
            dt3.Columns.Add(new DataColumn("CurrencyCode", typeof(string)));
            DataRow dr3 = dt3.NewRow();
            dr3["CurrencyCode"] = sqf.Quotation.CurrencyCode;
            dt3.Rows.Add(dr3);

            ReportDataSource reportDataSource3 = new ReportDataSource();
            reportDataSource3.Name = "OptionDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource3.Value = dt3;
            //end options
            string exefolder = System.Windows.Forms.Application.StartupPath;
            string reportPath = System.IO.Path.Combine(exefolder, @"SalesQuotation.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath; // Path of the rdlc file
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            reportViewer1.RefreshReport();
           // this.reportViewer1.Width = 75;
        }
        private void reportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {

        }
    }
}
