using SDN.Settings.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace SDN.Settings.Views
{

    /// <summary>
    /// Interaction logic for CompanyDetails.xaml
    /// </summary>
    public partial class CompanyDetailsView : UserControl
    {
        private bool _tabInvoked;
        public CompanyViewModel _objViewModel;
      
        public CompanyDetailsView(CompanyViewModel objViewModel)
        {
            InitializeComponent();
            this.DataContext = objViewModel;
            //this.DataContext = new CompanyViewModel();
            _objViewModel = objViewModel;
          

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_objViewModel = new CompanyViewModel();

            //SourceContext();
            //InitialOperations();
            
        }

        //private void Control_SourceUpdated(object sender, DataTransferEventArgs e)
        //{
        //    _objViewModel.Flag = true;
        //}
        //private void DatePicker_PreviewKeyUp(object sender, KeyEventArgs e)
        //{
        //    var _tab = true;
        //    if (e.Key == Key.Enter)
        //    {
        //        var dp = sender as DatePicker;
        //        dp.IsDropDownOpen
        //        if (dp == null || e.Key != Key.Tab)
        //            return;
        //        // Check if tab is pressed or not
        //        _tab = true;   // it is the var declared above and set to true if pressed
        //                       // Open the calender of Datepicker
        //        if (e.Key == Key.Tab)
        //        {
        //            dp.IsDropDownOpen = true;
        //        }
        //    }
        //}
        //public void cmbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    foreach (var cmbbox in FindVisualChildren<ComboBox>(this))
        //    {
        //        if (cmbbox.Name == "cmbCountry")
        //        {
        //            _objViewModel.LoadState((cmbbox.SelectedItem as CountryDropDown).CountryCode);
        //        }
        //    }
        //    //Load state when country combo is changed


        //}
        //private void OnKeyDownHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName ==)
        //    {
        //        _objViewModel.Flag = true;
        //    }
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

        private void cmbShipAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (var cmbbox in FindVisualChildren<ComboBox>(this))
            //{
            //    if (cmbbox.Name == "cmbShipAdd")
            //    {
            //        //var selected = (cmbbox.SelectedItem as ShippingAddressEntity).ShippingID;
            //        if(cmbbox.SelectedItem as ShippingAddressEntity!=null)
            //        {
            //            _objViewModel.LoadShippingAddress((cmbbox.SelectedItem as ShippingAddressEntity).ShippingID);
            //        }

            //        else
            //        {
            //            _objViewModel.NewShipping(null);
            //        }
            //    }
            //}
        }



        private void SourceContext()
        {
            //this.DataContext = _objViewModel;
        }
        ////private void InitialOpera tions()
        ////{
        ////    PopulateCountryCombo();

        ////}
        //private void InitialOperations()
        //{

        //    PopulateCountryCombo();
        //}
        //private void PopulateCountryCombo()
        //{

        //    _objViewModel.LoadProductsBackground();
        //}

        /// <summary>
        /// Browse image function
        /// </summary>
        /// <param name="sender"></param>
        ///// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // open file dialog
                System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
                // image filters
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                foreach (var img in FindVisualChildren<Image>(this))
                {
                    if (img.Name == "imgLogo")
                    {
                        if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            
                            FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                           
                            byte[] photo_aray = new byte[fs.Length];

                            fs.Read(photo_aray, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                           
                            if (photo_aray != null)
                            {
                                _objViewModel.addCompanyImage(photo_aray);
                            }
                            
                        }

                    }
                }
                // display image in picture box


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Image loading error....");
            }
        }
        public byte[] ConvertBitMapToByteArray(System.Drawing.Bitmap bitmap)
        {
            byte[] result = null;
            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, bitmap.RawFormat);
                result = stream.ToArray();
            }
            return result;
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //DateTime fromdate = Convert.ToDateTime(ManufacturingDatePicker.Text);
           
            //    if (ManufacturingDatePicker.SelectedDate.HasValue &&
            //        ExpiryDatePicker.SelectedDate.HasValue &&
            //        ExpiryDatePicker.SelectedDate <= ManufacturingDatePicker.SelectedDate)
            //    {
            //        ExpiryDatePicker.SelectedDate = ManufacturingDatePicker.SelectedDate.Value.AddDays(1);
            //    }
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
            if (e.Key == Key.Enter && dp!=null)
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
            //_tabInvoked = false;
            //var dp = sender as DatePicker;
            //if (e.Key == Key.Enter)
            //{
            //    if (dp == null) return;
            //    var datePicker = sender as DatePicker;
            //    if (datePicker == null || e.Key == Key.Tab) return;

            //    // Mark that "tab" was pressed
            //    _tabInvoked = true;

            //    // Reverse drop down opened state
            //    datePicker.IsDropDownOpen = !datePicker.IsDropDownOpen;
            //    return;
            //}
            //if (!dp.SelectedDate.HasValue) return;

            //var date = dp.SelectedDate.Value;
            //if (e.Key == Key.Up)
            //{
            //    e.Handled = true;
            //    dp.SetValue(DatePicker.SelectedDateProperty, date.AddDays(1));
            //}
            //else if (e.Key == Key.Down)
            //{
            //    e.Handled = true;
            //    dp.SetValue(DatePicker.SelectedDateProperty, date.AddDays(-1));
            //}
        }
        #endregion

        #region DatePicker WaterMark
        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            //DatePicker datePicker = sender as DatePicker;
            //if (datePicker != null)
            //{
            //    System.Windows.Controls.Primitives.DatePickerTextBox datePickerTextBox = FindVisualChild<System.Windows.Controls.Primitives.DatePickerTextBox>(datePicker);
            //    if (datePickerTextBox != null)
            //    {

            //        //ContentControl watermark = datePickerTextBox.Template.FindName("PART_Watermark", datePickerTextBox) as ContentControl;
            //        //ContentControl watermark1 = datePickerTextBox.Template.FindName("PART_Watermark", ;
            //        //if (watermark != null)
            //        //{
            //        //    watermark.Content = string.Empty;
            //        //    //or set it some value here...
            //        //}
            //        datePickerTextBox.Text = "sTRING";
            //    }
            //}

            var dp = sender as DatePicker;
            if (dp == null) return;

            //var tb = FindVisualChild<TextBox>(dp);
            //if (tb == null) return;

            var wm = (TextBox)dp.Template.FindName("PART_TextBox", dp) as TextBox;
            if (wm == null) return;

            wm.Text = "Your watermark here!";
        }

        private T FindVisualChild<T>(DependencyObject depencencyObject) where T : DependencyObject
        {
            if (depencencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depencencyObject); ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depencencyObject, i);
                    T result = (child as T) ?? FindVisualChild<T>(child);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }
        #endregion

    }
}
