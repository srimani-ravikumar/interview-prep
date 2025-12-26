using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.CoreAPI.RESTPrinciples.Controllers;

[ApiController]
[Route("api/v1/http-status-codes")]
public class HttpStatusCodesController : ControllerBase
{
    // ---------------------------------------
    // 2xx — SUCCESS
    // ---------------------------------------

    /// <summary>
    /// 200 OK
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Request succeeded and response contains data.
    /// <br/>
    /// <b>Use case:</b> Successful GET, PATCH responses.
    /// </remarks>
    [HttpGet("200")]
    public IActionResult OkExample()
    {
        return Ok(new { message = "Request processed successfully." });
    }

    /// <summary>
    /// 201 Created
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> New resource was successfully created.
    /// <br/>
    /// <b>Use case:</b> POST that creates users, orders, records.
    /// </remarks>
    [HttpPost("201")]
    public IActionResult CreatedExample()
    {
        return Created(
            "/api/v1/resources/123",
            new { id = 123, status = "created" });
    }

    /// <summary>
    /// 204 No Content
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Request succeeded but nothing to return.
    /// <br/>
    /// <b>Use case:</b> PUT or DELETE operations.
    /// </remarks>
    [HttpDelete("204")]
    public IActionResult NoContentExample()
    {
        return NoContent();
    }

    // ---------------------------------------
    // 3xx — REDIRECTION
    // ---------------------------------------

    /// <summary>
    /// 301 Moved Permanently
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Resource has a new permanent URI.
    /// <br/>
    /// <b>Use case:</b> API version migration.
    /// </remarks>
    [HttpGet("301")]
    public IActionResult MovedPermanentlyExample()
    {
        return RedirectPermanent("/api/v2/new-endpoint");
    }

    /// <summary>
    /// 304 Not Modified
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Client already has the latest version.
    /// <br/>
    /// <b>Use case:</b> Browser caching using ETag or Last-Modified.
    /// </remarks>
    [HttpGet("304")]
    public IActionResult NotModifiedExample()
    {
        return StatusCode(304);
    }

    // ---------------------------------------
    // 4xx — CLIENT ERRORS
    // ---------------------------------------

    /// <summary>
    /// 400 Bad Request
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Client sent invalid data.
    /// <br/>
    /// <b>Use case:</b> Validation failures, malformed JSON.
    /// </remarks>
    [HttpPost("400")]
    public IActionResult BadRequestExample()
    {
        return BadRequest("Invalid request payload.");
    }

    /// <summary>
    /// 401 Unauthorized
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Authentication required or failed.
    /// <br/>
    /// <b>Use case:</b> Missing or invalid JWT/token.
    /// </remarks>
    [HttpGet("401")]
    public IActionResult UnauthorizedExample()
    {
        return Unauthorized();
    }

    /// <summary>
    /// 403 Forbidden
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Authenticated but not allowed.
    /// <br/>
    /// <b>Use case:</b> Role/permission checks.
    /// </remarks>
    [HttpGet("403")]
    public IActionResult ForbiddenExample()
    {
        return Forbid();
    }

    /// <summary>
    /// 404 Not Found
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Requested resource does not exist.
    /// <br/>
    /// <b>Use case:</b> Invalid ID, missing record.
    /// </remarks>
    [HttpGet("404")]
    public IActionResult NotFoundExample()
    {
        return NotFound("Resource not found.");
    }

    /// <summary>
    /// 409 Conflict
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Request conflicts with current state.
    /// <br/>
    /// <b>Use case:</b> Duplicate records, optimistic concurrency.
    /// </remarks>
    [HttpPost("409")]
    public IActionResult ConflictExample()
    {
        return Conflict("Resource already exists.");
    }

    /// <summary>
    /// 429 Too Many Requests
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Client exceeded rate limits.
    /// <br/>
    /// <b>Use case:</b> API throttling, abuse protection.
    /// </remarks>
    [HttpGet("429")]
    public IActionResult TooManyRequestsExample()
    {
        Response.Headers.RetryAfter = "30";
        return StatusCode(429, "Too many requests. Try again later.");
    }

    // ---------------------------------------
    // 5xx — SERVER ERRORS
    // ---------------------------------------

    /// <summary>
    /// 500 Internal Server Error
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Server failed unexpectedly.
    /// <br/>
    /// <b>Use case:</b> Unhandled exceptions.
    /// </remarks>
    [HttpGet("500")]
    public IActionResult InternalServerErrorExample()
    {
        return StatusCode(500, "Something went wrong on the server.");
    }

    /// <summary>
    /// 503 Service Unavailable
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Server is temporarily unavailable.
    /// <br/>
    /// <b>Use case:</b> Maintenance, downstream dependency outage.
    /// </remarks>
    [HttpGet("503")]
    public IActionResult ServiceUnavailableExample()
    {
        Response.Headers.RetryAfter = "60";
        return StatusCode(503, "Service temporarily unavailable.");
    }
}