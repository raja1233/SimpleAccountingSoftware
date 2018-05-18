using SASClient.Accounts.ViewModel;
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

namespace SASClient.Accounts.Views
{
    /// <summary>
    /// Interaction logic for UndeliveredSalesOrdersWithDepositsView.xaml
    /// </summary>
    public partial class UndeliveredSalesOrdersWithDepositsView : UserControl
    {
        private UndeliveredSalesOrdersWithDepositsViewModel _ViewModel;
        public UndeliveredSalesOrdersWithDepositsView(UndeliveredSalesOrdersWithDepositsViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _ViewModel = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(9, 50).AsEnumerable();
        }

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
      
        private void Item_GotFocus1(object sender, RoutedEventArgs e)
        {
            ComboBox cmbBox = sender as ComboBox;
            if (cmbBox != null)
            {
                if (cmbBox.IsDropDownOpen == false)
                {
                    ((ComboBox)sender).IsDropDownOpen = true;
                }
            }

        }
        private void dg1_GotFocus(object sender, RoutedEventArgs e)
        {
            // Lookup for the source to be DataGridCell
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                // Starts the Edit on the row;
                DataGrid grd = (DataGrid)sender;
                if (grd != null)
                {
                    grd.BeginEdit(e);

                }
            }

        }
        private void dg1_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                int retunedRowIndex = -1;

                DataGridColumn column = dg1.CurrentColumn;
                //DataGrid pdGrid = sender as DataGrid;
                if (column != null && column.Header != null)
                {
                    var focusedElement = Keyboard.FocusedElement as UIElement;
                    TextBlock cmbPandSHeader = column.Header as TextBlock;

                    if (column.Header.ToString() == "Deposit Amount")
                    {
                        retunedRowIndex = _ViewModel.ManageDuplicateUnpaidSalesInvoice();

                        if (focusedElement != null)
                        {
                            if (retunedRowIndex > -1)
                            {
                                focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                            }

                        }
                    }
                }
                // e.Handled = true;
            }
        }
    }
}
