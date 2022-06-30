namespace BankApp1;

public class Client
{
    public Client() { }
    public Client(string lastName, string firstName, string middleName, string phoneNumber, string? passportSeries, string passsportNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        PhoneNumber = phoneNumber;
        PassportSeries = passportSeries;
        PassportNumber = passsportNumber;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string PhoneNumber { get; set; }
    public string? PassportSeries { get; set; }
    public string? PassportNumber { get; set; }
}
