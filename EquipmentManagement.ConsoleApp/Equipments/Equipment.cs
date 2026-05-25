using EquipmentManagement.ConsoleApp.Core;
using EquipmentManagement.ConsoleApp.Manufacturers;

namespace EquipmentManagement.ConsoleApp.Equipments;

public class Equipment : BaseEntity<Equipment>
{
  public string Name { get; set; } = string.Empty;
  public decimal PurchasePrice { get; set; }
  public DateTime ManufacturingDate { get; set; }
  public Manufacturer Manufacturer { get; set; } = null!;

  public Equipment() { }

  public Equipment(
      string name,
      decimal purchasePrice,
      DateTime manufacturingDate,
      Manufacturer manufacturer
  ) : this()
  {
    Name = name;
    PurchasePrice = purchasePrice;
    ManufacturingDate = manufacturingDate;
    Manufacturer = manufacturer;
  }

  public override List<string> Validate()
  {
    List<string> errors = new List<string>();

    if (string.IsNullOrWhiteSpace(Name) || Name.Length < 2 || Name.Length > 50)
      errors.Add("O campo \"Nome\" deve conter entre 2 e 50 caracteres.");

    if (PurchasePrice <= 0)
      errors.Add("O campo \"Preço de Aquisição\" deve conter um valor positivo.");

    if (ManufacturingDate > DateTime.Now)
      errors.Add("O campo \"Data de Fabricação\" deve conter uma data do passado.");

    return errors;
  }

  public override void UpdateData(Equipment updatedEntity)
  {
    Name = updatedEntity.Name;
    PurchasePrice = updatedEntity.PurchasePrice;
    ManufacturingDate = updatedEntity.ManufacturingDate;
    Manufacturer = updatedEntity.Manufacturer;
  }
}