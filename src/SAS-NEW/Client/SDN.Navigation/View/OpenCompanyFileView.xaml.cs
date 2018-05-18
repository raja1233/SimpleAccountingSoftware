using SDN.Navigation.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
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


namespace SDN.Navigation.View
{
    /// <summary>
    /// Interaction logic for OpenCompanyFileView.xaml
    /// </summary>
    public partial class OpenCompanyFileView : UserControl

    {
        public OpenCompanyFileViewModel _ViewModel;
        
        public OpenCompanyFileView(OpenCompanyFileViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            _ViewModel = model;
           
        }
        private void CloseApplication_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure to exit?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void RadioButton1_Loaded(object sender, RoutedEventArgs e)
        {
            RadioButton1.IsChecked = false;
        }
        private void RadioButton2_Loaded(object sender, RoutedEventArgs e)
        {
            RadioButton2.IsChecked = false;
        }
        private void RadioButton3_Loaded(object sender, RoutedEventArgs e)
        {
            RadioButton3.IsChecked = false;
        }

    }
}
