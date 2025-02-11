namespace Gestionale.DomainModel;

public class AllTransportsViewModel
{
    public List<Transport> Transports { get; set; }

    public AllTransportsViewModel(List<Transport> transports)
    {
        Transports = transports;
    }
}