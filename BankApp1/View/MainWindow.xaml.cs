namespace BankApp1.View;

public partial class MainWindow : Window
{
    public Bank bank;
    public Employee employee;
    public AppModelViewModel appModelView;
    public LogInPage logInPage;
    public MainWindow()
    {
        DB dB = new DB();
        InitializeComponent();
        ShowAuthorizationWindow();
    }
    
    private void ShowAuthorizationWindow()
    {
        logInPage = new LogInPage(this, bank);
        logInPage.ShowDialog();
    }
}
