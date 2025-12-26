using BackendMastery.CoreAPI.Validations.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.CoreAPI.Validations.Controllers;

[ApiController]
[Route("api/v1/validation")]
public class ValidationController : ControllerBase
{
    // ---------------------------------------
    // GENERAL VALIDATION (MANUAL)
    // ---------------------------------------

    /// <summary>
    /// Demonstrates MANUAL validation.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Validation is about rejecting bad input early.
    /// <br/>
    /// <b>Use case:</b> Lightweight endpoints, custom rules, non-DTO inputs.
    /// </remarks>
    [HttpPost("manual")]
    public IActionResult ManualValidation([FromBody] CreateUserRequest request)
    {
        // Explicit validation makes rules obvious and debuggable
        if (string.IsNullOrWhiteSpace(request.Email))
            return BadRequest("Email is required.");

        if (!request.Email.Contains("@"))
            return BadRequest("Email format is invalid.");

        if (request.Password.Length < 8)
            return BadRequest("Password must be at least 8 characters.");

        return Ok("Manual validation passed.");
    }

    // ---------------------------------------
    // ASP.NET CORE MODEL VALIDATION
    // ---------------------------------------

    /// <summary>
    /// Demonstrates automatic model validation using attributes.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Framework validates input before controller logic runs.
    /// <br/>
    /// <b>Use case:</b> Standard request validation across APIs.
    /// </remarks>
    [HttpPost("modelstate")]
    public IActionResult ModelStateValidation([FromBody] CreateUserRequest request)
    {
        // With [ApiController], invalid ModelState automatically returns 400
        return Ok("Model validation passed.");
    }

    // ---------------------------------------
    // MODELSTATE INSPECTION (EXPLICIT)
    // ---------------------------------------

    /// <summary>
    /// Demonstrates inspecting ModelState manually.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Gives control over how validation errors are returned.
    /// <br/>
    /// <b>Use case:</b> Custom error formats or logging validation failures.
    /// </remarks>
    [HttpPost("modelstate/inspect")]
    public IActionResult InspectModelState([FromBody] CreateUserRequest request)
    {
        if (!ModelState.IsValid)
        {
            // ModelState contains field-level validation errors
            return BadRequest(ModelState);
        }

        return Ok("Validated with explicit ModelState check.");
    }

    // ---------------------------------------
    // VALIDATION VS BUSINESS RULES
    // ---------------------------------------

    /// <summary>
    /// Demonstrates separation of validation and business rules.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Validation checks shape and safety, not meaning.
    /// <br/>
    /// <b>Use case:</b> Prevent mixing input checks with domain logic.
    /// </remarks>
    [HttpPost("validation-vs-business")]
    public IActionResult ValidationVsBusiness([FromBody] CreateUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // ❌ This is NOT validation (example)
        if (request.Email.EndsWith("@competitor.com"))
            return Conflict("Business rule violation.");

        return Ok("Input valid and business rules satisfied.");
    }
}