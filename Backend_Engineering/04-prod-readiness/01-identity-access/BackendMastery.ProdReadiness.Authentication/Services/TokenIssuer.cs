using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BackendMastery.ProdReadiness.Authentication.Infrastructure.Jwt;

namespace BackendMastery.ProdReadiness.Authentication.Services;

/// WHY: Issues JWTs after successful authentication.
/// USE CASE: Exchange credentials for stateless identity.
/// WARNING: Token issuance is a security-critical operation.
public sealed class TokenIssuer
{
    private readonly JwtOptions _options;

    public TokenIssuer(JwtOptions options)
    {
        _options = options;
    }

    public string IssueToken(string subject, IDictionary<string, string> claims)
    {
        var jwtClaims = claims
            .Select(c => new Claim(c.Key, c.Value))
            .Append(new Claim(ClaimTypes.NameIdentifier, subject));

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_options.SigningKey));

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: jwtClaims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials:
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}