﻿using Microsoft.Reporting.WinForms;
using SDN.Sales.ViewModel;
using SDN.UI.Entities.Sales;
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
    /// Interaction logic for CreditNoteReportViewer.xaml
    /// </summary>
    public partial class CreditNoteReportViewer : UserControl
    {
        private CreditNoteViewModel _viewModelSales;
        public CreditNoteReportViewer()
        {
            InitializeComponent();
            Type type = typeof(CreditNoteViewModel);

            //SalesInvoiceViewModel instance = (SalesInvoiceViewModel)Activator.CreateInstance(type);
            object obj = System.Runtime.Serialization.FormatterServices
             .GetUninitializedObject(type);
            _viewModelSales = (CreditNoteViewModel)obj;

            this.DataContext = obj;
        }
        public CreditNoteReportViewer(CreditNoteViewModel model) : this()
        {
            InitializeComponent();
            this.DataContext = _viewModelSales;
            _viewModelSales = model;

        }
        private void UserControl_LoadedCreditNote(object sender, RoutedEventArgs e)
        {
            //var a = _viewModel.PrintSalesQuotation();
            CreditNoteForm sqf = _viewModelSales.PrintCreditNote();

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


            foreach (var item in sqf.InvoiceDetails)
            {
                DataRow dr = dt.NewRow();
                dr["PandSCode"] = item.PandSCode;
                dr["PandSName"] = item.PandSName;
                dr["Qty"] = item.SIQty;
                dr["Price"] = item.Price.ToString();
                dr["Discount"] = item.SIDiscount;
                dr["Amount"] = item.SIAmount.ToString();
                dr["Rate"] = item.GSTRate.ToString();
                dt.Rows.Add(dr);
            }



            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "CreditNoteDetailDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource.Value = dt;
            // end of product grid code
            DataTable dt4 = new DataTable();
            //for other than table
            dt4.Columns.Add(new DataColumn("TAndCondition", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalBeforeTaxStr", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalAfterTaxStr", typeof(string)));
            dt4.Columns.Add(new DataColumn("CNNo", typeof(string)));
            dt4.Columns.Add(new DataColumn("CNDate", typeof(string)));
            dt4.Columns.Add(new DataColumn("CusDNNo", typeof(string)));
            dt4.Columns.Add(new DataColumn("CusDNDate", typeof(string)));
            dt4.Columns.Add(new DataColumn("CusDNAmount", typeof(string)));


            DataRow dr4 = dt4.NewRow();
            dr4["TAndCondition"] = sqf.CreditNote.TermsAndConditions;
            dr4["TotalBeforeTaxStr"] = sqf.CreditNote.TotalAfterTax;
            dr4["TotalTax"] = sqf.CreditNote.TotalTax.ToString();
            dr4["TotalAfterTaxStr"] = sqf.CreditNote.TotalAfterTax.ToString();
            dr4["CNNo"] = sqf.CreditNote.CreditNo;
            dr4["CNDate"] = sqf.CreditNote.CreditDate;
            dr4["CusDNNo"] = sqf.CreditNote.CustomerDebitNoteNo;
            dr4["CusDNDate"] = sqf.CreditNote.CustomerDebitNoteDate;
            dr4["CusDNAmount"] = sqf.CreditNote.CustomerDebitNoteAmount;
            dt4.Rows.Add(dr4);

            ReportDataSource reportDataSource4 = new ReportDataSource();
            reportDataSource4.Name = "CreditNoteUniqueRecordDetailDataSet"; // Name of the DataSet we set in .rdlc
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
            dr1["CompanyName"] = sqf.CreditNote.CompanyName;
            dr1["CompanyLogo"] = sqf.CreditNote.CompanyLogo;
            dr1["CompanyRegNumber"] = sqf.CreditNote.CompanyRegNumber;
            dr1["CompanyGstNumber"] = sqf.CreditNote.CompanyGstNumber;
            dr1["Telephone"] = sqf.CreditNote.Telephone;
            dr1["CompanyFax"] = sqf.CreditNote.CompanyFax;
            dr1["CompanyEmail"] = sqf.CreditNote.CompanyEmail;
            dr1["CompanyBillToAddressLine1"] = sqf.CreditNote.CompanyBillToAddressLine1;
            dr1["CompanyBillToAddressLine2"] = sqf.CreditNote.CompanyBillToAddressLine2;
            dr1["CompanyBillToCity"] = sqf.CreditNote.CompanyBillToCity;
            dr1["CompanyBillToState"] = sqf.CreditNote.CompanyBillToState;
            dr1["CompanyBillToCountary"] = sqf.CreditNote.CompanyBillToCountary;
            dr1["CompanyBillToPostCode"] = sqf.CreditNote.CompanyBillToPostCode;

            dt1.Rows.Add(dr1);
            /*****data part*******/
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "CompanyDetailsDataSet"; // Name of the DataSet we set in .rdlc
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
            dt2.Columns.Add(new DataColumn("CustomerTelephone", typeof(string)));

            /****end column defn**/
            /**data****/
            DataRow dr2 = dt2.NewRow();
            dr2["CustomerName"] = sqf.CreditNote.CustomerName;
            dr2["CustomerBillAddress1"] = sqf.CreditNote.CustomerBillAddress1;
            dr2["CustomerBillAddress2"] = sqf.CreditNote.CustomerBillAddress2;
            dr2["CustomerBillAddressCity"] = sqf.CreditNote.CustomerBillAddressCity;
            dr2["CustomerBillAddressState"] = sqf.CreditNote.CustomerBillAddressState;
            dr2["CustomerBillAddressCountary"] = sqf.CreditNote.CustomerBillAddressCountary;
            dr2["CustomerBillPostCode"] = sqf.CreditNote.CustomerBillPostCode;
            dr2["CustomerTelephone"] = sqf.CreditNote.CustomerTelephone;

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
            dr3["CurrencyCode"] = sqf.CreditNote.CurrencyCode;
            dt3.Rows.Add(dr3);

            ReportDataSource reportDataSource3 = new ReportDataSource();
            reportDataSource3.Name = "OptionsDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource3.Value = dt3;
            //end options
            string exefolder = System.Windows.Forms.Application.StartupPath;
            string reportPath = System.IO.Path.Combine(exefolder, @"CreditNote.rdlc");
           
            reportViewer5.LocalReport.ReportPath = reportPath; // Path of the rdlc file
          
            reportViewer5.LocalReport.DataSources.Clear();
            reportViewer5.LocalReport.DataSources.Add(reportDataSource);
            reportViewer5.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer5.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer5.LocalReport.DataSources.Add(reportDataSource3);
            reportViewer5.LocalReport.DataSources.Add(reportDataSource4);
            reportViewer5.RefreshReport();
            // this.reportViewer1.Width = 75;
        }
    }
}
