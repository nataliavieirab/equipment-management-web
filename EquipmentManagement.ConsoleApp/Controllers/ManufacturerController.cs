using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;
using EquipmentManagement.ConsoleApp.Manufacturers;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.ConsoleApp.Controllers;

public class ManufacturerController : Controller
{
  private readonly IRepository<Manufacturer> manufacturerRepository;

  public ManufacturerController()
  {
    ContextJson context = new ContextJson();
    context.Load();

    manufacturerRepository =
      new FileBasedManufacturerRepository(context);
  }

  [HttpGet]
  public ActionResult List()
  {
    List<Manufacturer> manufacturers = manufacturerRepository.FindAll();

    return View(manufacturers);
  }

  [HttpGet]
  public ActionResult Register()
  {
    List<Manufacturer> manufacturers = manufacturerRepository.FindAll();

    return View(manufacturers);
  }

  [HttpPost]
  public ActionResult Register(string name, string email, string phone)
  {
    Manufacturer manufacturer = new(name, email, phone);

    manufacturerRepository.Register(manufacturer);

    return RedirectToAction(nameof(List));
  }

  [HttpGet]
  public ActionResult Edit(string id)
  {

    Manufacturer manufacturer = manufacturerRepository.FindById(id);

    if (manufacturer == null)
      return RedirectToAction(nameof(List));

    return View(manufacturer);
  }

  [HttpPost]
  public ActionResult Edit(string id, string name, string email, string phone)
  {

    Manufacturer manufacturer = new Manufacturer(name, email, phone);

    manufacturerRepository.Edit(id, manufacturer);

    return RedirectToAction(nameof(List));
  }
}