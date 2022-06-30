namespace BankApp1.ViewModel;

public class AppModelViewModel : INotifyPropertyChanged
{
    private ClientDTO? selectedClient;

    public ObservableCollection<ClientDTO> Clients { get; set; }

    public ClientDTO? SelectedClient
    {
        get { return selectedClient; }
        set
        {
            selectedClient = value;
            OnPropertyChanged("SelectedClient");
        }
    }

    public AppModelViewModel(Bank bank)
    {
        Clients = bank.Clients;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
