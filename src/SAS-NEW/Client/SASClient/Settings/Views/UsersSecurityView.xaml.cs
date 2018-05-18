using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using SDN.Common;
using SDN.Settings.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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

namespace SDN.Settings.Views
{

    public partial class UsersSecurityView : UserControl
    {
        private UsersSecurityViewModel usersec;
        public UsersSecurityView(UsersSecurityViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            usersec = model;
            CustomGridLines.ItemsSource = DataGridTableCollection.GridLines(4, 50).AsEnumerable();
            CustomGridLinesRole.ItemsSource= DataGridTableCollection.GridLines(4, 50).AsEnumerable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        void OnChecked(object sender, RoutedEventArgs e)
        {
            //usersec = new UsersSecurityViewModel();
            //if (sender.GetType() == DataGridCell)
            //{
            DataGridCell checkevent = sender as DataGridCell;
            var moduledata = checkevent.BindingGroup.Items[0];

            usersec.CheckModuledemo(moduledata);

                //var demo = abc.
                //var item = (sender as DataGridCheckBoxColumn).DisplayIndex;
                //throw new NotImplementedException();
           // }
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                //MessageBox.Show("No space allowed.");
                e.Handled = true;
            }
            //string[] array = textbox1.Text.Split(new char[] { '.' });
            //if (array.Length == 2)
            //{
            //    if (array[1].Length == 2)
            //    {
            //        MessageBox.Show("No more than two decimal places.");
            //        e.Handled = true;
            //    }
            //}
        }
    }
}
