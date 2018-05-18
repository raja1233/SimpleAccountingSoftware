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
using SDN.Settings.ViewModel;
namespace SDN.Settings.Views
{
    /// <summary>
    /// Interaction logic for SettingsTabView.xaml
    /// </summary>
    public partial class SettingsTabView : UserControl
    {
        public SettingsTabView(SettingsTabViewModel model)
        {
            InitializeComponent();

            //SolidColorBrush black = new SolidColorBrush(Colors.Black);
            //SolidColorBrush white = new SolidColorBrush(Colors.White);
            //btnCompanyDetails.Background = black;
            //btnCompanyDetails.Foreground = white;
            DataContext = model;
            //SolidColorBrush btnBackColor = new SolidColorBrush(Colors.Black);
            //SolidColorBrush btnForColor = new SolidColorBrush(Colors.Black);
            //btnCompanydetails.Background = btnBackColor;
            //btnCompanydetails.Foreground = btnForColor;
        }

        private void RadioButton_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
