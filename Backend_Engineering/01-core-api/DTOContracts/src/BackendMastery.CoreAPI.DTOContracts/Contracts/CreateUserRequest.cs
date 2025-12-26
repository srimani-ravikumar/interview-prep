namespace BackendMastery.CoreAPI.DTOContracts.Contracts;

/// <summary>
/// WRITE DTO (client → server)
/// Defines what client is allowed to send.
/// Intuition: DTOs are not “data holders” — they are contracts.
/// </summary>
public class CreateUserRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}