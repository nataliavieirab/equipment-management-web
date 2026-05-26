namespace EquipmentManagement.ConsoleApp.Models;

public record ListTicketsViewModel(
    string Id,
    string Title,
    string Equipment,
    DateTime OpeningDate,
    int ElapsedDays,
    bool IsComplete
);
