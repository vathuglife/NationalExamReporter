
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using NationalExamReporter.Models;
using NationalExamReporter.RelayCommands;
using NationalExamReporter.Services;
using NationalExamReporter.Services.Implementation;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.ViewModels;
using NationalExamReporter.ViewModels.Parameters;


namespace NationalExamReporter.Views
{  
    public partial class InsertToDatabaseProgressView : Window
    {
        public InsertToDatabaseProgressViewModel? _viewModel;
        
        public InsertToDatabaseProgressView(InsertStudentDataParameters parameters)
        {
            InitializeComponent();
            InstantiateViewModel(parameters);
            StartInsertToDatabase();
            this.DataContext = _viewModel;
            this.Show();
        }
        
        private void InstantiateViewModel(InsertStudentDataParameters parameters)
        {
            _viewModel = new InsertToDatabaseProgressViewModel(parameters);
            
        }

        private void StartInsertToDatabase()
        {
            InsertToDatabaseRC insertToDatabaseRc = new InsertToDatabaseRC(
                _viewModel!.InsertStudentData
                );
            insertToDatabaseRc.Execute(null);      
        }
    }
}
