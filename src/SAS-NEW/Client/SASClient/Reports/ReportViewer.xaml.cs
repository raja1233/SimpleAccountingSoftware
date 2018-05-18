using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

namespace SASClient.Reports
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : UserControl
    {
        public ReportViewer()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //DataTable dt = new DataTable();
            //for (int i = 0; i < 2; i++)
            //{

            //    //  dt.Columns.Add(new DataColumn("CountryId", typeof(int)));
            //    dt.Columns.Add(new DataColumn("CountryName", typeof(string)));

            //    //dt.Columns.Add(new DataColumn("OrderAmount", typeof(int)));
            //    //ReportingDataset ds = new ReportingDataset();

            //    DataRow dr = dt.NewRow();
            //    //     dr["CountryId "] = 1;
            //    dr["CountryName"] = "CK Nitin";

            //    // dr["OrderAmount"] = 100;
            //    dt.Rows.Add(dr);
            //}




            //ReportDataSource reportDataSource = new ReportDataSource();
            //reportDataSource.Name = "CountryDataSet"; // Name of the DataSet we set in .rdlc
            //reportDataSource.Value = dt;
            DataTable dt1 = new DataTable();
            dt1 = x();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("CountryDataSet", dt1));
            reportViewer.LocalReport.ReportPath = "D:\\DayUsers\\src\\SAS-NEW\\Client\\SASClient\\Reports\\CustomerReport.rdlc"; // Path of the rdlc file

            
            reportViewer.RefreshReport();
        }
        //private void reportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        //{

        //}
       
        public DataTable x()
        {
            string[] arr2 = { "one", "two", "three" };
            DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("TransactionNo", typeof(string)));
            dt.Columns.Add(new DataColumn("CountryName", typeof(string)));
            foreach (var item in arr2)
            {
                DataRow dr2 = dt.NewRow();
                dr2["CountryName"] =item;
                dt.Rows.Add(dr2);
            }
               
           
            return dt;
        }
    }
   
}
