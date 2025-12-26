namespace BackendMastery.CoreAPI.DTOContracts.Contracts;

/// <summary>
/// READ DTO (server → client)
/// Defines what client is allowed to see.
/// Intuition: DTOs are not “data holders” — they are contracts.
/// </summary>
public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}