namespace Gestionale.DomainModel;

public class AllProductsViewModel
{
    public List<Product> Products { get; set; }

    public AllProductsViewModel(List<Product> products)
    {
        Products = products;
    }
}