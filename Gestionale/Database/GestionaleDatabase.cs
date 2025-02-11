using Gestionale.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Gestionale.Database
{
    public partial class GestionaleDatabase : DbContext
    {
        public static string ConnectionString = "Data Source=database.db";
    
        public GestionaleDatabase(DbContextOptions<GestionaleDatabase> options) : base(options)
        {
        }

        public GestionaleDatabase()
        {
        }
        
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transport> Transports { get; set; }

        public void Seed()
        {
            /*
            var stor = new Storage()
            {
                City = "Roma",
                Address = "Via Alberto 255",
                Active = false
            };
            if(!Storages.Contains(stor)) Storages.Add(stor);
            SaveChanges();

            var prod = new Product()
            {
                Name = "Latte",
                Brand = "Parmalat",
                Price = 1.20m,
                Description = "Il latte più buono dell'Italia!"
            };
            if(!Products.Contains(prod)) Products.Add(prod);
            SaveChanges();

            var tra = new Transport()
            {
                ProductId = prod.Id,
                StorageId = stor.Id,
                DestCity = "Milano",
                DestAddress = "Via NonLoSo 138",
                Cost = 5.0m
            };
            if(!Transports.Contains(tra)) Transports.Add(tra);
            SaveChanges();
            */
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}


