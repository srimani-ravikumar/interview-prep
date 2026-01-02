using BackendMastery.ProdReadiness.Authentication.Contracts;
using BackendMastery.ProdReadiness.Authentication.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Authentication.Controllers;

/// WHY: Demonstrates identity propagation post-authentication.
/// USE CASE: Testing authentication without permissions.
/// WARNING: Never make access decisions here.
[ApiController]
[Route("identity")]
public sealed class IdentityProbeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var identity =
            HttpContext.Items["Identity"] as AuthenticatedIdentity;

        return Ok(new IdentityResponse(
            identity!.Subject,
            identity.AuthenticationScheme,
            identity.Claims));
    }
}