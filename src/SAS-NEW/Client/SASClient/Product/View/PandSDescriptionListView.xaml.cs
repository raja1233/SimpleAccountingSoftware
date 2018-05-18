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
    /// Interaction logic for PandSDescriptionListView.xaml
    /// </summary>
    public partial class PandSDescriptionListView : UserControl
    {
        public PandSDescriptionListView(PandSDescriptionListViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(3, 50).AsEnumerable();
        }
    }
}
