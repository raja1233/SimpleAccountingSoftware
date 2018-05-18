using SDN.Settings.ViewModels;
using SDN.UI.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media;
namespace SDN.Settings.Views
{
    /// <summary>
    /// Interaction logic for OptionsView.xaml
    /// </summary>
    public partial class OptionsView : UserControl
    {
        public OptionsVewModel _objViewModel;
        public OptionsView(OptionsVewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _objViewModel = model;
            //SourceContext();
        }
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _objViewModel = new CompanyViewModel();

        //    SourceContext();
        //    //InitialOperations();
        //}

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



        private void cmbAccDet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var cmbbox in FindVisualChildren<ComboBox>(this))
            {
                if (cmbbox.Name == "cmbAccDet")
                {
                    //var selected = (cmbbox.SelectedItem as ShippingAddressEntity).ShippingID;
                    if (cmbbox.SelectedItem as AccountsEntity != null)
                    {
                        _objViewModel.SetAccountDetails((cmbbox.SelectedItem as AccountsEntity).AccountName);
                        cmbbox.SelectedItem = _objViewModel.setDefaultValue();
                    }
                }
            }
        }

        //private void SourceContext()
        //{
        //    this.DataContext = _objViewModel;
        //}

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        //private void OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var tb = (ComboBox)sender;
        //    using (tb.())
        //    {
        //        foreach (var c in e.Changes)
        //        {
        //            if (c.AddedLength == 0) continue;
        //            tb.Select(c.Offset, c.AddedLength);
        //            if (tb.SelectedText.Contains('.'))
        //            {
        //                tb.SelectedText = tb.SelectedText.Replace('.', '/');

        //            }
        //            if (tb.SelectedText.Contains('-'))
        //            {
        //                tb.SelectedText = tb.SelectedText.Replace('-', '/');
        //            }
        //            tb.Select(c.Offset + c.AddedLength, 0);
        //        }
        //    }
        //}
    }   
}
