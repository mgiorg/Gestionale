using Gestionale.DomainModel;
using Gestionale.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestionale.Controllers;

public class TransportController : Controller
{
    private readonly TransportService _service;

    public TransportController(TransportService service)
    {
        _service = service;
    }

    [Route("/transport/all")]
    public IActionResult All()
    {
        var model = _service.GetAllTransportsViewModel();
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int id = 0)
    {
        var model = _service.GetById(id);
        return View(model);
    }

    [HttpPost]
    [Route("/transport/save/")]
    public IActionResult Save(Transport transport)
    {
        var response = _service.Save(transport);
        return Json(response);
    }
    
    [HttpPost]
    [Route("/transport/delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var response = _service.Delete(id);
        return Json(response);
    }
}