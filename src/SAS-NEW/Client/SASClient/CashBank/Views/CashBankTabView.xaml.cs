using SDN.CashBank.ViewModels;
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

namespace SDN.CashBank.Views
{
    /// <summary>
    /// Interaction logic for CashBankTabView.xaml
    /// </summary>
    public partial class CashBankTabView : UserControl
    {
        public CashBankTabView(CashAndBankTabViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
        }
    }
}
