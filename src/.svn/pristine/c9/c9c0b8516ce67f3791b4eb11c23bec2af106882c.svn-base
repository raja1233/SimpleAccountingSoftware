
namespace SDN.CashBank.Views
{
    using SDN.CashBank.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
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
    using UI.Entities;


    /// <summary>
    /// Interaction logic for AccountDetailView.xaml
    /// </summary>
    public partial class AccountsDetailsView : UserControl
    {
        public AccountDetailViewModel _objViewModel;
        public AccountsDetailsView(AccountDetailViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _objViewModel = model;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_objViewModel = new AccountDetailViewModel();

            //SourceContext();
            //InitialOperations();

        }

        private void SourceContext()
        {
            //this.DataContext = _objViewModel;
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

        private void cmbAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var cmbbox in FindVisualChildren<ComboBox>(this))
            {
                if (cmbbox.Name == "cmbAccInfo")
                {
                    //var selected = (cmbbox.SelectedItem as ShippingAddressEntity).ShippingID;
                    if (cmbbox.SelectedItem as AccountsEntity != null)
                    {

                        //ComboBox cb = sender as ComboBox;

                        //var item = cb.SelectedItem as AccountsEntity;
                        //string projectID = item.AccountName;

                        //if (projectID == "Stock" || projectID == "Payments Due from Customers")
                        //{
                           
                        //}
                        //else
                        //{
                        //    string varvalueactive = Visibility.Hidden.ToString();
                        //}



                        var selectedindex = cmbbox.SelectedIndex;
                        _objViewModel.LoadAccInfo((cmbbox.SelectedItem as AccountsEntity).AccountID, selectedindex);
                    }

                    else
                    {
                        //_objViewModel.NewShipping(null);
                    }
                }
            }
        }
        private void cmbAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var cmbbox in FindVisualChildren<ComboBox>(this))
            {
                if (cmbbox.Name == "cmbAccInfotype")
                {
                    //var selected = (cmbbox.SelectedItem as ShippingAddressEntity).ShippingID;
                    if (cmbbox.SelectedItem != null)
                    {
                        var selectedindex = cmbbox.SelectedIndex;
                        _objViewModel.CheckOpeningBal((cmbbox.SelectedValue));
                    }

                    else
                    {

                        //var selectedindex = cmbbox.SelectedIndex;
                        //_objViewModel.CheckOpeningBal((cmbbox.SelectedItem as AccountDetailEntity).AccuntTypeCode);
                    }

                }
            }
        }



        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[0-9]+(/.[0-9][0-9]?)?");
            //e.Handled = regex.IsMatch(e.Text);

            //Regex regex = new Regex("[^0-9]+");
            //e.Handled = regex.IsMatch(e.Text);

            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;

        }
        //        private void txtbxPlatypus_KeyPress(object sender, KeyPressEventArgs args)
        //{
        //    const int BACKSPACE = 8;
        //    const int DECIMAL_POINT = 46;
        //    const int ZERO = 48;
        //    const int NINE = 57;
        //    const int NOT_FOUND = -1;

        //    int keyvalue = (int)args.KeyChar; // not really necessary to cast to int

        //    if ((keyvalue == BACKSPACE) || 
        //    ((keyvalue >= ZERO) && (keyvalue <= NINE))) return;
        //    // Allow the first (but only the first) decimal point
        //    if ((keyvalue == DECIMAL_POINT) && 
        //    (txtbxPlatypus.Text.IndexOf(".") == NOT_FOUND)) return;
        //    // Allow nothing else
        //    args.Handled = true;
        //}
    }
}
