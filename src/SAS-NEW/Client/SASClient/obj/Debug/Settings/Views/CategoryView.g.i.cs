﻿#pragma checksum "..\..\..\..\Settings\Views\CategoryView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F511E353594E11F6EB6D60910204323A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SDN.Common;
using SDN.Common.Converter;
using SDN.Settings.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SDN.Settings.Views {
    
    
    /// <summary>
    /// CategoryView
    /// </summary>
    public partial class CategoryView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 97 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomGridLines;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg1;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomGridLinesCatContent;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdCategoryContent;
        
        #line default
        #line hidden
        
        
        #line 279 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ContentsItemControl;
        
        #line default
        #line hidden
        
        
        #line 294 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg2;
        
        #line default
        #line hidden
        
        
        #line 374 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 377 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNew;
        
        #line default
        #line hidden
        
        
        #line 380 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave1;
        
        #line default
        #line hidden
        
        
        #line 388 "..\..\..\..\Settings\Views\CategoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOk;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SASClient;component/settings/views/categoryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Settings\Views\CategoryView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            this.CustomGridLines = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.dg1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 115 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.dg1.KeyUp += new System.Windows.Input.KeyEventHandler(this.dg1_KeyUp);
            
            #line default
            #line hidden
            
            #line 115 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.dg1.KeyDown += new System.Windows.Input.KeyEventHandler(this.dg1_KeyDown);
            
            #line default
            #line hidden
            
            #line 115 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.dg1.Loaded += new System.Windows.RoutedEventHandler(this.dg1_Loaded);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CustomGridLinesCatContent = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.grdCategoryContent = ((System.Windows.Controls.DataGrid)(target));
            
            #line 200 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.grdCategoryContent.KeyUp += new System.Windows.Input.KeyEventHandler(this.grdCategoryContent_KeyUp);
            
            #line default
            #line hidden
            
            #line 200 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.grdCategoryContent.KeyDown += new System.Windows.Input.KeyEventHandler(this.grdCategoryContent_KeyDown);
            
            #line default
            #line hidden
            
            #line 200 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.grdCategoryContent.Loaded += new System.Windows.RoutedEventHandler(this.grdCategoryContent_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ContentsItemControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 7:
            this.dg2 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 298 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.dg2.KeyUp += new System.Windows.Input.KeyEventHandler(this.dg1_KeyUp);
            
            #line default
            #line hidden
            
            #line 298 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.dg2.KeyDown += new System.Windows.Input.KeyEventHandler(this.dg1_KeyDown);
            
            #line default
            #line hidden
            
            #line 298 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.dg2.Loaded += new System.Windows.RoutedEventHandler(this.dg1_Loaded);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnNew = ((System.Windows.Controls.Button)(target));
            
            #line 378 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.btnNew.KeyDown += new System.Windows.Input.KeyEventHandler(this.btnNew_KeyDown);
            
            #line default
            #line hidden
            
            #line 378 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.btnNew.KeyUp += new System.Windows.Input.KeyEventHandler(this.btnNew_KeyUp);
            
            #line default
            #line hidden
            
            #line 378 "..\..\..\..\Settings\Views\CategoryView.xaml"
            this.btnNew.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnNew_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSave1 = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.btnOk = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 55 "..\..\..\..\Settings\Views\CategoryView.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.txtContentName_KeyDown);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\..\Settings\Views\CategoryView.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.txtContentName_KeyUp);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

