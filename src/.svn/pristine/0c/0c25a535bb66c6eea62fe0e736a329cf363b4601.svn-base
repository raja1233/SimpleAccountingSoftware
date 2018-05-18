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
    /// Interaction logic for CustomerPaymentDueDaysView.xaml
    /// </summary>
    public partial class CustomerPaymentDueDaysView : UserControl
    {

        public CustomerPaymentDueDaysView(CustomerPaymentDueDaysViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(6, 50).AsEnumerable();
        }
    }
}
