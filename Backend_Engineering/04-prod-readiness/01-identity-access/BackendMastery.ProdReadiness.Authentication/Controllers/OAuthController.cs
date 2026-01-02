using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Authentication.Controllers;

/// WHY: Demonstrates OAuth2 / OpenID Connect flows.
/// USE CASE: Teaching separation of Identity Provider vs Resource Server.
/// WARNING: This is NOT a production OAuth server.
[ApiController]
[Route("oauth")]
public sealed class OAuthController : ControllerBase
{
    [HttpGet("authorize")]
    public IActionResult Authorize(
        string client_id,
        string redirect_uri,
        string response_type)
    {
        // Simulated user consent + auth code issuance
        return Redirect($"{redirect_uri}?code=AUTH_CODE_123");
    }

    [HttpPost("token")]
    public IActionResult Token(
        string code,
        string client_id,
        string client_secret)
    {
        // Simulated token exchange
        return Ok(new
        {
            access_token = "OAUTH_ACCESS_TOKEN",
            token_type = "Bearer",
            expires_in = 1800
        });
    }
}