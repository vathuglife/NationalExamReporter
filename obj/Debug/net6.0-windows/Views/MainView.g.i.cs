// Updated by XamlIntelliSenseFileGenerator 17/1/2024 10:40:29 PM
#pragma checksum "..\..\..\..\Views\MainView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E2D91C09B1D0D110DDD5E388F6EA96A294D5FC33"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AverageScoreCalculator.Views;
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


namespace NationalExamReporter.Views
{


    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 12 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome LoadingIcon;

#line default
#line hidden


#line 13 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CurrentCsvFileTextBox;

#line default
#line hidden


#line 15 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox YearComboBox;

#line default
#line hidden


#line 17 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid StudentsDataGrid;

#line default
#line hidden


#line 18 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChooseCsvFileButton;

#line default
#line hidden


#line 19 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowAverageScoreByProvinceButton;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NationalExamReporter;component/views/mainview.xaml", System.UriKind.Relative);

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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
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
                    return;
                case 4:
                    this.StudentsDataGrid = ((System.Windows.Controls.DataGrid)(target));
                    return;
                case 5:
                    this.ChooseCsvFileButton = ((System.Windows.Controls.Button)(target));

#line 18 "..\..\..\..\Views\MainView.xaml"
                    this.ChooseCsvFileButton.Click += new System.Windows.RoutedEventHandler(this.AddCsv);

#line default
#line hidden
                    return;
                case 6:
                    this.ShowAverageScoreByProvinceButton = ((System.Windows.Controls.Button)(target));

#line 19 "..\..\..\..\Views\MainView.xaml"
                    this.ShowAverageScoreByProvinceButton.Click += new System.Windows.RoutedEventHandler(this.ShowAverageScoreByProvince);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button LoadCsvFromSelectedYearButton;
    }
}
