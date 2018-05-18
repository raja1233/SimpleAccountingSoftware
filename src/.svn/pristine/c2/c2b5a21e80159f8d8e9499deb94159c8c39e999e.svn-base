using System.Windows;
using Microsoft.Practices.Prism.Regions;
using MahApps.Metro.Controls;
using System;
using System.Configuration;
 
namespace SDN.SimpleAccounting
{
    /// <summary>
    /// Interaction logic for SimpleAccounting.xaml
    /// </summary>
    public partial class SimpleAccounting : MetroWindow
    {
        public SimpleAccounting(SimpleAccountingViewModel model)
        {
            InitializeComponent();
            DataContext = model;

            // this.Closing += OnMainWindowClose;           
        }
       
        private void OnMainWindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
           var result= MessageBox.Show("Are you sure to exit?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question,MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
        
        private void CloseApplication_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure to exit?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void MinimizeApplication_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            bool isMinimized = true;

            //this.ShowInTaskbar = !isMinimized;
            //systemTrayIcon.Visible = isMinimized;
            //if (isMinimized)
            //{
            //    systemTrayIcon.ShowBalloonTip(500, "SAS", "Application minimized to tray.", ToolTipIcon.Info);
            //}
        }
    }
}
