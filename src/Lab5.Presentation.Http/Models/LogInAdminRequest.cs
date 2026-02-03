using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models;

public sealed class LogInAdminRequest
{
    [NotNull]
    [Required]
    public string? SystemPassword { get; set; }
}