using System.ComponentModel.DataAnnotations;
namespace EquipmentManagement.ConsoleApp.Models;

public record ListTicketsViewModel(
    string Id,
    string Title,
    string Equipment,
    DateTime OpeningDate,
    int ElapsedDays,
    bool IsComplete
);

public record RegisterTicketViewModel(
    [Required(ErrorMessage = "O campo \"Título\" deve ser preenchido.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo \"Título\" deve conter entre 2 e 50 caracteres.")]
    string Title,

    [StringLength(500, ErrorMessage = "O campo \"Descrição\" deve conter no máximo 500 caracteres.")]
    string? Description,

    [Required(ErrorMessage = "O campo \"Equipamento\" deve ser preenchido.")]
    string EquipmentId
);

public record EditTicketViewModel(
    string Id,

    [Required(ErrorMessage = "O campo \"Título\" deve ser preenchido.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo \"Título\" deve conter entre 2 e 50 caracteres.")]
    string Title,

    [StringLength(500, ErrorMessage = "O campo \"Descrição\" deve conter no máximo 500 caracteres.")]
    string? Description,

    [Required(ErrorMessage = "O campo \"Equipamento\" deve ser preenchido.")]
    string EquipmentId
);