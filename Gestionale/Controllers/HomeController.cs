using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gestionale.Models;
using Gestionale.Services;

namespace Gestionale.Controllers;

public class HomeController : Controller
{
    private readonly StorageService _storageService;
    private readonly ProductService _productService;
    private readonly TransportService _transportService;

    public HomeController(StorageService storageService, ProductService productService, TransportService transportService)
    {
        _storageService = storageService;
        _productService = productService;
        _transportService = transportService;
    }

    public IActionResult Index()
    {
        // 1) Recupero le liste di ViewModel
        var storages = _storageService.GetAllStoragesViewModel();
        var products = _productService.GetAllProductsViewModel();
        var transports = _transportService.GetAllTransportsViewModel();
        
        // 2) Li incapsulo tutti nel costruttore
        var vm = new HomeIndexViewModel
        {
            Storages = storages,
            Products = products,
            Transports = transports
        };
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}