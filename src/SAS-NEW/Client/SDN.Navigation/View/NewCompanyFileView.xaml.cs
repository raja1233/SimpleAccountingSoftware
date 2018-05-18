using SDN.Navigation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EnterDatabaseNameView.xaml
    /// </summary>
    public partial class NewCompanyFileView : UserControl
    {
        public NewCompanyFileViewModel _ViewModel;
        public NewCompanyFileView(NewCompanyFileViewModel model)
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
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                _ViewModel.NewDatabase();

            }
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //string playerName;
            string userInput = _ViewModel.DatabaseName;

            Regex r = new Regex("^[a-zA-Z]*$");
            if (r.IsMatch(userInput))
            {
                //MessageBox.Show("onlyletter");
            }
            else
            {
                MessageBox.Show("Only letters permitted. Try again!");
            }
        }
    }
}
