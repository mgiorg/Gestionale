using System.Net.Sockets;
using Gestionale.Database;
using Gestionale.DomainModel;
using Gestionale.Helpers;

namespace Gestionale.Repository;

public class ProductRepository
{
    //Funzioni di query nel Db con una creazione di nuova istanza di Db
    public List<Product> GetProducts()
    {
        using var db = new GestionaleDatabase();
        var prod = (from p in db.Products select p).ToList();
        return prod;
    }

    public Product? FindById(int id)
    {
        using var db = new GestionaleDatabase();
        //Ritorna null se il prodotto non è stato trovato
        return db.Products.FirstOrDefault(p => p.Id == id);
    }

    public CommandResponse Save(Product product)
    {
        using var db = new GestionaleDatabase();
        var found = (from p in db.Products where p.Id == product.Id select p).FirstOrDefault();
        return found != null
            ? UpdateInternal(found, product, db)
            : InsertInternal(product, db);
    }

    public CommandResponse InsertInternal(Product product, GestionaleDatabase db)
    {
        try
        {
            db.Add(product);
            db.SaveChanges();
            return CommandResponse.Ok("Product saved", "/product/all");
        }
        catch
        {
            return CommandResponse.Error("Product not found", "/product/all");
        }
    }

    public CommandResponse UpdateInternal(Product found, Product product, GestionaleDatabase db)
    {
        try
        {
            found.Name = product.Name;
            found.Brand = product.Brand;
            found.Price = product.Price;
            found.Description = product.Description;
            db.SaveChanges();
            return CommandResponse.Ok("Product updated", "/product/all");
        }
        catch
        {
            return CommandResponse.Error("Product not found", "/product/all");
        }
    }

    public CommandResponse Delete(int id)
    {
        using var db = new GestionaleDatabase();
        var found = (from p in db.Products where p.Id == id select p).FirstOrDefault();
        if (found != null)
        {
            db.Remove(found);
            db.SaveChanges();
            return CommandResponse.Ok("Product deleted", "/product/all");
        }
        return CommandResponse.Error("Product not found", "/product/all");
    }
}