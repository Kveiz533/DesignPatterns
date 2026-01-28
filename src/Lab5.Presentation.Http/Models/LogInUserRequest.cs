using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models;

public sealed class LogInUserRequest
{
    [NotNull]
    [Required]
    [RegularExpression(@"^\d{20}$", ErrorMessage = "Account number must be exactly 20 digits")]
    public string? AccountNumber { get; set; }

    [NotNull]
    [Required]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "PIN must be exactly 4 digits")]
    public string? PinCode { get; set; }
}