﻿using System;
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

namespace SDN.Purchasing.View
{
    using SDN.Purchasing.ViewModel;
    using System.Data;
    using SDN.UI.Entities;
    using System.Collections;
    //using Microsoft.Windows.Controls.Primitives;
    using System.ComponentModel;
    using System.Windows.Threading;
    using Common;

    /// <summary>
    /// Interaction logic for PurchaseInvoiceBEView.xaml
    /// </summary>
    public partial class PurchaseInvoiceBEView : UserControl
    {
        #region Fields

        // Member variables
        public PurchaseInvoiceBEViewModel pandsViewModel;
        private bool _tabInvoked;

        #endregion
        public PurchaseInvoiceBEView(PurchaseInvoiceBEViewModel model)
        {
            InitializeComponent();
            this.pandsViewModel = model;
            //  this.pandsViewModel = PurchaseQuotationViewModel.GetInstance();
            this.DataContext = model;
           
            if (pandsViewModel.BEDetailsEntity != null)
            {
                this.grdPandS.ItemsSource = this.pandsViewModel.BEDetailsEntity;
                
            }
            if(pandsViewModel.MustCompare == true)
            {
                PART_TextBox.IsReadOnly = false;
                PART_TextBox1.IsReadOnly = false;
                PayDueDatepicker.IsEnabled = true;
                InvoiceDatepicker.IsEnabled = true;
            }
            else
            {
                btnNew.IsEnabled = false;
                PART_TextBox.IsReadOnly = true;
                PART_TextBox1.IsReadOnly = true;
                PayDueDatepicker.IsEnabled = false;
                InvoiceDatepicker.IsEnabled = false;
            }
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(4, 50).AsEnumerable();
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
        public int ManageDuplicatePandS()
        {
            return pandsViewModel.ManageDuplicatePandS();
        }


        private void grdPandS_GotFocus(object sender, RoutedEventArgs e)
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



        private void grdPandS_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                int retunedRowIndex = -1;
                pandsViewModel.CalculateTotal();
                DataGridColumn column = grdPandS.CurrentColumn;
                DataGrid pdGrid = sender as DataGrid;
                if (column != null && column.Header != null)
                {
                    var focusedElement = Keyboard.FocusedElement as UIElement;
                    TextBlock cmbPandSHeader = column.Header as TextBlock;
                    //if (column.Header.ToString().Contains("%"))
                    //{
                       retunedRowIndex = ManageDuplicatePandS();
                    //if (retunedRowIndex > -1)
                    //{
                    //    focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                    //}
                    //}
                    e.Handled = true;
                }

            }
        }


        private void Item_GotFocus(object sender, RoutedEventArgs e)
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

        private void PandSCodeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox drp = sender as ComboBox;

            if (drp != null)
            {
                int indexnum = drp.SelectedIndex;
               
                    var item = drp.Items[indexnum] as PandSDetailsModel;
                    if (item != null)
                    {
                        var psCod = item.PSCode;
                        if (psCod != null)
                        {
                            ManageDuplicatePandS();
                            var focusedElement = Keyboard.FocusedElement as UIElement;
                            focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
                            // e.Handled = true;
                        }
                   
                     }
                e.Handled = true;
            }

        }

        private void grdPandS_KeyUp(object sender, KeyEventArgs e)
       {
            //if (e.OriginalSource.GetType() ==typeof(DataGridCell))
            //{   DataGrid dg = sender as DataGrid;
            if (e.Key == Key.Escape)
            {
                //dg.CommitEdit();
                if (btnSave.IsEnabled == true)
                {
                    btnSave.Focus();
                }
                else
                {
                    cmbSupplierName.IsEditable = true;
                    cmbSupplierName.Focus();
                }
            }
        }
    }
}
