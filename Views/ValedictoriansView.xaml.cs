using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.ViewModels;

namespace NationalExamReporter.Views
{
    public partial class ValedictoriansView : Window
    {
        private List<CsvStudent>? _csvStudents;
        private ValedictoriansViewModel? _viewModel;
        private List<ValedictoriansDetails>? _valedictoriansDetails;

        public ValedictoriansView(ValedictoriansParameters parameters)
        {
            InitializeComponent();
            InitializeObjects();
            AssignValuesToPrivateMembers(parameters);
            RefreshValedictorians();
        }

        private void RefreshValedictorians()
        {
            _valedictoriansDetails = _viewModel!.GetValedictoriansDetails(_csvStudents!);
            ValedictoriansDetailsDataGrid.ItemsSource = _valedictoriansDetails;
        }

        private void InitializeObjects()
        {
            _viewModel = new ValedictoriansViewModel();
        }

        private void AssignValuesToPrivateMembers(ValedictoriansParameters parameters)
        {
            _csvStudents = parameters.CsvStudents;
        }
    }
}