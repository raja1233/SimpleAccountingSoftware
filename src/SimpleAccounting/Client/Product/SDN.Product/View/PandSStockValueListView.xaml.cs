using SDN.Common;
using SDN.Product.ViewModel;
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

namespace SDN.Product.View
{
    /// <summary>
    /// Interaction logic for PandSStockValueListView.xaml
    /// </summary>
    public partial class PandSStockValueListView : UserControl
    {
        public PandSStockValueListView(PandSStockValueListViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(7, 50).AsEnumerable();
        }
        private async void cmbLoadEvent(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000);
            cmb1Cat1.SelectedIndex = 0;
        }
        private async void cmbLoadEventCat2(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000);
            cmb1Cat2.SelectedIndex = 0;
        }
    }
}
