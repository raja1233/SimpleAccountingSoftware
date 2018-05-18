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
    /// Interaction logic for CustomersDetailsList3View.xaml
    /// </summary>
    public partial class CustomersDetailsList3View : UserControl
    {
        public CustomersDetailsList3View(CustomersDetailsList1ViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(7, 50).AsEnumerable();
        }
    }
}
