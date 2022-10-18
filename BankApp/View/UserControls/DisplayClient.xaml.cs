using BankApp.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankApp.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DisplayClient.xaml
    /// </summary>
    public partial class DisplayClient : UserControl
    {
        public Client Client
        {
            get { return (Client)GetValue(ClientProperty); }
            set { SetValue(ClientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClientProperty =
            DependencyProperty.Register("Client", typeof(Client), typeof(DisplayClient), new PropertyMetadata(null, SetValues));
        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e) 
        {
            DisplayClient clientUserControl = d as DisplayClient;
            if(clientUserControl != null)
            {
                clientUserControl.DataContext = clientUserControl.Client;
            }
        }

        public DisplayClient()
        {
            InitializeComponent();
        }
    }
}
