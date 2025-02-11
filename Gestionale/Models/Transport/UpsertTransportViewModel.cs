namespace Gestionale.DomainModel;

public class UpsertTransportViewModel
{
    public List<Storage> Storages { get; set; }
    public List<Product> Products { get; set; }
    public Transport Transport { get; set; }

    public UpsertTransportViewModel(Transport transport, List<Storage> storages, List<Product> products)
    {
        Transport = transport;
        Storages = storages;
        Products = products;
    }
}