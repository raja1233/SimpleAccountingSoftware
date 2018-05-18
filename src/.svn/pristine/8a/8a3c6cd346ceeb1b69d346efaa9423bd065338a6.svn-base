using Microsoft.Reporting.WinForms;
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
    /// Interaction logic for PurchaseQuotationReportViewer.xaml
    /// </summary>
    public partial class PurchaseQuotationReportViewer : UserControl
    {
        private PurchaseQuotationViewModel _viewModelSales;
        public PurchaseQuotationReportViewer()
        {
            InitializeComponent();
            Type type = typeof(PurchaseQuotationViewModel);

            //SalesQuotationViewModel instance = (SalesQuotationViewModel)Activator.CreateInstance(type);
            object obj = System.Runtime.Serialization.FormatterServices
             .GetUninitializedObject(type);
            _viewModelSales = (PurchaseQuotationViewModel)obj;

            this.DataContext = obj;
        }
        public PurchaseQuotationReportViewer(PurchaseQuotationViewModel model) : this()
        {
            InitializeComponent();
            this.DataContext = _viewModelSales;
            _viewModelSales = model;

        }

        private void UserControl_LoadedPurchaseQuotation(object sender, RoutedEventArgs e)
        {
            //var a = _viewModel.PrintSalesQuotation();
            PurchaseQuotationForm sqf = _viewModelSales.PrintPurchaseQuotation();

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
                dr["Qty"] = item.PQQty;
                dr["Price"] = item.Price.ToString();
                dr["Discount"] = item.PQDiscount;
                dr["Amount"] = item.PQAmount.ToString();
                dr["Rate"] = item.GSTRate.ToString();
                dt.Rows.Add(dr);
            }



            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "PurchaseQuotationDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource.Value = dt;
            // end of product grid code
            DataTable dt4 = new DataTable();
            //for other than table
            dt4.Columns.Add(new DataColumn("TAndCondition", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalBeforeTaxStr", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalAfterTaxStr", typeof(string)));
            dt4.Columns.Add(new DataColumn("PQNo", typeof(string)));
            dt4.Columns.Add(new DataColumn("PQDate", typeof(string)));
            dt4.Columns.Add(new DataColumn("ValidForDays", typeof(int)));

            DataRow dr4 = dt4.NewRow();
            dr4["TAndCondition"] = sqf.Quotation.TermsAndConditions;
            dr4["TotalBeforeTaxStr"] = sqf.Quotation.TotalAfterTax;
            dr4["TotalTax"] = sqf.Quotation.TotalTax.ToString();
            dr4["TotalAfterTaxStr"] = sqf.Quotation.TotalAfterTax.ToString();
            dr4["PQNo"] = sqf.Quotation.QuotationNo;
            dr4["PQDate"] = sqf.Quotation.QuotationDate.Date.ToString("dd/M/yyyy");
            dr4["ValidForDays"] = sqf.Quotation.ValidForDays;
            dt4.Rows.Add(dr4);

            ReportDataSource reportDataSource4 = new ReportDataSource();
            reportDataSource4.Name = "PurchaseQuotationUniqueRecordDetailsDataSet"; // Name of the DataSet we set in .rdlc
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
            dr1["CompanyShipToLine1"] = sqf.Quotation.CompanyShipToAddressLine1;
            dr1["CompanyShipToLine2"] = sqf.Quotation.CompanyShipToAddressLine2;
            dr1["CompanyShipToCity"] = sqf.Quotation.CompanyShipToCity;
            dr1["CompanyShipToState"] = sqf.Quotation.CompanyShipToState;
            dr1["CompanyShipToCountary"] = sqf.Quotation.CompanyShipToCountary;
            dr1["CompanyShipToPostCode"] = sqf.Quotation.CompanyShipToPostCode;

            dt1.Rows.Add(dr1);
            /*****data part*******/
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "CompanyDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource1.Value = dt1;
            // end of company details

            //Customer Details
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
            dr2["SupplierName"] = sqf.Quotation.SupplierName;
            dr2["SupplierBillToLine1"] = sqf.Quotation.SupplierBillAddress1;
            dr2["SupplierBillToLine2"] = sqf.Quotation.SupplierBillAddress2;
            dr2["SupplierBillToCity"] = sqf.Quotation.SupplierBillAddressCity;
            dr2["SupplierBillToState"] = sqf.Quotation.SupplierBillAddressState;
            dr2["SupplierBillToCountary"] = sqf.Quotation.SupplierBillAddressCountary;
            dr2["SupplierBillToPostCode"] = sqf.Quotation.SupplierBillPostCode;
            dr2["SupplierTelephone"] = sqf.Quotation.SupplierTelephone;

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
            dr3["CurrencyCode"] = sqf.Quotation.CurrencyCode;
            dt3.Rows.Add(dr3);

            ReportDataSource reportDataSource3 = new ReportDataSource();
            reportDataSource3.Name = "OptionsDetailsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource3.Value = dt3;
            //end options
            string exefolder = System.Windows.Forms.Application.StartupPath;
            string reportPath = System.IO.Path.Combine(exefolder, @"PurchaseQuotation.rdlc");
            reportViewer9.LocalReport.ReportPath = reportPath;
            //D:\DayUser\src\SAS - NEW\Client\SASClient\Reports\ReportsRdlc
            reportViewer9.LocalReport.DataSources.Clear();
            reportViewer9.LocalReport.DataSources.Add(reportDataSource);
            reportViewer9.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer9.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer9.LocalReport.DataSources.Add(reportDataSource3);
            reportViewer9.LocalReport.DataSources.Add(reportDataSource4);
            reportViewer9.RefreshReport();
            // this.reportViewer1.Width = 75;
        }
        private void reportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {

        }
    }
}
