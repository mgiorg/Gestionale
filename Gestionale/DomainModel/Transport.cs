namespace Gestionale.DomainModel;

public class Transport
{
    //Primary key
    public int Id { get; set; }
    
    //Foreign keys
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int StorageId { get; set; }
    public Storage Storage { get; set; }
    
    public string DestCity { get; set; } = string.Empty;
    public string DestAddress { get; set; } = string.Empty;
    public decimal Cost { get; set; }
}