using BackendMastery.ProdReadiness.SecretsManagement.Contracts;
using BackendMastery.ProdReadiness.SecretsManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.SecretsManagement.Controllers;

/// <summary>
/// WHY:
/// Shows that secrets never cross API boundaries.
///
/// WHAT BREAKS IF MISUSED:
/// Returning secret-derived data leaks credentials.
/// </summary>
[ApiController]
[Route("secure-ping")]
public sealed class SecurePingController : ControllerBase
{
    private readonly ExternalServiceClient _client;

    public SecurePingController(ExternalServiceClient client)
    {
        _client = client;
    }

    [HttpGet]
    public ActionResult<SecurePingResponse> Get()
    {
        return new SecurePingResponse
        {
            Status = _client.Ping()
        };
    }
}