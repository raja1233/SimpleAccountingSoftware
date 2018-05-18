﻿using System;
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
using SDN.Manufacturing.ViewModel;

namespace SDN.Manufacturing.View
{
    /// <summary>
    /// Interaction logic for ProductInventoryView.xaml
    /// </summary>
    public partial class ProductInventoryView : UserControl
    {
        public ProductInventoryView(ProductInventoryViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
