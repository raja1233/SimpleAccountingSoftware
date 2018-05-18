﻿using System;
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
using SASClient.File.ViewModel;

namespace SASClient.File.Views
{
    /// <summary>
    /// Interaction logic for ImportDataView.xaml
    /// </summary>
    public partial class ImportDataView : UserControl
    {
        private  ImportDataViewModel _viewModel;
        public ImportDataView(ImportDataViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _viewModel = model;
        }
    }
}