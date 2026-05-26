using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;
using EquipmentManagement.ConsoleApp.Equipments;
using EquipmentManagement.ConsoleApp.Models;
using EquipmentManagement.ConsoleApp.Tickets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquipmentManagement.ConsoleApp.Controllers;

public class TicketController : Controller
{
  private readonly IRepository<Ticket> _ticketRepository;
  private readonly IRepository<Equipment> _equipmentRepository;

  public TicketController()
  {
    ContextJson context = new();
    context.Load();

    _ticketRepository = new FileBasedTicketRepository(context);
    _equipmentRepository = new FileBasedEquipmentRepository(context);
  }

  [HttpGet]
  public ActionResult List()
  {
    List<Ticket> tickets = _ticketRepository.FindAll();

    List<ListTicketsViewModel> viewTickets = [];

    foreach (Ticket t in tickets)
    {
      ListTicketsViewModel ticketViewModel = new(
        t.Id,
        t.Title,
        t.Equipment.Name,
        t.OpeningDate,
        t.ElapsedDays,
        t.IsComplete
      );

      viewTickets.Add(ticketViewModel);
    }

    return View(viewTickets);
  }

  [HttpGet]
  public ActionResult Register()
  {
    ViewBag.Equipments = LoadEquipments();

    RegisterTicketViewModel registerViewModel = new RegisterTicketViewModel(
      string.Empty,
      null,
      string.Empty
    );

    return View(registerViewModel);
  }

  [HttpPost]
  public ActionResult Register(RegisterTicketViewModel registerViewModel)
  {

    Equipment? equipment = _equipmentRepository.FindById(registerViewModel.EquipmentId);

    if (!string.IsNullOrEmpty(registerViewModel.EquipmentId) && equipment == null)
    {
      ModelState.AddModelError(
        nameof(registerViewModel.EquipmentId),
        "Selecione um equipamento válido"
      );
    }

    if (!ModelState.IsValid)
    {
      ViewBag.Equipments = LoadEquipments();
      
      return View(registerViewModel);
    }

    Ticket ticket = new Ticket(
      registerViewModel.Title,
      equipment,
      registerViewModel.Description
    );

    _ticketRepository.Register(ticket);

    return RedirectToAction(nameof(List));
  }

  [HttpGet]
  public ActionResult Edit(string id)
  {
    Ticket? ticket = _ticketRepository.FindById(id);

    if (ticket == null)
      return RedirectToAction(nameof(List));

    EditTicketViewModel editViewModel = new EditTicketViewModel(
      ticket.Id,
      ticket.Title,
      ticket.Description,
      ticket.Equipment.Id
    );

    ViewBag.Equipments = LoadEquipments();

    return View(editViewModel);
  }
  
  [HttpPost]
  public ActionResult Edit(EditTicketViewModel editViewModel)
  {
    Equipment? equipment = _equipmentRepository.FindById(editViewModel.EquipmentId);

    if (!string.IsNullOrEmpty(editViewModel.EquipmentId) && equipment == null)
    {
      ModelState.AddModelError(
        nameof(editViewModel.EquipmentId),
        "Selecione um equipamento válido"
      );
    }

    if (!ModelState.IsValid)
    {
      ViewBag.Equipments = LoadEquipments();
      
      return View(editViewModel);
    }

    Ticket ticket = new Ticket(
      editViewModel.Title,
      equipment,
      editViewModel.Description
    );

    _ticketRepository.Edit(editViewModel.Id, ticket);

    return RedirectToAction(nameof(List));
  }
  
  private List<SelectListItem> LoadEquipments()
  {
    List<Equipment> equipments = _equipmentRepository.FindAll();

    List<SelectListItem> selectEquipments = new List<SelectListItem>();

    foreach (Equipment e in equipments)
    {
      SelectListItem selectEquipmentViewModel = new SelectListItem(
        e.Name,
        e.Id
      );

      selectEquipments.Add(selectEquipmentViewModel);
    }

    return selectEquipments;
  }
}