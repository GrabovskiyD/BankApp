using BankApp1.Model;

namespace BankApp1.View;

public partial class LogInPage : Window
{
    public MainWindow mainWindow;
    public LogInPage(MainWindow mainWindow, Bank bank)
    {
        this.mainWindow = mainWindow;
        InitializeComponent();

        consultantButton.Click += delegate (object sender, RoutedEventArgs e)
        {
            mainWindow.employee = new Consultant();
            mainWindow.bank = new Bank(mainWindow);
            mainWindow.appModelView = new AppModelViewModel(mainWindow.bank);
            mainWindow.DataContext = mainWindow.appModelView;
            mainWindow.Visibility = Visibility.Visible;
            Close();
        };

        managerButton.Click += delegate (object sender, RoutedEventArgs e)
        {
            mainWindow.employee = new Manager();
            mainWindow.bank = new Bank(mainWindow);
            mainWindow.appModelView = new AppModelViewModel(mainWindow.bank);
            mainWindow.DataContext = mainWindow.appModelView;
            mainWindow.Visibility = Visibility.Visible;
            Close();
        };
    }
}
