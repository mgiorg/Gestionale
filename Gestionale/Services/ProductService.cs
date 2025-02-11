using Gestionale.DomainModel;
using Gestionale.Helpers;
using Gestionale.Repository;

namespace Gestionale.Services;

public class ProductService
{
    private readonly ProductRepository _repo;

    public ProductService()
    {
        _repo = new ProductRepository();
    }

    public AllProductsViewModel GetAllProductsViewModel()
    {
        return new AllProductsViewModel(_repo.GetProducts());
    }

    public UpsertProductViewModel GetById(int id)
    {
        return new UpsertProductViewModel(
            _repo.FindById(id) ?? new()
        );
    }

    public CommandResponse Save(Product product)
    {
        var response = _repo.Save(product);
        return response;
    }

    public CommandResponse Delete(int id)
    {
        var response = _repo.Delete(id);
        return response;
    }
}