using SASClient.CashBank.ViewModels;
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

namespace SASClient.CashBank.Views
{
    /// <summary>
    /// Interaction logic for CashBankStatement.xaml
    /// </summary>
    public partial class CashBankStatement : UserControl
    {
      
        private CashBankStatementViewModel _ViewModel;
        public CashBankStatement(CashBankStatementViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _ViewModel = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(7, 50).AsEnumerable();
            CustomGridLines1.ItemsSource = DataGridTableCollection.GridLines(2, 50).AsEnumerable();

        }
        private void ComboBoxlaod()
        {
            //cmbStatus.SelectedIndex = 1;

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
        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    foreach (var item in _ViewModel.CashBankStatementList)
        //    {
        //        item.IsSelected = true;
        //    }
        //}
        //private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        //{
        //    foreach (var item in _ViewModel.CashBankStatementList)
        //    {
        //        item.IsSelected = false;
        //    }
        //}

        //private void cmb_SupName(object sender, SelectionChangedEventArgs e)
        //{
        //    foreach (var cmbbox in FindVisualChildren<ComboBox>(this))
        //    {
        //        if (cmbbox.Name == "cmbSuppNameSearch")
        //        {
        //            //var selected = (cmbbox.SelectedItem as ShippingAddressEntity).ShippingID;
        //            if (cmbbox.SelectedItem as CashBankStatementViewModel != null)
        //            {
        //                var selectedindex = cmbbox.SelectedIndex;
        //                _ViewModel.LoadSearchResult((cmbbox.SelectedItem as CashBankStatementViewModel).CustomerName);
        //            }

        //            else
        //            {
        //                //_objViewModel.NewShipping(null);
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
