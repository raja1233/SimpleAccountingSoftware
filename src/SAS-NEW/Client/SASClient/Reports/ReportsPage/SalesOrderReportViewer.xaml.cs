﻿using Microsoft.Reporting.WinForms;
using SDN.Sales.ViewModel;
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
    /// Interaction logic for SalesOrderReportViewer.xaml
    /// </summary>
    public partial class SalesOrderReportViewer : UserControl
    {
        private SalesOrderViewModel _viewModel;
        public SalesOrderReportViewer()
        {
            InitializeComponent();
            InitializeComponent();
            Type type = typeof(SalesOrderViewModel);

            //SalesQuotationViewModel instance = (SalesQuotationViewModel)Activator.CreateInstance(type);
            object obj = System.Runtime.Serialization.FormatterServices
             .GetUninitializedObject(type);

            _viewModel = (SalesOrderViewModel)obj;

            this.DataContext = obj;
        }
        public SalesOrderReportViewer(SalesOrderViewModel model) : this()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
            _viewModel = model;
        }
        private void UserControl_LoadedSalesOrder(object sender, RoutedEventArgs e)
        {
            SalesOrderForm sqf = _viewModel.PrintSalesOrder();

            //this is for table grid

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PandSCode", typeof(string)));
            dt.Columns.Add(new DataColumn("PandSName", typeof(string)));
            dt.Columns.Add(new DataColumn("SOQty", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("SODiscount", typeof(string)));
            dt.Columns.Add(new DataColumn("SOAmount", typeof(string)));
            dt.Columns.Add(new DataColumn("GSTRate", typeof(string)));

            //ReportingDataset ds = new ReportingDataset();


            foreach (var item in sqf.OrderDetails)
            {
                DataRow dr = dt.NewRow();
                dr["PandSCode"] = item.PandSCode;
                dr["PandSName"] = item.PandSName;
                dr["SOQty"] = item.SOQty;
                dr["Price"] = item.Price.ToString();
                dr["SODiscount"] = item.SODiscount;
                dr["SOAmount"] = item.SOAmount.ToString();
                dr["GSTRate"] = item.GSTRate.ToString();
                dt.Rows.Add(dr);
            }



            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "SalesOrderDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource.Value = dt;
            // end of product grid code
            DataTable dt4 = new DataTable();
            //for other than table
            dt4.Columns.Add(new DataColumn("TermsAndConditions", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalBeforeTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("TotalAfterTax", typeof(string)));
            dt4.Columns.Add(new DataColumn("SONo", typeof(string)));
            dt4.Columns.Add(new DataColumn("OrderDate", typeof(string)));
            dt4.Columns.Add(new DataColumn("CusPoNo", typeof(string)));
            dt4.Columns.Add(new DataColumn("DeliveryDate", typeof(string)));

            DataRow dr4 = dt4.NewRow();
            dr4["TermsAndConditions"] = sqf.Order.TermsAndConditions;
            dr4["TotalBeforeTax"] = sqf.Order.TotalAfterTax;
            dr4["TotalTax"] = sqf.Order.TotalTax.ToString();
            dr4["TotalAfterTax"] = sqf.Order.TotalAfterTax.ToString();
            dr4["SONo"] = sqf.Order.OrderNo;
            dr4["OrderDate"] = sqf.Order.OrderDate.Date.ToString("dd/M/yyyy");
            dr4["CusPoNo"] = sqf.Order.Cus_Po_No;
            dr4["DeliveryDate"] = sqf.Order.DeliveryDate.Date.ToString("dd/M/yyyy");
            dt4.Rows.Add(dr4);

            ReportDataSource reportDataSource4 = new ReportDataSource();
            reportDataSource4.Name = "SalesOrderUniqueRecordDataSet"; // Name of the DataSet we set in .rdlc
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
            dr2["CustomerName"] = sqf.Order.CustomerName;
            dr2["CustomerBillAddress1"] = sqf.Order.CustomerBillAddress1;
            dr2["CustomerBillAddress2"] = sqf.Order.CustomerBillAddress2;
            dr2["CustomerBillAddressCity"] = sqf.Order.CustomerBillAddressCity;
            dr2["CustomerBillAddressState"] = sqf.Order.CustomerBillAddressState;
            dr2["CustomerBillAddressCountary"] = sqf.Order.CustomerBillAddressCountary;
            dr2["CustomerBillPostCode"] = sqf.Order.CustomerBillPostCode;
            dr2["CustomerShipAddress1"] = sqf.Order.CustomerShipAddress1;
            dr2["CustomerShipAddress2"] = sqf.Order.CustomerShipAddress2;
            dr2["CustomerShipAddressCity"] = sqf.Order.CustomerShipAddressCity;
            dr2["CustomerShipAddressState"] = sqf.Order.CustomerShipAddressState;
            dr2["CustomerShipAddressCountary"] = sqf.Order.CustomerShipAddressCountary;
            dr2["CustomerShipPostCode"] = sqf.Order.CustomerShipPostCode;
            dr2["CustomerTelephone"] = sqf.Order.CustomerTelephone;

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
            dr3["CurrencyCode"] = sqf.Order.CurrencyCode;
            dt3.Rows.Add(dr3);

            ReportDataSource reportDataSource3 = new ReportDataSource();
            reportDataSource3.Name = "OptionsDataSet"; // Name of the DataSet we set in .rdlc
            reportDataSource3.Value = dt3;
            //end options
            string exefolder = System.Windows.Forms.Application.StartupPath;
            string reportPath = System.IO.Path.Combine(exefolder, @"SalesOrder.rdlc");
          
            ReportViewer2.LocalReport.ReportPath = reportPath; // Path of the rdlc file
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            ReportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            ReportViewer2.LocalReport.DataSources.Add(reportDataSource4);
            ReportViewer2.RefreshReport();
            
        }
        private void reportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {

        }
    }
}
