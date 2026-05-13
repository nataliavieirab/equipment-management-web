using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;

namespace EquipmentManagement.ConsoleApp.Equipments;

public class FileBasedEquipmentRepository :
    FileBasedBaseRepository<Equipment>, IRepository<Equipment>
{
  public FileBasedEquipmentRepository(ContextJson context) : base(context) { }

  protected override List<Equipment> LoadRecords()
  {
    return context.Equipments;
  }
}