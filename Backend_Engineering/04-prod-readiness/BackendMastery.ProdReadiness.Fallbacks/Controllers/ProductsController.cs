using BackendMastery.ProdReadiness.Fallbacks.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Fallbacks.Controllers;

/// <summary>
/// Product API.
///
/// WHY THIS EXISTS:
/// Demonstrates visible, controlled degradation.
///
/// WHAT BREAKS IF MISUSED:
/// Controllers should not implement fallback logic.
/// </summary>
[ApiController]
[Route("api/products")]
public sealed class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(
        string id,
        CancellationToken cancellationToken)
    {
        var product = await _service
            .GetAsync(id, cancellationToken);

        return Ok(product);
    }
}