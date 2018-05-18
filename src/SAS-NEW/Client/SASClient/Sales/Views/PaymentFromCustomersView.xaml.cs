using System;
using System.Collections.Generic;
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
    using SDN.UI.Entities;
    using SDN.Sales.ViewModel;
    using Common;
    using System.Data;

    /// <summary>
    /// Interaction logic for PaymentFromCustomersView.xaml
    /// </summary>
    public partial class PaymentFromCustomersView : UserControl
    {
        private PaymentFromCustomersViewModel _ViewModel;
        private bool _tabInvoked;
        public PaymentFromCustomersView(PaymentFromCustomersViewModel model)
        {
            InitializeComponent();
            this._ViewModel = model;
            //  this.pandsViewModel = PurchaseQuotationViewModel.GetInstance();
            this.DataContext = this._ViewModel;
            if (_ViewModel.PQDetailsEntity != null)
            {
                this.dg1.ItemsSource = this._ViewModel.PQDetailsEntity;
            }
            if(_ViewModel.MustCompare == true)
            {
               
                PART_TextBox.IsReadOnly = false;
                PayFromCustomerDatepicker.IsEnabled = true;
            }
            else
            {
                btnNew.IsEnabled = false;
                PART_TextBox.IsReadOnly = true;
                PayFromCustomerDatepicker.IsEnabled = false;
                btnSave.IsEnabled = false;
            }
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(7, 50).AsEnumerable();
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
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            using (tb.DeclareChangeBlock())
            {
                foreach (var c in e.Changes)
                {
                    if (c.AddedLength == 0) continue;
                    tb.Select(c.Offset, c.AddedLength);
                    if (tb.SelectedText.Contains('.'))
                    {
                        tb.SelectedText = tb.SelectedText.Replace('.', '/');

                    }
                    if (tb.SelectedText.Contains('-'))
                    {
                        tb.SelectedText = tb.SelectedText.Replace('-', '/');
                    }
                    tb.Select(c.Offset + c.AddedLength, 0);
                }
            }

        }
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
        private void Item_GotFocus(object sender, RoutedEventArgs e)
        {
            //int index=dg1.SelectedIndex + 1;
            var currentRowIndex = dg1.Items.IndexOf(dg1.CurrentItem);
            _ViewModel.OnAmountChange(currentRowIndex);
        }
        private void Item_LostFocus(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = dg1.Items.IndexOf(dg1.CurrentItem);
            _ViewModel.OnAmountChangeAgain(currentRowIndex);
        }
        #endregion
    }
}
