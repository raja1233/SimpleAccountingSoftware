using Microsoft.Reporting.WinForms;
using SASClient.Customers.Services;
using SASClient.Customers.ViewModel;
using SDN.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
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
    /// Interaction logic for UnpaidSalesInvoiceReportViewer.xaml
    /// </summary>
    public partial class UnpaidSalesInvoiceReportViewer : UserControl
    {
        private CustomersUnpaidInvoicesViewModel _ViewModel;
        //string connectionstring = "data source=108.168.203.227,7007;user id=SimpleAccounting;password=SimpleA@2017;";
        string connectionstring = SASDAL.Properties.Settings.Default.SASEntitiesEDM;

        public UnpaidSalesInvoiceReportViewer()
        {
            InitializeComponent();
            Type type = typeof(CustomersUnpaidInvoicesViewModel);

            //SalesInvoiceViewModel instance = (SalesInvoiceViewModel)Activator.CreateInstance(type);
            object obj = System.Runtime.Serialization.FormatterServices
             .GetUninitializedObject(type);
            _ViewModel = (CustomersUnpaidInvoicesViewModel)obj;

            this.DataContext = obj;
            if (connectionstring.ToLower().StartsWith("metadata="))
            {
              EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder(connectionstring);
                connectionstring = efBuilder.ProviderConnectionString;
            }
        }
        public UnpaidSalesInvoiceReportViewer(CustomersUnpaidInvoicesViewModel model):this()
        {
            InitializeComponent();
            this.DataContext = _ViewModel;
            _ViewModel = model;
        }
        private void UserControl_LoadedUnpaidSalesInvoice(object sender, RoutedEventArgs e)
        {
           

            string exefolder = System.Windows.Forms.Application.StartupPath;
            string reportPath = System.IO.Path.Combine(exefolder, @"UnpaidSalesInvoice.rdlc");

            reportViewer6.LocalReport.ReportPath = reportPath; // Path of the rdlc file  
            reportViewer6.LocalReport.DataSources.Clear();
            reportViewer6.LocalReport.DataSources.Add(new ReportDataSource("CombinedUnpaidSalesInvoicesDataSet", CombinedUnpaiddetails()));
            reportViewer6.LocalReport.DataSources.Add(new ReportDataSource("CompanyDetailsDataSet", Companydetails()));
            reportViewer6.RefreshReport();
        
            // this.reportViewer1.Width = 75;
        }
        private void reportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {

        }
        public DataTable Companydetails()
        {
            DataTable table = new DataTable();
            using (var con = new SqlConnection(connectionstring))
            using (var cmd = new SqlCommand("USP_CompanyDetails", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);
            }
            return table;
        }
        public DataTable CombinedUnpaiddetails()
        {

            SqlDataReader rdr = null;
            DataTable table = new DataTable();
            var SelectedDate = SharedValues.PrintDate;
            //var x = _ViewModel.PrintSalesOrder();
            table.Columns.Add("MyId", typeof(System.Int32));
            table.Columns.Add(new DataColumn("Balance", typeof(string)));
            table.Columns.Add(new DataColumn("Oneto30Days", typeof(string)));
            table.Columns.Add(new DataColumn("Thirtyoneto60Days", typeof(string)));
            table.Columns.Add(new DataColumn("Sixtyoneto90Days", typeof(string)));
            table.Columns.Add(new DataColumn("GreaterThen90Days", typeof(string)));
            table.Columns.Add(new DataColumn("CustomerName", typeof(string)));
            table.Columns.Add(new DataColumn("CustomerBillAddress1", typeof(string)));
            table.Columns.Add(new DataColumn("CustomerBillAddress2", typeof(string)));
            table.Columns.Add(new DataColumn("CustomerBillAddressCity", typeof(string)));
            table.Columns.Add(new DataColumn("CustomerBillAddressState", typeof(string)));
            table.Columns.Add(new DataColumn("CustomerBillAddressCountary", typeof(string)));
            table.Columns.Add(new DataColumn("CustomerBillPostCode", typeof(string)));
            table.Columns.Add(new DataColumn("CustomerTelephone", typeof(string)));
            table.Columns.Add(new DataColumn("CurrencyCode", typeof(string)));
            table.Columns.Add(new DataColumn("SelectedDate", typeof(string)));
            foreach (var id in SharedValues.CustomersID)
            {
                //var Customerid = item.CustomerID;       
                //var date1 = _ViewModel.SelectedStatementDate;
               // var 
                using (var con = new SqlConnection(connectionstring))
                using (var cmd = new SqlCommand("USP_CustomersStatementUnPaidInvoice", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@SDate", SelectedDate);
                    //cmd.Parameters.AddWithValue("@Type", "C");
                    da.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        string selecteddate = row["SelectedDate"].ToString();
                        string customerid = row["MyId"].ToString();
                        //need to set value to NewColumn column
                        if (customerid == "" && selecteddate == "")
                            row["MyId"] = id;
                            row["SelectedDate"] = SelectedDate;
                        // or set it to some other value

                    }
                }
                using (var con = new SqlConnection(connectionstring))
                using (var cmd = new SqlCommand("USP_GetStatementUnpaidInvoice_Summary", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@SDate", SelectedDate);
                    cmd.Parameters.AddWithValue("@Type", "C");
                    //da.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        con.Open();
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            string Balance = row["Balance"].ToString();
                            string Oneto30Days = row["Oneto30Days"].ToString();
                            string Thirtyoneto60Days = row["Thirtyoneto60Days"].ToString();
                            string Sixtyoneto90Days = row["Sixtyoneto90Days"].ToString();
                            string GreaterThen90Days = row["GreaterThen90Days"].ToString();
                            if (Balance == "")
                            {
                                row["Balance"] = (string)rdr["Balance"].ToString();
                                row["Oneto30Days"] = (string)rdr["Oneto30Days"].ToString();
                                row["Thirtyoneto60Days"] = (string)rdr["Thirtyoneto60Days"].ToString();
                                row["Sixtyoneto90Days"] = (string)rdr["Sixtyoneto90Days"].ToString();
                                row["GreaterThen90Days"] = (string)rdr["GreaterThen90Days"].ToString();
                            }
                        }
                        con.Close();
                    }

                }
                using (var con = new SqlConnection(connectionstring))
                using (var cmd = new SqlCommand("USP_CustomerDetails", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", id);
                    foreach (DataRow row in table.Rows)
                    {
                        con.Open();
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            string CustomerName = row["CustomerName"].ToString();
                            string CustomerBillAddress1 = row["CustomerBillAddress1"].ToString();
                            string CustomerBillAddress2 = row["CustomerBillAddress2"].ToString();
                            string CustomerBillAddressCity = row["CustomerBillAddressCity"].ToString();
                            string CustomerBillAddressState = row["CustomerBillAddressState"].ToString();
                            string CustomerBillAddressCountary = row["CustomerBillAddressCountary"].ToString();
                            string CustomerBillPostCode = row["CustomerBillPostCode"].ToString();
                            string CustomerTelephone = row["CustomerTelephone"].ToString();

                            
                            if (CustomerName == "")
                            {
                                row["CustomerName"] = (string)rdr["CustomerName"].ToString();
                                row["CustomerBillAddress1"] = (string)rdr["CustomerBillAddress1"].ToString();
                                row["CustomerBillAddress2"] = (string)rdr["CustomerBillAddress2"].ToString();
                                row["CustomerBillAddressCity"] = (string)rdr["CustomerBillAddressCity"].ToString();
                                row["CustomerBillAddressState"] = (string)rdr["CustomerBillAddressState"].ToString();
                                row["CustomerBillAddressCountary"] = (string)rdr["CustomerBillAddressCountary"].ToString();
                                row["CustomerBillPostCode"] = (string)rdr["CustomerBillPostCode"].ToString();
                                row["CustomerTelephone"] = (string)rdr["CustomerTelephone"].ToString();

                            }

                        }
                        con.Close();

                    }
                }
                using (var con = new SqlConnection(connectionstring))
                using (var cmd = new SqlCommand("USP_OptionDetails", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in table.Rows)
                    {
                        con.Open();
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            string CurrencyCode = row["CurrencyCode"].ToString();
                            if (CurrencyCode == "")
                            {
                                row["CurrencyCode"] = (string)rdr["CurrencyCode"].ToString();

                            }


                        }
                        con.Close();


                    }
                }
            }
        
           
            return table;
        }
    }
}
