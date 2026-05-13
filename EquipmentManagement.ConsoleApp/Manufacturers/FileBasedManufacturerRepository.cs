using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Core.Files;

namespace EquipmentManagement.ConsoleApp.Manufacturers;

public class FileBasedManufacturerRepository :
    FileBasedBaseRepository<Manufacturer>, IRepository<Manufacturer>
{
  public FileBasedManufacturerRepository(ContextJson context) : base(context) { }

  protected override List<Manufacturer> LoadRecords()
  {
    return context.Manufacturers;
  }

}