using Gestionale.Database;
using Gestionale.DomainModel;
using Gestionale.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Gestionale.Repository;

public class TransportRepository
{
    public List<Transport> GetTransports()
    {
        using var db = new GestionaleDatabase();
        var transports = (from t in db.Transports select t)
            .Include(t=>t.Product)
            .Include(t=>t.Storage)
            .ToList();
        return transports;
    }

    public Transport? FindById(int id = 0)
    {
        using var db = new GestionaleDatabase();
        return db.Transports.FirstOrDefault(x => x.Id == id);
    }

    public CommandResponse Save(Transport transport)
    {
        using var db = new GestionaleDatabase();
        //var found = (from t in db.Transports where t.Id == transport.Id select t).FirstOrDefault();
        var found = db.Transports
                                    .FirstOrDefault(x => x.Id == transport.Id);
        return found != null
            ? UpdateInternal(found, transport, db)
            : InsertInternal(transport, db);
    }

    public CommandResponse InsertInternal(Transport transport, GestionaleDatabase db)
    {
        try
        {
            db.Add(transport);
            db.SaveChanges();
            return CommandResponse.Ok("Transport saved", "/transport/all");
        }
        catch
        {
            return CommandResponse.Error("Transport not found", "/transport/all");
        }
    }
    
    public CommandResponse UpdateInternal(Transport found, Transport transport, GestionaleDatabase db)
    {
        try
        {
            found.Id = transport.Id;
            found.ProductId = transport.ProductId;
            found.StorageId = transport.StorageId;
            found.DestCity = transport.DestCity;
            found.DestAddress = transport.DestAddress;
            found.Cost = transport.Cost;
            db.SaveChanges();
            return CommandResponse.Ok("Transport updated", "/transport/all");
        }
        catch
        {
            return CommandResponse.Error("Transport not found", "/transport/all");
        }
    }

    public CommandResponse Delete(int id)
    {
        using var db = new GestionaleDatabase();
        var found = (from t in db.Transports where t.Id == id select t).FirstOrDefault();
        if (found != null)
        {
            db.Remove(found);
            db.SaveChanges();
            return CommandResponse.Ok("Transport deleted", "/transport/all");
        }
        return CommandResponse.Error("Transport not found", "/transport/all");
    }
}