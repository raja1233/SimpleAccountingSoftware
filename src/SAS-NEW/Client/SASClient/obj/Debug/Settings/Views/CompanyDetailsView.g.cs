﻿#pragma checksum "..\..\..\..\Settings\Views\CompanyDetailsView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7BADA0B7A760E351CFD74C83941436C3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// CompanyDetailsView
    /// </summary>
    public partial class CompanyDetailsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
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
            System.Uri resourceLocater = new System.Uri("/SASClient;component/settings/views/companydetailsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
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
            
            #line 11 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((SDN.Settings.Views.CompanyDetailsView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
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
            case 2:
            
            #line 104 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyDown);
            
            #line default
            #line hidden
            
            #line 104 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyUp);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 155 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyDown);
            
            #line default
            #line hidden
            
            #line 155 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyUp);
            
            #line default
            #line hidden
            
            #line 156 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DatePicker_Loaded);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 184 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 186 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 249 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyDown);
            
            #line default
            #line hidden
            
            #line 249 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyUp);
            
            #line default
            #line hidden
            
            #line 250 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DatePicker_Loaded);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 276 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyDown);
            
            #line default
            #line hidden
            
            #line 276 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.DatePicker)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OpenDatePicker_KeyUp);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 314 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 323 "..\..\..\..\Settings\Views\CompanyDetailsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
