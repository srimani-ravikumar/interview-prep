using BackendMastery.ProdReadiness.Validation.Contracts.Requests;
using BackendMastery.ProdReadiness.Validation.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Validation.Controllers;

/// <summary>
/// INTUITION:
/// Controllers enforce input correctness, not business decisions.
///
/// USE CASE:
/// Reject invalid input before it reaches deeper layers.
///
/// FAILURE MODE:
/// Skipping validation causes defensive logic everywhere.
/// </summary>
[ApiController]
[Route("api/v1/orders")]
public sealed class OrdersController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] CreateOrderRequest request)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(request.CustomerId))
            errors["customerId"] = new[] { "CustomerId is required." };

        if (request.Amount <= 0)
            errors["amount"] = new[] { "Amount must be greater than zero." };

        if (errors.Any())
        {
            /*
             WHY:
             Validation errors are returned, not thrown.
             */
            return BadRequest(ValidationErrorFactory.Create(errors));
        }

        return Ok(new { Status = "Accepted" });
    }
}