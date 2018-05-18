using SDN.Common;
using SDN.Sales.ViewModel;
using SDN.UI.Entities.Sales;
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

namespace SDN.Sales.Views
{
    /// <summary>
    /// Interaction logic for SalesInvoiceListView.xaml
    /// </summary>
    public partial class SalesInvoiceListView : UserControl
    {
        private SalesInvoiceListViewModel _ViewModel;
        private bool _tabInvoked;
        public SalesInvoiceListView(SalesInvoiceListViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            _ViewModel = new SalesInvoiceListViewModel();
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(8, 50).AsEnumerable();
        }

        private void ComboBoxlaod()
        {
            cmbStatus.SelectedIndex = 1;
        }
        #region Search Functionality
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;

                }
            }
        }

        private void cmb_SupName(object sender, SelectionChangedEventArgs e)
        {
            foreach (var cmbbox in FindVisualChildren<ComboBox>(this))
            {
                if (cmbbox.Name == "cmbSuppNameSearch")
                {
                    //var selected = (cmbbox.SelectedItem as ShippingAddressEntity).ShippingID;
                    if (cmbbox.SelectedItem as SalesInvoiceListEntity != null)
                    {
                        var selectedindex = cmbbox.SelectedIndex;
                        _ViewModel.LoadSearchResult((cmbbox.SelectedItem as SalesInvoiceListEntity).CustomerName);
                    }

                    else
                    {
                        //_objViewModel.NewShipping(null);
                    }
                }
            }
        }
        #endregion
        #region Events
        private void OpenDatePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_tabInvoked) return;

            // Reset marker
            _tabInvoked = false;

            // Go to next control in sequence
            var element = Keyboard.FocusedElement as UIElement;
            if (element == null) return;
            element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        private void OpenDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            var dp = sender as DatePicker;
            if (e.Key == Key.Enter && dp != null)
            {
                //    // Mark that "tab" was pressed
                _tabInvoked = true;
                if (dp.IsDropDownOpen)
                {
                    dp.IsDropDownOpen = false;
                }
                else
                {
                    dp.IsDropDownOpen = true;
                }

            }

        }

        #endregion

        private void cmbStatus_Loaded(object sender, RoutedEventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
        }
        
    }
}
