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

namespace SASClient.Purchasing.View
{
    using SASClient.Purchasing.ViewModel;
    using SDN.Common;
    using System.Data;

    /// <summary>
    /// Interaction logic for SuppliersStatementUnPaidInvoicesView.xaml
    /// </summary>
    public partial class SuppliersUnPaidInvoicesView : UserControl
    {
        SuppliersUnpaidInvoicesViewModel _ViewModel;
        private bool _tabInvoked;
        public SuppliersUnPaidInvoicesView(SuppliersUnpaidInvoicesViewModel model)
        {
            
            InitializeComponent();
            this.DataContext = model;
            _ViewModel = model;
            CustomGridLines1.ItemsSource = DataGridTableCollection.GridLines(2, 50).AsEnumerable();
            CustomGridLines2.ItemsSource = DataGridTableCollection.GridLines(5, 50).AsEnumerable();
            CustomGridLines3.ItemsSource = DataGridTableCollection.GridLines(6, 50).AsEnumerable();
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
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in _ViewModel.LstSuppliers)
            {
                item.IsSelected = true;
            }
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in _ViewModel.LstSuppliers)
            {
                item.IsSelected = false;
            }
        }
        #endregion

        private void dg1_Loaded(object sender, RoutedEventArgs e)
        {
            //dg1.SelectedIndex = 0;
        }
    }
}
