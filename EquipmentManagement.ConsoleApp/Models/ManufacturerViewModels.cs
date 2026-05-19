namespace EquipmentManagement.ConsoleApp.Models;

public record ListManufacturerViewModel(
  string Id,
  string Name,
  string Email,
  string Phone
);
public record RegisterManufacturerViewModel(
  string Name,
  string Email,
  string Phone
);

public record EditManufacturerViewModel(
  string Id, 
  string Name,
  string Email,
  string Phone
);

public record DeleteManufacturerViewModel(
  string Id, 
  string Name,
  string Email,
  string Phone
);