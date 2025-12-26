using BackendMastery.CoreAPI.ErrorHandling.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.CoreAPI.ErrorHandling.Controllers;

[ApiController]
[Route("api/v1/errors")]
public class ErrorHandlingController : ControllerBase
{
    private readonly ProductService _service = new();

    [HttpGet("fail-fast/{id}")]
    public IActionResult FailFast(string id)
    {
        var product = _service.GetProductFailFast(id);
        return Ok(product);
    }

    [HttpGet("fail-safe/{id}")]
    public IActionResult FailSafe(string id)
    {
        var product = _service.GetProductFailSafe(id);
        return Ok(product);
    }
}