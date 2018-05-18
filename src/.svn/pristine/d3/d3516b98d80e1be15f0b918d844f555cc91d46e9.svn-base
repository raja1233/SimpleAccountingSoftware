using SDN.Common;
using SDN.Product.ViewModel;
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

namespace SDN.Product.View
{
    /// <summary>
    /// Interaction logic for PandSSoldView.xaml
    /// </summary>
    public partial class PandSSoldView : UserControl
    {
        private PandSSoldViewModel _ViewModel;
        private bool _tabInvoked;
        public PandSSoldView(PandSSoldViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            // _ViewModel = new PurchaseQuotationListViewModel();
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(8, 50).AsEnumerable();
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
            //        if (cmbbox.SelectedItem as PurchaseQuotationListEntity != null)
            //        {
            //            var selectedindex = cmbbox.SelectedIndex;
            //            _ViewModel.LoadSearchResult((cmbbox.SelectedItem as PurchaseQuotationListEntity).SupplierName);
            //        }

            //        else
            //        {
            //            //_objViewModel.NewShipping(null);
            //        }
            //    }
            //}
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

        private void setInvoiceColumnFalse(bool? isHideInvoiceColumn)
        {
            if (isHideInvoiceColumn == true)
            {
                var extrawidth = Convert.ToDouble(this.dg1.Columns[6].ActualWidth) + Convert.ToDouble(this.dg1.Columns[7].ActualWidth);
                var qtywidth = Convert.ToDouble(this.dg1.Columns[3].ActualWidth) + Convert.ToDouble(54);
                var pricewidth = Convert.ToDouble(this.dg1.Columns[4].ActualWidth) + Convert.ToDouble(54);
                var amountwidth = Convert.ToDouble(this.dg1.Columns[5].ActualWidth) + Convert.ToDouble(54);
                //var overallwidth = extrawidth + lastwidth;
                this.dg1.Columns[6].Visibility = System.Windows.Visibility.Hidden;
                this.dg1.Columns[7].Visibility = System.Windows.Visibility.Hidden;
                //this.dg1.Columns[3].Width = new DataGridLength(extrawidth, DataGridLengthUnitType.Pixel, extrawidth, extrawidth);
                this.dg1.Columns[3].Width = new DataGridLength(qtywidth, DataGridLengthUnitType.Pixel, qtywidth, qtywidth);
                this.dg1.Columns[4].Width = new DataGridLength(pricewidth, DataGridLengthUnitType.Pixel, pricewidth, pricewidth);
                this.dg1.Columns[5].Width = new DataGridLength(amountwidth, DataGridLengthUnitType.Pixel, amountwidth, amountwidth);
                this.qtybackground.Width = qtywidth;
                this.amtbackground.Width = amountwidth;
                this.pricebackground.Width = pricewidth;
                this.invoicenobackground.Width = 0;
                this.datebackground.Width = 0;
            }
            else
            {
                this.dg1.Columns[6].Visibility = System.Windows.Visibility.Visible;
                this.dg1.Columns[7].Visibility = System.Windows.Visibility.Visible;

            }
        }
        private void setInvoiceColumntrue(bool? isHideInvoiceColumn)
        {
            if (isHideInvoiceColumn == true)
            {
                var extrawidth = Convert.ToDouble(this.dg1.Columns[6].ActualWidth) + Convert.ToDouble(this.dg1.Columns[7].ActualWidth);
                var qtywidth = Convert.ToDouble(this.dg1.Columns[3].ActualWidth) - Convert.ToDouble(54);
                var pricewidth = Convert.ToDouble(this.dg1.Columns[4].ActualWidth) - Convert.ToDouble(54);
                var amountwidth = Convert.ToDouble(this.dg1.Columns[5].ActualWidth) - Convert.ToDouble(54);
                //var overallwidth = extrawidth + lastwidth;
                this.dg1.Columns[6].Visibility = System.Windows.Visibility.Visible;
                this.dg1.Columns[7].Visibility = System.Windows.Visibility.Visible;
                //this.dg1.Columns[3].Width = new DataGridLength(extrawidth, DataGridLengthUnitType.Pixel, extrawidth, extrawidth);
                this.dg1.Columns[3].Width = new DataGridLength(qtywidth, DataGridLengthUnitType.Pixel, qtywidth, qtywidth);
                this.dg1.Columns[4].Width = new DataGridLength(pricewidth, DataGridLengthUnitType.Pixel, pricewidth, pricewidth);
                this.dg1.Columns[5].Width = new DataGridLength(amountwidth, DataGridLengthUnitType.Pixel, amountwidth, amountwidth);
                this.qtybackground.Width = qtywidth;
                this.amtbackground.Width = amountwidth;
                this.pricebackground.Width = pricewidth;
                this.invoicenobackground.Width = this.dg1.Columns[6].ActualWidth;
                this.datebackground.Width = this.dg1.Columns[7].ActualWidth;
            }
            else
            {
                this.dg1.Columns[6].Visibility = System.Windows.Visibility.Visible;
                this.dg1.Columns[7].Visibility = System.Windows.Visibility.Visible;

            }
        }

        private void radSummaryYes_Checked(object sender, RoutedEventArgs e)
        {
            setInvoiceColumnFalse(true);
        }

        private void radDetailsyes_Checked(object sender, RoutedEventArgs e)
        {
            setInvoiceColumntrue(true);
        }
        private void cmbConvertedtoSearch_Loaded(object sender, RoutedEventArgs e)
        {
            // cmbConvertedtoSearch.SelectedIndex = 0;
        }

        #endregion
    }
}
