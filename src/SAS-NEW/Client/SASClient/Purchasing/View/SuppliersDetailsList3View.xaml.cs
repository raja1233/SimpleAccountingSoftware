using SASClient.Purchasing.ViewModel;
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

namespace SASClient.Purchasing.View
{
    /// <summary>
    /// Interaction logic for SuppliersDetailsList3View.xaml
    /// </summary>
    public partial class SuppliersDetailsList3View : UserControl
    {
        public SuppliersDetailsList3View(SuppliersDetailsListViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(7, 50).AsEnumerable();
        }
    }
}
