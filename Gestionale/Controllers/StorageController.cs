using Gestionale.DomainModel;
using Gestionale.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestionale.Controllers;

public class StorageController : Controller
{
    private readonly StorageService _service;

    public StorageController(StorageService service)
    {
        _service = service;
    }

    [Route("/storage/all")]
    public IActionResult All()
    {
        var model = _service.GetAllStoragesViewModel();
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int id = 0)
    {
        var model = _service.GetById(id);
        return View(model);
    }

    [Route("/storage/save")]
    [HttpPost]
    public IActionResult Save(Storage storage)
    {
        var response = _service.Save(storage);
        return Json(response);
    }

    [HttpPost]
    [Route("/storage/delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var response = _service.Delete(id);
        return Json(response);
    }
}