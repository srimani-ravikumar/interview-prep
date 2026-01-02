using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BackendMastery.ProdReadiness.Authentication.Infrastructure.Jwt;

/// WHY: Validates JWTs issued by a trusted authority.
/// USE CASE: Stateless identity verification for users and services.
/// WARNING: Never relax validation rules in production.
public sealed class JwtTokenValidator
{
    private readonly JwtOptions _options;

    public JwtTokenValidator(JwtOptions options)
    {
        _options = options;
    }

    public ClaimsPrincipal Validate(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        var parameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _options.Issuer,

            ValidateAudience = true,
            ValidAudience = _options.Audience,

            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),

            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SigningKey))
        };

        return handler.ValidateToken(token, parameters, out _);
    }
}