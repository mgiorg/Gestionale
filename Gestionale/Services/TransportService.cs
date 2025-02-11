using Gestionale.DomainModel;
using Gestionale.Helpers;
using Gestionale.Repository;

namespace Gestionale.Services;

public class TransportService
{
    private readonly TransportRepository _repo;
    private readonly ProductRepository _productRepo;
    private readonly StorageRepository _storageRepo;

    public TransportService()
    {
        _repo = new TransportRepository();
        _productRepo = new ProductRepository();
        _storageRepo = new StorageRepository();
    }
    
    public AllTransportsViewModel GetAllTransportsViewModel()
    {
        return new AllTransportsViewModel(_repo.GetTransports());
    }

    public UpsertTransportViewModel GetById(int id)
    {
        return new UpsertTransportViewModel(
            _repo.FindById(id) ?? new(),
            _storageRepo.GetStorages(),
            _productRepo.GetProducts()
        );
    }

    public CommandResponse Save(Transport transport)
    {
        var response = _repo.Save(transport);
        return response;
    }

    public CommandResponse Delete(int id)
    {
        var response = _repo.Delete(id);
        return response;
    }
}