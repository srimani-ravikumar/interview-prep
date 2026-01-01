using BackendMastery.Persistence.EFCore.CodeFirst.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.Persistence.EFCore.CodeFirst.Api.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _service;

    public OrdersController(OrderService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var id = await _service.CreateOrderAsync(1000);
        return CreatedAtAction(nameof(Create), new { id }, null);
    }
}