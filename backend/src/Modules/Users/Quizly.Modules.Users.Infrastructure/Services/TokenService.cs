using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Shared.Abstractions.Auth;
using Quizly.Shared.Abstractions.Clock;

namespace Quizly.Modules.Users.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;
    private readonly IClock _clock;

    public TokenService(IOptions<JwtOptions> jwtOptions, IClock clock)
    {
        _jwtOptions = jwtOptions.Value;
        _clock = clock;
    }

    public string GenerateAccessToken(UserId userId, Login login)
    {
        var key = Encoding.UTF8.GetBytes(_jwtOptions.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.Value.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, login.Value),
                new Claim(JwtRegisteredClaimNames.NameId, userId.Value.ToString()),
                new Claim(ClaimTypes.Name, userId.Value.ToString()),
            }),
            Expires = _clock.Current.AddHours(_jwtOptions.ExpiryTime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        return token;
    }

    public ClaimsPrincipal? GetClaimsFromAccessToken(string accessToken)
    {
        var key = Encoding.UTF8.GetBytes(_jwtOptions!.Key);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            //ValidateAudience = true,
            //ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //ValidIssuer = tokenOptions.Issuer,
            //ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            return null;
        }

        return principal;
    }
}