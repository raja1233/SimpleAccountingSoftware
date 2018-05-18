using SDN.Common;
using SDN.Sales.ViewModel;
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

namespace SDN.Sales.Views
{
    /// <summary>
    /// Interaction logic for CreditNoteView.xaml
    /// </summary>
    public partial class CreditNoteView : UserControl
    {
        #region Fields

        public CreditNoteViewModel debitViewModel;
        private bool _tabInvoked;

        #endregion
        public CreditNoteView(CreditNoteViewModel model)
        {

            InitializeComponent();
            this.debitViewModel = model;
         
            this.DataContext = this.debitViewModel;
            if (debitViewModel.PQDetailsEntity != null)
            {
                this.grdPandS.ItemsSource = this.debitViewModel.PQDetailsEntity;
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

    }
}
