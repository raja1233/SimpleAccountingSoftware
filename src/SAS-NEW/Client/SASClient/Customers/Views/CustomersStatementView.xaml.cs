
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDN.Customers.Views
{
    using SDN.Customers.ViewModel;
    using System.Windows.Controls;
    /// <summary>
    /// Interaction logic for CustomersStatementView.xaml
    /// </summary>
    public partial class CustomersStatementView : UserControl
    {
        public CustomersStatementView(CustomersViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
