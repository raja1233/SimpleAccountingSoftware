using SASClient.CloseRequest;
using SDN.Common;
using SDN.Navigation.ViewModel;
using SDN.Settings.Views;
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
using System.Windows.Shapes;

namespace SDN.Navigation.View
{
    /// <summary>
    /// Interaction logic for LoginUserView.xaml
    /// </summary>
    public partial class LoginUserView : UserControl
    {
  
        public LoginUserViewModel _viewModel;
        public LoginUserView(LoginUserViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            _viewModel = model;
            
        }
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoginUser();
       
        }
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Put your rules here - Example rejects the period key
            if (e.Key == Key.OemPeriod)
                e.Handled = true;
        }
        private void WindowCommands_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _viewModel.Password = PasswordBox.Password;
            _viewModel.LoginUser();
            var connectionString = ConfigurationManager.ConnectionStrings["SASEntitiesEDM"].ConnectionString;
            List<string> listview = (List<string>)Application.Current.Resources["views"];
            if (listview != null)
            {
                //listview = new List<string>();
                Application.Current.Resources.Remove("views");
                //listview = (List<string>)Application.Current.Resources["views"];
                StackList.list = new List<string>();
                //list = 
            }

        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _viewModel.Password = PasswordBox.Password;
                _viewModel.LoginUser();
                var connectionString = ConfigurationManager.ConnectionStrings["SASEntitiesEDM"].ConnectionString;
                List<string> listview = (List<string>)Application.Current.Resources["views"];
                if (listview != null)
                {
                    //listview = new List<string>();
                    Application.Current.Resources.Remove("views");
                    //listview = (List<string>)Application.Current.Resources["views"];
                    StackList.list = new List<string>();
                    //list = 
                }
            }
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

    }
}
