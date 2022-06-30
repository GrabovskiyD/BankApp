namespace BankApp1.Model;

public class DB
{
    private ObservableCollection<Client> clients = new ObservableCollection<Client>()
    {
        new Client("Фёдоров", "Мирон", "Янович", "898519853101", "", "1111111"),
        new Client("Алексеев", "Иван", "Александрович", "87051985309", "", "2222222")
    };
    public DB()
    {
        using(FileStream fs = new FileStream("clients.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<ObservableCollection<Client>>(fs, clients);
        }
    }
}
