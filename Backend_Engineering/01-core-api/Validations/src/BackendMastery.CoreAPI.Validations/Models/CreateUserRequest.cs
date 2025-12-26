using System.ComponentModel.DataAnnotations;

namespace BackendMastery.CoreAPI.Validations.Models;

/// <summary>
/// Represents client input.
/// This is where boundary validation starts.
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    /// Email must be present and well-formed.
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Password must meet minimum strength requirements.
    /// </summary>
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Age is optional but must be reasonable if provided.
    /// </summary>
    [Range(18, 120)]
    public int? Age { get; set; }
}