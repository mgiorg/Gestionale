using System.Xml.Linq;
using Gestionale.DomainModel;
using Gestionale.Helpers;
using Gestionale.Repository;

namespace Gestionale.Services;

public class StorageService
{
    private readonly StorageRepository _repo;

    public StorageService()
    {
        _repo = new StorageRepository();
    }
    
    public AllStoragesViewModel GetAllStoragesViewModel()
    {
        return new AllStoragesViewModel(_repo.GetStorages());
    }

    public UpsertStorageViewModel GetById(int id)
    {
        return new UpsertStorageViewModel(
            _repo.FindById(id) ?? new()
        );
    }

    public CommandResponse Save(Storage storage)
    {
        var response = _repo.Save(storage);
        return response;
    }

    public CommandResponse Delete(int id)
    {
        var response = _repo.Delete(id);
        return response;
    }
}