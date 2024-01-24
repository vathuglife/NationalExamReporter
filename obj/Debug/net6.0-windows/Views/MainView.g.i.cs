﻿#pragma checksum "..\..\..\..\Views\MainView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5C7A10CBEAED18867AA14F9A4BE7E0654F451545"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace NationalExamReporter.Views {
    
    
    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome LoadingIcon;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CurrentCsvFileTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox YearComboBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadCsvFromSelectedYearButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid StudentsDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NationalExamReporter;V1.0.0.0;component/views/mainview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\MainView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LoadingIcon = ((FontAwesome.WPF.ImageAwesome)(target));
            return;
            case 2:
            this.CurrentCsvFileTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.YearComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\..\Views\MainView.xaml"
            this.YearComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.HandleYearChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LoadCsvFromSelectedYearButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Views\MainView.xaml"
            this.LoadCsvFromSelectedYearButton.Click += new System.Windows.RoutedEventHandler(this.LoadCsvFromSelectedYear);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 24 "..\..\..\..\Views\MainView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddCsv);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 25 "..\..\..\..\Views\MainView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteCsv);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\..\..\Views\MainView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowAverageScoreByProvince);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StudentsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

