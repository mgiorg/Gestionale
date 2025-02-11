using Gestionale.DomainModel;
using Gestionale.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestionale.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [Route("/product/all")]
    public IActionResult All()
    {
        var model = _service.GetAllProductsViewModel();
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int id = 0)
    {
        var model = _service.GetById(id);
        return View(model);
    }

    [Route("/product/save")]
    [HttpPost]
    public IActionResult Save(Product product)
    {
        var response = _service.Save(product);
        return Json(response);
    }

    [HttpPost]
    [Route("/product/delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var response = _service.Delete(id);
        return Json(response);
    }
}