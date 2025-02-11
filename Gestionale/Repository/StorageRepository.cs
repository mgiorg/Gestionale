using System.Net.Sockets;
using Gestionale.Database;
using Gestionale.DomainModel;
using Gestionale.Helpers;

namespace Gestionale.Repository;

public class StorageRepository
{
    //Funzioni di query nel Db con una creazione di nuova istanza di Db
    public List<Storage> GetStorages()
    {
        using var db = new GestionaleDatabase();
        var stor = (from p in db.Storages select p).ToList();
        return stor;
    }

    public Storage? FindById(int id)
    {
        using var db = new GestionaleDatabase();
        //Ritorna null se il prodotto non è stato trovato
        return db.Storages.FirstOrDefault(p => p.Id == id);
    }

    public CommandResponse Save(Storage storage)
    {
        using var db = new GestionaleDatabase();
        var found = (from s in db.Storages where s.Id == storage.Id select s).FirstOrDefault();
        return found != null 
            ? UpdateInternal(found, storage, db)
            : InsertInternal(storage, db);
    }

    private CommandResponse InsertInternal(Storage storage, GestionaleDatabase db)
    {
        try
        {
            db.Add(storage);
            db.SaveChanges();
            return CommandResponse.Ok("Storage saved", "/storage/all");
        }
        catch
        {
            return CommandResponse.Error("Storage not found", "/storage/all");
        }
    }

    private CommandResponse UpdateInternal(Storage found, Storage storage, GestionaleDatabase db)
    {
        try
        {
            found.City = storage.City;
            found.Address = storage.Address;
            found.Active = storage.Active;
            db.SaveChanges();
            return CommandResponse.Ok("Storage updated", "/storage/all");
        }
        catch
        {
            return CommandResponse.Error("Storage not found", "/storage/all");
        }
    }

    public CommandResponse Delete(int id)
    {
        using var db = new GestionaleDatabase();
        var found = (from s in db.Storages where s.Id == id select s).FirstOrDefault();
        if (found != null)
        {
            db.Remove(found);
            db.SaveChanges();
            return CommandResponse.Ok("Storage deleted", "/storage/all");
        }
        return CommandResponse.Error("Storage not found", "/storage/all");
    }
}