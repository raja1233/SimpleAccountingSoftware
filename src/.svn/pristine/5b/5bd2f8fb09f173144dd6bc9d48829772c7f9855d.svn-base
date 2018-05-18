
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

namespace SASClient.Product.View
{
    using SASClient.Product.ViewModel;
    using SDN.Common;
    using System.Data;

    /// <summary>
    /// Interaction logic for PandSHistoryView.xaml
    /// </summary>
    public partial class PandSHistoryView : UserControl
    {
        public PandSHistoryView(PandSHistoryViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(7, 50).AsEnumerable();
        }
    }
}
