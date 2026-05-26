namespace EquipmentManagement.ConsoleApp.Models;

public record ListEquipmentsViewModel(
  string Id,
  string Name,
  decimal PurchasePrice,
  DateTime ManufacturingDate,
  string Manufacturer
);

public record RegisterEquipmentViewModel(
  string Name,
  decimal PurchasePrice,
  DateTime ManufacturingDate,
  string ManufacturerId
);

public record EditEquipmentViewModel(
  string Id,
  string Name,
  decimal PurchasePrice,
  DateTime ManufacturingDate,
  string ManufacturerId
);

public record DeleteEquipmentViewModel(
  string Id,
  string Name,
  decimal PurchasePrice,
  DateTime ManufacturingDate,
  string Manufacturer
);