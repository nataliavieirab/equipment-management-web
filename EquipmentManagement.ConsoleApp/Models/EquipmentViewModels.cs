namespace EquipmentManagement.ConsoleApp.Models;

public record ListEquipmentsViewModel(
  string Id,
  string Name,
  decimal PurchasePrice,
  DateTime ManufacturingDate,
  string Manufacturer
);