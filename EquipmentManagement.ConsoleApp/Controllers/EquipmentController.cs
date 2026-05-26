using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;
using EquipmentManagement.ConsoleApp.Equipments;
using EquipmentManagement.ConsoleApp.Manufacturers;
using EquipmentManagement.ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.ConsoleApp.Controllers;

public class EquipmentController : Controller
{
  private readonly IRepository<Equipment> _equipmentRepository;
  private readonly IRepository<Manufacturer> _manufacturerRepository;

  public EquipmentController()
  {
    ContextJson context = new();
    context.Load();

    _equipmentRepository = new FileBasedEquipmentRepository(context);
    _manufacturerRepository = new FileBasedManufacturerRepository(context);
  }

  [HttpGet]
  public ActionResult List()
  {

        List<Equipment> equipamentos = _equipmentRepository.FindAll();

        List<ListEquipmentsViewModel> listViewModels = new List<ListEquipmentsViewModel>();

        foreach (Equipment e in equipamentos)
        {
            ListEquipmentsViewModel viewModel = new ListEquipmentsViewModel(
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

  [HttpGet]
  public ActionResult Register()
  {

    ViewBag.Manufacturers = LoadManufacturers();

    return View();
  }

  [HttpPost]
  public ActionResult Register(RegistertEquipmentsViewModel registerViewModel)
  {

    Manufacturer? manufacturer = _manufacturerRepository.FindById(registerViewModel.ManufacturerId);

    if (manufacturer == null) return RedirectToAction(nameof(List));

    Equipment equipment = new Equipment(
      registerViewModel.Name,
      registerViewModel.PurchasePrice,
      registerViewModel.ManufacturingDate,
      manufacturer
      );
    
    _equipmentRepository.Register(equipment);

    return RedirectToAction(nameof(List));
  }

  private List<ListManufacturerViewModel> LoadManufacturers()
  {
    List<Manufacturer> manufacturers = _manufacturerRepository.FindAll();

    List<ListManufacturerViewModel> listViewModels = [];

    foreach (Manufacturer m in manufacturers)
    {
      ListManufacturerViewModel viewModel = new(m.Id, m.Name, m.Email, m.Phone);

      listViewModels.Add(viewModel);
    }

    return listViewModels;
  }
}