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

  public ActionResult List()
  {
    List<Manufacturer> manufacturers = manufacturerRepository.FindAll();

    return View(manufacturers);
  }

}