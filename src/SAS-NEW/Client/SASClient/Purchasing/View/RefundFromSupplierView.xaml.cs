﻿
using System;

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

namespace SDN.Purchasing.View
{
    using System.Collections.Generic;
    using System.Data;
    using SDN.Common;
    using SDN.Purchasing.ViewModel;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Interaction logic for RefundFromSupplierView.xaml
    /// </summary>
    public partial class RefundFromSupplierView : UserControl
    {
        private RefundFromSupplierViewModel _ViewModel;
        
        private bool _tabInvoked;
        public RefundFromSupplierView(RefundFromSupplierViewModel model)
        {
            InitializeComponent();
            this._ViewModel = model;
         
            this.DataContext = this._ViewModel;
            if (_ViewModel.PQDetailsEntity != null)
            {
                this.dg1.ItemsSource = this._ViewModel.PQDetailsEntity;
            }
            if(_ViewModel.MustCompare == true)
            {
                RefundDatepicker.IsEnabled = true;
                PART_TextBox.IsReadOnly = false;
            }
            else
            {
                btnNew.IsEnabled = false;
                RefundDatepicker.IsEnabled = false;
                PART_TextBox.IsReadOnly = true;
            }
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(6, 50).AsEnumerable();
        }

        private void ComboBoxlaod()
        {

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
            //foreach (var cmbbox in FindVisualChildren<ComboBox>(this))
            //{
            //    if (cmbbox.Name == "cmbSuppNameSearch")
            //    {
            //        //var selected = (cmbbox.SelectedItem as ShippingAddressEntity).ShippingID;
            //        if (cmbbox.SelectedItem as PurchaseInvoiceListEntity != null)
            //        {
            //            var selectedindex = cmbbox.SelectedIndex;
            //            _ViewModel.LoadSearchResult((cmbbox.SelectedItem as PurchaseInvoiceListEntity).SupplierName);
            //        }

            //        else
            //        {
            //            //_objViewModel.NewShipping(null);
            //        }
            //    }
            //}
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
      
        private void Item_GotFocus(object sender, RoutedEventArgs e)
        {
            //int index=dg1.SelectedIndex + 1;
            var currentRowIndex = dg1.Items.IndexOf(dg1.CurrentItem);
            _ViewModel.OnAmountChange(currentRowIndex);
        }
        private void Item_LostFocus(object sender, RoutedEventArgs e)
        {
            //int index=dg1.SelectedIndex + 1;
            var currentRowIndex = dg1.Items.IndexOf(dg1.CurrentItem);
            _ViewModel.OnAmountChangeAgain(currentRowIndex);
        }
        #endregion
        #region Events
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
    }
}
