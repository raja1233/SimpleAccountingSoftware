﻿#pragma checksum "..\..\..\..\File\Views\ExportDataView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C812F8F5921A4D049AF0EC866010F507"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SASClient.File.Views;
using SDN.Common;
using SDN.Common.Converter;
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


namespace SASClient.File.Views {
    
    
    /// <summary>
    /// ExportDataView
    /// </summary>
    public partial class ExportDataView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 39 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbxAll2;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbxAll3;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid1;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn TransactionPages;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid fromdategrid;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn FromDate;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid todategrid;
        
        #line default
        #line hidden
        
        
        #line 263 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ToDate;
        
        #line default
        #line hidden
        
        
        #line 332 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid2;
        
        #line default
        #line hidden
        
        
        #line 337 "..\..\..\..\File\Views\ExportDataView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn TransactionPages1;
        
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
            System.Uri resourceLocater = new System.Uri("/SASClient;component/file/views/exportdataview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\File\Views\ExportDataView.xaml"
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
            case 1:
            this.cbxAll2 = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 2:
            
            #line 50 "..\..\..\..\File\Views\ExportDataView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyDown);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\..\File\Views\ExportDataView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 77 "..\..\..\..\File\Views\ExportDataView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyDown);
            
            #line default
            #line hidden
            
            #line 77 "..\..\..\..\File\Views\ExportDataView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbxAll3 = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.datagrid1 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.TransactionPages = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 7:
            this.fromdategrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.FromDate = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 10:
            this.todategrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.ToDate = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 13:
            this.datagrid2 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            this.TransactionPages1 = ((System.Windows.Controls.DataGridTemplateColumn)(target));
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
            case 9:
            
            #line 213 "..\..\..\..\File\Views\ExportDataView.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 288 "..\..\..\..\File\Views\ExportDataView.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

