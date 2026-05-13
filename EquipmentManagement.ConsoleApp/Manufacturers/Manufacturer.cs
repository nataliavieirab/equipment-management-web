using EquipmentManagement.ConsoleApp.Core;

namespace EquipmentManagement.ConsoleApp.Manufacturers;

public class Manufacturer : BaseEntity<Manufacturer>
{
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;

  public Manufacturer() { }

  public Manufacturer(string name, string email, string phone) : this()
  {
    Name = name;
    Email = email;
    Phone = phone;
  }

  public override List<string> Validate()
  {
    List<string> errors = new List<string>();

    if (string.IsNullOrWhiteSpace(Name) || Name.Length < 2 || Name.Length > 50)
      errors.Add("O campo \"Nome\" deve conter entre 2 e 50 caracteres.");

    if (string.IsNullOrWhiteSpace(Email))
      errors.Add("O campo \"Email\" deve ser preenchido.");

    if (string.IsNullOrWhiteSpace(Phone))
      errors.Add("O campo \"Telefone\" deve ser preenchido.");

    return errors;
  }

  public override void UpdateData(Manufacturer updatedEntity)
  {
    Name = updatedEntity.Name;
    Email = updatedEntity.Email;
    Phone = updatedEntity.Phone;
  }
}
