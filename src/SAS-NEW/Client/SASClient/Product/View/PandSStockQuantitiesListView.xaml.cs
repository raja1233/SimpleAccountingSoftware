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
using System.Windows.Threading;

namespace SDN.Product.View
{
    /// <summary>
    /// Interaction logic for PandSStockQuantitiesListView.xaml
    /// </summary>
    public partial class PandSStockQuantitiesListView : UserControl
    {
        public PandSStockQuantitiesListView(PandSStockQuantitiesListViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(9, 50).AsEnumerable();
            
        }

        private async void cmbLoadEvent(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            cmb1Cat1.SelectedIndex = 0;
        }
        private async void cmbLoadEventCat2(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            cmb1Cat2.SelectedIndex = 0;
        }
        private void CheckIfEmpty(object sender, RoutedEventArgs e)
        {
            if (cmb1Cat1.SelectedItem == null)
            {
                cmb1Cat1.SelectedIndex = 0;
            }
        }
    }
}
