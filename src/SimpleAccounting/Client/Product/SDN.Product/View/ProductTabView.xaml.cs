using SDN.Product.ViewModel;
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
    /// <summary>
    /// Interaction logic for ProductTabView.xaml
    /// </summary>
    public partial class ProductTabView : UserControl
    {
        public ProductTabView(ProductTabViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
        }
    }
}
