namespace BackendMastery.CoreAPI.DTOContracts.Domain;

/// <summary>
/// Internal domain entity.
/// This represents how the system thinks about a User.
/// Intuition: Domain models evolve with business, not with API clients.
/// </summary>
public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty; // ❌ Never expose

    public bool IsAdmin { get; set; }          // ❌ Internal concern

    public DateTime CreatedAt { get; set; }
}