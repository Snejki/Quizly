using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Quizly.Shared.Abstractions.Auth;

namespace Quizly.Shared.Infrastructure.Auth;

internal static class AuthExtensions
{
    public static void AddCustomAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var tokenOptions = configuration.GetSection(JwtOptions.Path).Get<JwtOptions>();
        var key = Encoding.UTF8.GetBytes(tokenOptions!.Key);
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
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
            });
        
        services.AddAuthorization();
    }
}