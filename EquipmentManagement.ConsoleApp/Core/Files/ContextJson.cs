using System.Text.Json;
using System.Text.Json.Serialization;
using EquipmentManagement.ConsoleApp.Equipments;
using EquipmentManagement.ConsoleApp.Manufacturers;
using EquipmentManagement.ConsoleApp.Tickets;

namespace EquipmentManagement.ConsoleApp.Core.Files;

public sealed class ContextJson
{
  public List<Equipment> Equipments { get; set; } = new List<Equipment>();
  public List<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
  public List<Ticket> Tickets { get; set; } = new List<Ticket>();

  private readonly string filePath;

  public ContextJson()
  {
    string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    string directoryPath = Path.Combine(appDataPath, "EquipmentManagementWeb");

    Directory.CreateDirectory(directoryPath);

    filePath = Path.Combine(directoryPath, "data.json");
  }

  public void Save()
  {
    JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
    opcoesJson.WriteIndented = true;
    opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

    string jsonString = JsonSerializer.Serialize(this, opcoesJson);

    File.WriteAllText(filePath, jsonString);
  }

  public void Load()
  {
    if (!File.Exists(filePath))
      return;

    string jsonString = File.ReadAllText(filePath);

    JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
    jsonOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

    ContextJson? savedContext = JsonSerializer.Deserialize<ContextJson>(jsonString, jsonOptions);

    if (savedContext == null)
      return;

    this.Equipments = savedContext.Equipments;
    this.Manufacturers = savedContext.Manufacturers;
    this.Tickets = savedContext.Tickets;
  }
}
