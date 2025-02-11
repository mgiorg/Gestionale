using Gestionale.DomainModel;

namespace Gestionale.Models;

public class HomeIndexViewModel
{
    public AllStoragesViewModel Storages { get; set; }
    public AllProductsViewModel Products { get; set; }
    public AllTransportsViewModel Transports { get; set; }
}