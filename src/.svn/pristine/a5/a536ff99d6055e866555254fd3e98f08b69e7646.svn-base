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
    /// Interaction logic for GstVatCollectedView.xaml
    /// </summary>
    public partial class GstVatCollectedView : UserControl
    {
        private GstVatCollectedViewModel _viewModel;
        public GstVatCollectedView(GstVatCollectedViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            this._viewModel = model;
            CustomGridLines1.ItemsSource = DataGridTableCollection.GridLines(8, 50).AsEnumerable();
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
    }
}
