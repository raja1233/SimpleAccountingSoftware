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

    //using Microsoft.Windows.Controls.Primitives;


    /// <summary>
    /// Interaction logic for PurchaseOrderView.xaml
    /// </summary>
    public partial class PurchaseOrderView : UserControl
    {
        #region Fields

        // Member variables
        public PurchaseOrderViewModel pandsViewModel;
        private bool _tabInvoked;
        bool m_excludeTax = false;

        #endregion

        public PurchaseOrderView(PurchaseOrderViewModel model)
        {
            InitializeComponent();
            this.pandsViewModel = model;
            //  this.pandsViewModel = PurchaseOrderViewModel.GetInstance();
            this.DataContext = this.pandsViewModel;
            if (pandsViewModel.PODetailsEntity != null)
            {
                this.grdPandS.ItemsSource = this.pandsViewModel.PODetailsEntity;
            }
            if(pandsViewModel.MustCompare == true)
            {
                PART_TextBox.IsReadOnly = false;
                PART_TextBox1.IsReadOnly = false;
                POrderDatepicker.IsEnabled = true;
                PDeliverDatepicker.IsEnabled = true;
            }
            else
            {
                btnNew.IsEnabled = false;
                PART_TextBox.IsReadOnly = true;
                PART_TextBox1.IsReadOnly = true;
                POrderDatepicker.IsEnabled = false;
                PDeliverDatepicker.IsEnabled = false;
            }
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(8, 50).AsEnumerable();
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
            if ((bool)rdnIncludeGST.IsChecked)
            {
                m_excludeTax = false;
            }
            else
            {
                m_excludeTax = true;
            }
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
                pandsViewModel.CalculateTotal(m_excludeTax);
                DataGridColumn column = grdPandS.CurrentColumn;
                DataGrid pdGrid = sender as DataGrid;
                if (column != null && column.Header != null)
                    {
                    var focusedElement = Keyboard.FocusedElement as UIElement;
                     TextBlock cmbPandSHeader = column.Header as TextBlock;
                    if (pandsViewModel.QtyJumptoNextRow == true && cmbPandSHeader != null)
                    {
                        if (cmbPandSHeader.Name.Equals("txtHeaderPandSname", StringComparison.CurrentCultureIgnoreCase))
                        {
                            retunedRowIndex = ManageDuplicatePandS();
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
                    else if (column.Header.ToString() == "Amount")
                    {
                        retunedRowIndex = ManageDuplicatePandS();
                        if (retunedRowIndex > -1)
                        {
                            focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                        }
                    }
                    // e.Handled = true;
                }
            }
        }

        private void grdPandS_LostFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                int retunedRowIndex = -1;
                pandsViewModel.CalculateTotal(m_excludeTax);
                DataGridColumn column = grdPandS.CurrentColumn;
                DataGrid pdGrid = sender as DataGrid;
                if (column != null && column.Header != null)
                {
                    var focusedElement = Keyboard.FocusedElement as UIElement;
                    TextBlock cmbPandSHeader = column.Header as TextBlock;
                    if (pandsViewModel.QtyJumptoNextRow == true && cmbPandSHeader != null)
                    {
                        if (cmbPandSHeader.Name.Equals("txtHeaderPandSname", StringComparison.CurrentCultureIgnoreCase))
                        {
                            retunedRowIndex = ManageDuplicatePandS();
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
                    else if (column.Header.ToString() == "Amount")
                    {
                        retunedRowIndex = ManageDuplicatePandS();
                        if (retunedRowIndex > -1)
                        {
                            focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                        }
                    }
                    // e.Handled = true;
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
                if (pandsViewModel.QtyJumptoNextRow == true && indexnum >= 0)
                {
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
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            try
            {
                Convert.ToInt32(e.Text);
            }
            catch
            {
                // Show some kind of error message if you want

                // Set handled to true
                e.Handled = true;
            }
        }
        private void OnPreviewTextInputDecPrice(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            try
            {
                Convert.ToDecimal(e.Text);
            }
            catch
            {
                // Show some kind of error message if you want

                // Set handled to true
                e.Handled = true;
            }
        }
    }
}








