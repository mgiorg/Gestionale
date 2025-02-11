namespace Gestionale.DomainModel;

public class UpsertStorageViewModel
{
    public Storage Storage { get; set; }
    public UpsertStorageViewModel(Storage storage)
    {
        Storage = storage;
    }
}