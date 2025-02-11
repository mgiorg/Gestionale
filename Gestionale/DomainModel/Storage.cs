namespace Gestionale.DomainModel;

public class Storage
{
    //Primary Key
    public int Id {get; set;}
    
    public string City {get; set;} = string.Empty;
    public string Address {get; set;} = string.Empty;
    public bool Active {get; set;}
    
    public ICollection<Transport> Transports {get; set;} = new List<Transport>();
}