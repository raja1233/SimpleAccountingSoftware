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

namespace SDN.Settings.Views
{
    using SDN.Settings.ViewModels;
    using System.Data;
    using SDN.UI.Entities;
    using Common;

    /// <summary>
    /// Interaction logic for TaxCodesAndRatesView.xaml
    /// </summary>
    public partial class TaxCodesAndRatesView : UserControl
    {
        #region "Constructors"
        public TaxCodesAndRatesView()
        {
            InitializeComponent();
            this.DataContext = new TaxCodesAndRatesViewModel();
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(6, 50).AsEnumerable();
        }
        #endregion

        #region Events
        private void dgTaxCodesAndRates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Right)
            {

                GetFocusOnControl();
            }
        }
        
        private void dgTaxCodesAndRates_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Right)
            {

                GetFocusOnControl();
            }
        }

        private void txtTaxDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Left)
            {
                GetFocusOnDataGrid();
            }
        }

        private void txtTaxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Left)
            {
                GetFocusOnDataGrid();
            }
        }

        private void txtTaxRate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Right)
            {
                GetFocusOnSaveButton();
            }
        }

        private void txtTaxRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Right)
            {
                GetFocusOnSaveButton();
            }
        }


        private void btnNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab)
            {
                GetFocusOnControl();
            }
        }

        private void btnNew_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab)
            {
                GetFocusOnControl();
            }
        }

        private void dgTaxCodesAndRates_Loaded(object sender, RoutedEventArgs e)
        {
           // dgTaxCodesAndRates.SelectedIndex = 1;
            //GetFocusOnControl();
        }

        private void DecimalTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }


        private void btnNew_MouseLeave(object sender, MouseEventArgs e)
        {
            GetFocusOnControl();
        }

        //private void dgTaxCodesAndRates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //    var tax = dgTaxCodesAndRates.SelectedItem as TaxModel;
        //    if (tax != null)
        //    {
        //        cmbTaxName.SelectedValue = tax.TaxName;
        //    }

        //    DataGrid dataGrid = sender as DataGrid;

        //    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
        //    if (row != null)
        //    {
        //        DataGridCell RowColumn = dataGrid.Columns[1].GetCellContent(row).Parent as DataGridCell;
        //        string CellValue = ((TextBlock)RowColumn.Content).Text;

        //        DataGridCell RowColumnRate = dataGrid.Columns[3].GetCellContent(row).Parent as DataGridCell;
        //        string rateValue = ((TextBlock)RowColumnRate.Content).Text;

        //        if (CellValue == "GST Free" && rateValue == "0")
        //        {
        //            for (int i = 0; i < TaxItemControl.Items.Count; i++)
        //            {

        //                ContentPresenter c = (ContentPresenter)TaxItemControl.ItemContainerGenerator.ContainerFromItem(TaxItemControl.Items[i]);
        //                //     TextBox tb = c.Content.Template.FindName("txtTaxDescription", c) as TextBox;
        //                //    //TextBox tb = FindElementByName<TextBox>(c, "txtTaxDescription");
        //                //    tb.IsEnabled = false;
        //                //}
        //                // ContentPresenter cp = (ContentPresenter)(this.Template.FindName("customCP", this));
        //                c.ApplyTemplate();
        //                DataTemplate dt = FindResource("dttax") as DataTemplate;
        //                TextBox tb = (TextBox)dt.FindName("txtTaxDescription", c);
        //                tb.IsReadOnly = true;
        //                TextBox tbRate = (TextBox)dt.FindName("txtTaxRate", c);
        //                tbRate.IsReadOnly = true;
        //                CheckBox chk = (CheckBox)dt.FindName("chkInactive", c);
        //                chk.IsEnabled = false;

        //            }
        //        }
        //    }

        //    if (dataGrid.SelectedIndex == 0)
        //    {

        //        for (int i = 0; i < TaxItemControl.Items.Count; i++)
        //        {

        //            ContentPresenter c = (ContentPresenter)TaxItemControl.ItemContainerGenerator.ContainerFromItem(TaxItemControl.Items[i]);
        //            //     TextBox tb = c.Content.Template.FindName("txtTaxDescription", c) as TextBox;
        //            //    //TextBox tb = FindElementByName<TextBox>(c, "txtTaxDescription");
        //            //    tb.IsEnabled = false;
        //            //}
        //            // ContentPresenter cp = (ContentPresenter)(this.Template.FindName("customCP", this));
        //            c.ApplyTemplate();
        //            DataTemplate dt = FindResource("dttax") as DataTemplate;
        //            TextBox tb = (TextBox)dt.FindName("txtTaxDescription", c);
        //            if (tb.Text.Trim() == "GST Free")
        //            {
        //                tb.IsReadOnly = true;
        //            }
        //            TextBox tbRate = (TextBox)dt.FindName("txtTaxRate", c);
        //            if (tb.Text.Trim() == "0")
        //            {
        //                tbRate.IsReadOnly = true;
        //            }
        //            CheckBox chk = (CheckBox)dt.FindName("chkInactive", c);
        //            chk.IsEnabled = false;

        //        }

        //    }
        //}


        #endregion

        #region "Private Methods"
        void GetFocusOnControl()
        {
            for (int i = 0; i < TaxItemControl.Items.Count; i++)
            {

                ContentPresenter c = (ContentPresenter)TaxItemControl.ItemContainerGenerator.ContainerFromItem(TaxItemControl.Items[i]);
                TextBox tb = c.ContentTemplate.FindName("txtTaxDescription", c) as TextBox;
                tb.Focus();

            }
        }

        void GetFocusOnSaveButton()
        {
            btnSave.Focus();
        }

        void GetFocusOnDataGrid()
        {
            if ((dgTaxCodesAndRates.Items.Count > 0) &&
              (dgTaxCodesAndRates.Columns.Count > 0))
            {

                dgTaxCodesAndRates.SelectedIndex = 0;
                DataGridRow row = (DataGridRow)dgTaxCodesAndRates.ItemContainerGenerator.ContainerFromIndex(0);
                row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

            }
        }

        /// <summary>
        /// Find Child Control from ContentPresenter
        /// </summary>
        /// <typeparam name="ChildControl"></typeparam>
        /// <param name="DependencyObj"></param>
        /// <returns></returns>
        private ChildControl FindVisualChild<ChildControl>(DependencyObject DependencyObj)
        where ChildControl : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(DependencyObj); i++)
            {
                DependencyObject Child = VisualTreeHelper.GetChild(DependencyObj, i);

                if (Child != null && Child is ChildControl)
                {
                    return (ChildControl)Child;
                }
                else
                {
                    ChildControl ChildOfChild = FindVisualChild<ChildControl>(Child);

                    if (ChildOfChild != null)
                    {
                        return ChildOfChild;
                    }
                }
            }
            return null;
        }

        public T FindElementByName<T>(FrameworkElement element, string sChildName) where T : FrameworkElement
        {
            T childElement = null;
            var nChildCount = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < nChildCount; i++)
            {
                FrameworkElement child = VisualTreeHelper.GetChild(element, i) as FrameworkElement;

                if (child == null)
                    continue;

                if (child is T && child.Name.Equals(sChildName))
                {
                    childElement = (T)child;
                    break;
                }

                childElement = FindElementByName<T>(child, sChildName);

                if (childElement != null)
                    break;
            }

            return childElement;
        }




        #endregion

        
    }

}
