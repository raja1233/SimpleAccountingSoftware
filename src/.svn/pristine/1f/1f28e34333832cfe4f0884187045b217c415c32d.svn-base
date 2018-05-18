using SASClient.Accounts.ViewModel;
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

namespace SASClient.Accounts.Views
{
    /// <summary>
    /// Interaction logic for ProfitAndLossStatementView.xaml
    /// </summary>
    public partial class ProfitAndLossStatementView : UserControl
    {
        private ProfitAndLossStatementViewModel _ViewModel;
        public ProfitAndLossStatementView(ProfitAndLossStatementViewModel model)
        {
            this.DataContext = model;
            _ViewModel = model;
            InitializeComponent();
            ProfitLossStatementGridLines.ItemsSource = DataGridTableCollection.GridLines(2, 50).AsEnumerable();
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
       
        #endregion
    }
}
