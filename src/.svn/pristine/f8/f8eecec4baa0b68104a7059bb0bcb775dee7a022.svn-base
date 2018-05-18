
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

namespace SASClient.CashBank.Views
{
    using SASClient.CashBank.ViewModels;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Interaction logic for ReceiveMoneyView.xaml
    /// </summary>
    public partial class ReceiveMoneyView : UserControl
    {
        ReceiveMoneyViewModel _viewModel;

        private bool _tabInvoked;
        public ReceiveMoneyView(ReceiveMoneyViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _viewModel = model;
            if(_viewModel.MustCompare == true)
            {
                ReceiveDatepicker.IsEnabled = true;
                PART_TextBox.IsReadOnly = false;
            }
            else
            {
                btnNew.IsEnabled = false;
                ReceiveDatepicker.IsEnabled = false;
                PART_TextBox.IsReadOnly = true;
            }
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
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

        #endregion

        
    }
}
