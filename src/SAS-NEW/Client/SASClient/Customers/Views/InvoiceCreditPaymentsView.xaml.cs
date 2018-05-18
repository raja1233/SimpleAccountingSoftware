using SASClient.Customers.ViewModel;
using SDN.Common;
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

namespace SASClient.Customers.Views
{
    /// <summary>
    /// Interaction logic for InvoiceCreditPaymentsView.xaml
    /// </summary>
    public partial class InvoiceCreditPaymentsView : UserControl
    {
        InvoiceCreditPaymentsViewModel _ViewModel;
        public InvoiceCreditPaymentsView(InvoiceCreditPaymentsViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _ViewModel = model;
            CustomGridLines1.ItemsSource = DataGridTableCollection.GridLines(5, 50).AsEnumerable();
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(2, 50).AsEnumerable();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in _ViewModel.LstCustomers)
            {
                item.IsSelected = true;
            }
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in _ViewModel.LstCustomers)
            {
                item.IsSelected = false;
            }
        }
    }
}
