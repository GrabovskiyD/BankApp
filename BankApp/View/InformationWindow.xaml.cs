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

namespace BankApp.View
{
    /// <summary>
    /// Логика взаимодействия для InformationWindow.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
        private string text;
        public string Text 
        {
            get => text;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    text = value;
                    informationTextBox.Text = text;
                }
            }
        }
        public InformationWindow()
        {
            InitializeComponent();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
