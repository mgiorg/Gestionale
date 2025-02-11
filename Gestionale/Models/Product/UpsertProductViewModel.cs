namespace Gestionale.DomainModel;

public class UpsertProductViewModel
{
    public Product Product { get; set; }

    public UpsertProductViewModel(Product product)
    {
        Product = product;
    }
}