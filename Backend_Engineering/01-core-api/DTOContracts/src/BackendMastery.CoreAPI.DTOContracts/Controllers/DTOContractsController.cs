using BackendMastery.CoreAPI.DTOContracts.Contracts;
using BackendMastery.CoreAPI.DTOContracts.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.CoreAPI.DTOContracts.Controllers;

[ApiController]
[Route("api/v1/dto-contracts")]
public class DtoContractsController : ControllerBase
{
    // Simulated persistence
    private static readonly List<User> _users = new();

    // ---------------------------------------
    // ❌ BAD PRACTICE (for learning only)
    // ---------------------------------------

    /// <summary>
    /// BAD: Exposes domain entity directly.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Any change in domain breaks API clients.
    /// <br/>
    /// <b>Problem:</b> Leaks sensitive/internal fields.
    /// </remarks>
    [HttpGet("bad/users")]
    public IActionResult GetUsers_Bad()
    {
        return Ok(_users); // ❌ PasswordHash, IsAdmin exposed
    }

    // ---------------------------------------
    // ✅ GOOD PRACTICE (DTO boundary)
    // ---------------------------------------

    /// <summary>
    /// GOOD: Returns a response DTO.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> API exposes a stable, intentional contract.
    /// <br/>
    /// <b>Use case:</b> Public-facing or long-lived APIs.
    /// </remarks>
    [HttpGet("good/users")]
    public IActionResult GetUsers_Good()
    {
        var response = _users.Select(u => new UserResponse
        {
            Id = u.Id,
            Email = u.Email,
            CreatedAt = u.CreatedAt
        });

        return Ok(response);
    }

    // ---------------------------------------
    // WRITE CONTRACT
    // ---------------------------------------

    /// <summary>
    /// Creates a user using a request DTO.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Client sends intent, not internal structure.
    /// <br/>
    /// <b>Use case:</b> Prevent over-posting and security leaks.
    /// </remarks>
    [HttpPost("users")]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = $"HASH({request.Password})",
            IsAdmin = false, // Controlled internally
            CreatedAt = DateTime.UtcNow
        };

        _users.Add(user);

        var response = new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };

        return CreatedAtAction(nameof(GetUsers_Good), response);
    }
}