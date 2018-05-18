using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SDN.Navigation.ViewModel;

namespace SDN.Navigation.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainViewModel _ViewModel;
        public MainView(MainViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            db.MaxDropDownHeight = 700;
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            _ViewModel.reportlist();
        }
        private void HelpButton(object sender, RoutedEventArgs e)
        {
            if (btn.IsEnabled) {
                btn.Background = Brushes.White;
            }
            MessageBox.Show("Hi There");
        }
    }
}
