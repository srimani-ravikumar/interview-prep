using BackendMastery.Architecture.DependencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.Architecture.DependencyInjection.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    /// <summary>
    /// Controller depends only on abstraction.
    /// </summary>
    /// <remarks>
    /// Intuition:
    /// - Controller should orchestrate, not construct.
    ///
    /// Use case:
    /// - Easy unit testing
    /// - Clear responsibility
    /// </remarks>
    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(string product)
    {
        _service.CreateOrder(product);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetOrders());
    }
}