namespace BankApp1.Model;

public class Bank
{
    private ObservableCollection<ClientDTO> clientsDTO;
    public ObservableCollection<ClientDTO> Clients { get { return clientsDTO; } }

    public Bank(MainWindow mainWindow)
    {
        clientsDTO = new ObservableCollection<ClientDTO>();
        using(FileStream fs = new FileStream("clients.json", FileMode.Open))
        {
            ObservableCollection<Client>? clients = JsonSerializer.Deserialize<ObservableCollection<Client>>(fs);
            foreach(Client client in clients)
            {
                ///MessageBox.Show($"{client.FirstName {client.LastName}");
                clientsDTO.Add(new ClientDTO(client, mainWindow));
            }
        }
    }
}
