using BackendMastery.ProdReadiness.Authentication.Contracts;
using BackendMastery.ProdReadiness.Authentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Authentication.Controllers;

/// WHY: Handles credential-based authentication.
/// USE CASE: Humans exchanging credentials for tokens.
/// WARNING: This endpoint authenticates identity ONLY.
[ApiController]
[Route("auth")]
public sealed class AuthController : ControllerBase
{
    private readonly CredentialAuthenticationService _auth;
    private readonly TokenIssuer _issuer;

    public AuthController(
        CredentialAuthenticationService auth,
        TokenIssuer issuer)
    {
        _auth = auth;
        _issuer = issuer;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        if (!_auth.Validate(request.Username, request.Password))
            return Unauthorized();

        var token = _issuer.IssueToken(
            request.Username,
            new Dictionary<string, string>
            {
                ["auth_method"] = "password",
                ["identity_type"] = "user"
            });

        return Ok(new TokenResponse(token));
    }
}