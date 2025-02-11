namespace Gestionale.DomainModel;

public class AllStoragesViewModel
{
    public List<Storage> Storages { get; set; }

    public AllStoragesViewModel(List<Storage> storages)
    {
        Storages = storages;
    }
}