using System.Security.Cryptography;

namespace EquipmentManagement.ConsoleApp.Core;

public abstract class BaseEntity<T>
{
  public string Id { get; set; } = Convert
          .ToHexStringLower(RandomNumberGenerator.GetBytes(20))
          .Substring(0, 7);

  public abstract List<string> Validate();
  public abstract void UpdateData(T updatedEntity);
}
