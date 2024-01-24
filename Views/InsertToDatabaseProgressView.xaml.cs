using System;
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
using System.Windows.Shapes;

namespace NationalExamReporter.Views
{  
    public partial class InsertToDatabaseProgressView : Window
    {
        public InsertToDatabaseProgressView()
        {
            InitializeComponent();
            SetDefaultWindowValues();
        }

        public void UpdateProgressText(string text)
        {
            
        }

        private void SetDefaultWindowValues()
        {
            ProgressText.Content = "0%";
            ProgressBar.Value = 0;
        }
    }
}
