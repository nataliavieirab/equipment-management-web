using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Equipments;
namespace EquipmentManagement.ConsoleApp.Tickets;

public class Ticket : BaseEntity<Ticket>
{
  public string Title { get; set; } = string.Empty;
  public string? Description { get; set; }
  public Equipment Equipment { get; set; } = null!;
  public DateTime OpeningDate { get; set; } = DateTime.Now;
  public bool IsComplete { get; set; }
  public int ElapsedDays
  {
    get
    {
      TimeSpan timeDifference = DateTime.Now.Subtract(OpeningDate);

      return timeDifference.Days;
    }
  }

  public Ticket(string title, Equipment equipment, string? description = null) : this()
  {
    Title = title;
    Equipment = equipment;
    Description = description;
  }

  public Ticket() { }

  public void Complete()
  {
    IsComplete = true;
  }

  public override List<string> Validate()
  {
    List<string> errors = [];

    if (string.IsNullOrWhiteSpace(Title) || Title.Length < 2 || Title.Length > 50)
      errors.Add("O campo \"Título\" deve conter entre 2 e 50 caracteres.");

    if (Equipment == null)
      errors.Add("O campo \"Equipamento\" deve ser preenchido.");

    return errors;
  }

  public override void UpdateData(Ticket updatedEntity)
  {
    Title = updatedEntity.Title;
    Description = updatedEntity.Description;
    Equipment = updatedEntity.Equipment;
  }
}