using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;
using EquipmentManagement.ConsoleApp.Manufacturers;
using EquipmentManagement.ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.ConsoleApp.Controllers;

public class ManufacturerController : Controller
{
  private readonly IRepository<Manufacturer> _manufacturerRepository;

  public ManufacturerController()
  {
    ContextJson context = new ContextJson();
    context.Load();

    _manufacturerRepository =
      new FileBasedManufacturerRepository(context);
  }

  [HttpGet]
  public ActionResult List()
  {
    List<Manufacturer> manufacturers = _manufacturerRepository.FindAll();

    List<ListManufacturerViewModel> listViewModels = [];

    foreach(Manufacturer m in manufacturers)
    {
      ListManufacturerViewModel viewModel = new(m.Id, m.Name, m.Email, m.Phone);

      listViewModels.Add(viewModel);
    }

    return View(listViewModels);
  }

  [HttpGet]
  public ActionResult Register()
  {
    List<Manufacturer> manufacturers = _manufacturerRepository.FindAll();

    return View(manufacturers);
  }

  [HttpPost]
  public ActionResult Register(RegisterManufacturerViewModel registerViewModel)
  {
    Manufacturer manufacturer = new(
      registerViewModel.Name,
      registerViewModel.Email,
      registerViewModel.Phone
    );

    _manufacturerRepository.Register(manufacturer);

    return RedirectToAction(nameof(List));
  }

  [HttpGet]
  public ActionResult Edit(string id)
  {

    Manufacturer? manufacturer = _manufacturerRepository.FindById(id);

    if (manufacturer == null)
      return RedirectToAction(nameof(List));

    EditManufacturerViewModel editViewModel = new(
      id,
      manufacturer.Name,
      manufacturer.Email,
      manufacturer.Phone
    );

    return View(editViewModel);
  }

  [HttpPost]
  public ActionResult Edit(EditManufacturerViewModel editViewModel)
  {

    Manufacturer manufacturer = new Manufacturer(
      editViewModel.Name,
      editViewModel.Email,
      editViewModel.Phone
    );

    _manufacturerRepository.Edit(editViewModel.Id, manufacturer);

    return RedirectToAction(nameof(List));
  }


  [HttpGet]
  public ActionResult Delete(string id)
  {

    Manufacturer? manufacturer = _manufacturerRepository.FindById(id);

    if (manufacturer == null)
      return RedirectToAction(nameof(List));

    DeleteManufacturerViewModel deleteViewModel = new DeleteManufacturerViewModel(
      id,
      manufacturer.Name,
      manufacturer.Email,
      manufacturer.Phone
    );

    return View(deleteViewModel);
  }

  [HttpPost]
  [ActionName("Delete")]
  public ActionResult SuccessDelete(DeleteManufacturerViewModel deleteViewModel)
  {
    Manufacturer? manufacturer = _manufacturerRepository.FindById(deleteViewModel.Id);

    if (manufacturer == null)
      return RedirectToAction(nameof(List));

    _manufacturerRepository.Delete(manufacturer);

    return RedirectToAction(nameof(List));
  }
}