
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

namespace SDN.Product.View
{
    using Common;
    using SDN.Product.ViewModel;
    using System.Data;

    /// <summary>
    /// Interaction logic for TopPandSView.xaml
    /// </summary>
    public partial class TopPandSView : UserControl
    {
        private TopPandSViewModel _ViewModel;
        private bool _tabInvoked;
        public TopPandSView(TopPandSViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(4, 50).AsEnumerable();
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

     
        #endregion
    }
}
