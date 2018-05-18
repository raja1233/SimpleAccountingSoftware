﻿
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

namespace SDN.Product.View
{
    using Common;
    using SDN.Product.ViewModel;
    using System.Data;

    /// <summary>
    /// Interaction logic for CountAndAdjustStockView.xaml
    /// </summary>
    public partial class CountAndAdjustStockView : UserControl
    {
        private CountAndAdjustStockViewModel _ViewModel;
        private bool _tabInvoked;
        public CountAndAdjustStockView(CountAndAdjustStockViewModel model)
        {
            InitializeComponent();
            _ViewModel = model;
            //  this.pandsViewModel = PurchaseQuotationViewModel.GetInstance();
            this.DataContext = model;
            if (_ViewModel.PSDetailsEntity != null)
            {
                this.dg1.ItemsSource = this._ViewModel.PSDetailsEntity;
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
        private void Item_GotFocus(object sender, RoutedEventArgs e)
        {
            DataGrid grd = (DataGrid)sender;
            if (grd != null)
            {
                grd.BeginEdit(e);

            }
            var currentRowIndex = dg1.Items.IndexOf(dg1.CurrentItem);

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

                    if (column.Header.ToString() == "System Qty")
                    {
                        retunedRowIndex = _ViewModel.ManageDuplicatePandS();

                        if (focusedElement != null)
                        {
                            if (retunedRowIndex > -1)
                            {
                                focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                            }
                            else
                            {
                                focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
                            }
                        }
                    }
                }
                // e.Handled = true;
            }
        }

        public int ManageDuplicatePandS()
        {
            return _ViewModel.ManageDuplicatePandS();
        }

        //private void dg1_LostFocus(object sender, RoutedEventArgs e)
        //  {
        //    var sd = sender as DataGrid;
        //    if(sd!=null)
        //    if (e.OriginalSource.GetType() == typeof(DataGridCell))
        //    {
        //        int retunedRowIndex = -1;

        //        DataGridColumn column = dg1.CurrentColumn;
        //        //DataGrid pdGrid = sender as DataGrid;
        //        if (column != null && column.Header != null)
        //        {
        //            var focusedElement = Keyboard.FocusedElement as UIElement;
        //            TextBlock cmbPandSHeader = column.Header as TextBlock;

        //            if (column.Header.ToString() == "Count Qty")
        //            {
        //                retunedRowIndex = _ViewModel.ManageDuplicatePandS();
        //                    if (retunedRowIndex > -1)
        //                    {
        //                        focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
        //                    }
        //                    else
        //                    {
        //                        focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
        //                    }
        //                }
        //        }
        //        // e.Handled = true;
        //    }
        //}
    }
}