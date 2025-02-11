using Gestionale.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Gestionale.Database;

public partial class GestionaleDatabase
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Azioni per lo storage
        modelBuilder.Entity<Storage>()
            .HasKey(s => s.Id);
        modelBuilder.Entity<Storage>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd(); //L'Id si genera automaticamente incrementato di 1
        
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd(); //L'Id si genera automaticamente incrementato di 1
        
        modelBuilder.Entity<Transport>()
            .HasKey(t=>t.Id);
        modelBuilder.Entity<Transport>()
            .Property(t=>t.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Transport>()
            .HasOne(t=>t.Product)
            .WithMany(p=>p.Transports)
            .HasForeignKey(t=>t.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Transport>()
            .HasOne(t=>t.Storage)
            .WithMany(s=>s.Transports)
            .HasForeignKey(t=>t.StorageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}