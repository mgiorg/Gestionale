namespace Gestionale.DomainModel;

public class Product
{
    //Primary key
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    
    public ICollection<Transport> Transports { get; set; } = new List<Transport>();
}