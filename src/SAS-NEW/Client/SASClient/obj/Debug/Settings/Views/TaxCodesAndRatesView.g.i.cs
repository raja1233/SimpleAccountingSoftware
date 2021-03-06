﻿#pragma checksum "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "026788C4B1CEBC693B72567A365B947E"
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
    /// TaxCodesAndRatesView
    /// </summary>
    public partial class TaxCodesAndRatesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 114 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTaxName;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomGridLines;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTaxCodesAndRates;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn TaxDesc;
        
        #line default
        #line hidden
        
        
        #line 279 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl TaxItemControl;
        
        #line default
        #line hidden
        
        
        #line 296 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNew;
        
        #line default
        #line hidden
        
        
        #line 298 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave1;
        
        #line default
        #line hidden
        
        
        #line 316 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 317 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/SASClient;component/settings/views/taxcodesandratesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
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
            case 3:
            this.cmbTaxName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.CustomGridLines = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.dgTaxCodesAndRates = ((System.Windows.Controls.DataGrid)(target));
            
            #line 161 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            this.dgTaxCodesAndRates.KeyDown += new System.Windows.Input.KeyEventHandler(this.dgTaxCodesAndRates_KeyDown);
            
            #line default
            #line hidden
            
            #line 162 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            this.dgTaxCodesAndRates.KeyUp += new System.Windows.Input.KeyEventHandler(this.dgTaxCodesAndRates_KeyUp);
            
            #line default
            #line hidden
            
            #line 162 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            this.dgTaxCodesAndRates.Loaded += new System.Windows.RoutedEventHandler(this.dgTaxCodesAndRates_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TaxDesc = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.TaxItemControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 8:
            this.btnNew = ((System.Windows.Controls.Button)(target));
            
            #line 296 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            this.btnNew.KeyDown += new System.Windows.Input.KeyEventHandler(this.btnNew_KeyDown);
            
            #line default
            #line hidden
            
            #line 296 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            this.btnNew.KeyUp += new System.Windows.Input.KeyEventHandler(this.btnNew_KeyUp);
            
            #line default
            #line hidden
            
            #line 296 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            this.btnNew.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnNew_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSave1 = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
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
            
            #line 52 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.txtTaxDescription_KeyUp);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.txtTaxDescription_KeyDown);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 60 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.txtTaxRate_KeyUp);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.txtTaxRate_KeyDown);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\..\Settings\Views\TaxCodesAndRatesView.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.DecimalTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

