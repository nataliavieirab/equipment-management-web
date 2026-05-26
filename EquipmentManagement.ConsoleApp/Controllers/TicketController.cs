using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;
using EquipmentManagement.ConsoleApp.Models;
using EquipmentManagement.ConsoleApp.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.ConsoleApp.Controllers;

public class TicketController : Controller
{
  private readonly IRepository<Ticket> _ticketRepository;
  // private readonly IRepository<Equipment> _equipmentRepository;

  public TicketController()
  {
    ContextJson context = new();
    context.Load();

    _ticketRepository = new FileBasedTicketRepository(context);
    // _equipmentRepository = new FileBasedEquipmentRepository(context);
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

}