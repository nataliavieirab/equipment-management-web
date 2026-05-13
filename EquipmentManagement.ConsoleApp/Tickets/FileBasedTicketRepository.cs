using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;

namespace EquipmentManagement.ConsoleApp.Tickets;

public class FileBasedTicketRepository : FileBasedBaseRepository<Ticket>, IRepository<Ticket>
{
  public FileBasedTicketRepository(ContextJson context) : base(context) { }

  protected override List<Ticket> LoadRecords()
  {
    return context.Tickets;
  }
}
