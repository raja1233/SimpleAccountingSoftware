﻿using SASClient.File.ViewModel;
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

namespace SASClient.File.Views
{
    
    /// <summary>
    /// Interaction logic for RestoreData.xaml
    /// </summary>
    public partial class RestoreDataView : UserControl
    {
        private RestoreDataViewModel _viewmodel;
        public RestoreDataView(RestoreDataViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            this._viewmodel = model;
        }
    }
}