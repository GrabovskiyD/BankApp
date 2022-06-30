namespace BankApp1.Model;

public class ClientDTO
{
    private string firstName;
    private string lastName;
    private string? middleName;
    private string fullName;
    private string phoneNumber;
    private string? passportSeries;
    private string? passportNumber;

    public ClientDTO(Client client, MainWindow mainWindow)
    {
        this.firstName = client.FirstName;
        this.lastName = client.LastName;
        this.middleName = client.MiddleName;
        this.fullName = $"{this.lastName} {this.firstName} {this.middleName}";
        this.phoneNumber = client.PhoneNumber;
        if (mainWindow.employee is Consultant)
        {
            if (passportSeries is not null && passportSeries != "")
            {
                PassportSeries = "********";
            }
            if (passportNumber is not null && passportNumber != "")
            {
                PassportNumber = "********";
            }
        }
        else if (mainWindow.employee is Manager)
        {
            PassportSeries = client.PassportSeries;
            PassportNumber = client.PassportNumber;
        }
    }

    public string FirstName
    {
        get => this.firstName;
        set
        {
            this.firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }
    public string LastName
    {
        get => this.lastName;
        set
        {
            this.lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }
    public string? MiddleName
    {
        get => this.middleName;
        set
        {
            this.middleName = value;
            OnPropertyChanged(nameof(MiddleName));
        }
    }
    public string FullName
    {
        get => this.fullName;
        set
        {
            this.fullName = value;
            OnPropertyChanged(nameof(MiddleName));
        }
    }
    public string PhoneNumber
    {
        get => this.phoneNumber;
        set
        {
            this.phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }
    public string? PassportSeries
    {
        get => this.passportSeries;
        set
        {
            this.passportSeries = value;
            OnPropertyChanged(nameof(PassportSeries));
        }
    }
    public string? PassportNumber
    {
        get => this.passportNumber;
        set
        {
            this.passportNumber = value;
            OnPropertyChanged(nameof(PassportNumber));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
