using Gestionale.Database;
using Gestionale.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi questa riga dopo CreateBuilder
builder.WebHost.UseUrls("https://localhost:5001");  // Usa la porta specificata nel launch.json

// Registri il DbContext e specifichi di usare SQLite
builder.Services.AddDbContext<GestionaleDatabase>(options =>
{
    options.UseSqlite("Data Source=database.db");
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Aggiungi i tuoi servizi custom
builder.Services.AddScoped<StorageService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TransportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//setup db
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GestionaleDatabase>();
    db.Database.EnsureCreated();
    db.Seed();
    try
    {
        db.SaveChanges();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();