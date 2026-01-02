using BackendMastery.ProdReadiness.Authorization.Authorization;
using BackendMastery.ProdReadiness.Authorization.Authorization.Requirements;
using BackendMastery.ProdReadiness.Authorization.Contracts;
using BackendMastery.ProdReadiness.Authorization.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Authorization.Controllers;

/// WHY: Demonstrates authorization usage without embedding rules.
/// USE CASE: Resource-based authorization.
/// WARNING: Controllers must never contain security logic.
[ApiController]
[Route("orders")]
public sealed class OrdersController : ControllerBase
{
    private readonly AuthorizationService _authz;

    public OrdersController(AuthorizationService authz)
    {
        _authz = authz;
    }

    [HttpGet("{orderId}")]
    public IActionResult GetOrder(string orderId)
    {
        // Simulated resource
        var order = new OrderResponse(
            OrderId: orderId,
            OwnerId: "alice",
            Status: "CREATED");

        var identity =
            HttpContext.Items["Identity"] as AuthenticatedIdentity;

        var decision = _authz.Authorize(
            new AuthorizationContext(identity!, order),
            new OwnershipRequirement<OrderResponse>(o => o.OwnerId));

        if (!decision.IsAllowed)
            return Forbid(decision.Reason);

        return Ok(order);
    }
}