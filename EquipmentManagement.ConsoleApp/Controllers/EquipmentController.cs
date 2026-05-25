using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;
using EquipmentManagement.ConsoleApp.Equipments;
using EquipmentManagement.ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.ConsoleApp.Controllers;
public class EquipmentController : Controller
{
  private readonly IRepository<Equipment> _equipmentRepository;

  public EquipmentController()
  {
    ContextJson context = new ContextJson();
    context.Load();

    _equipmentRepository = new FileBasedEquipmentRepository(context);
  }

  [HttpGet]
  public ActionResult List()
  {

    List<Equipment> equipments = _equipmentRepository.FindAll();

    List<ListEquipmentsViewModel> listViewModels = [];

    foreach (Equipment e in equipments)
    {
        ListEquipmentsViewModel viewModel = new(
                e.Id,
                e.Name,
                e.PurchasePrice,
                e.ManufacturingDate,
                e.Manufacturer.Name
            );

            listViewModels.Add(viewModel);
    }

    return View(listViewModels);
  }
}