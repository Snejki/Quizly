using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Quizly.Shared.Abstractions.Endpoints;

namespace Quizly.Modules.Users.Api.Endpoints;

public class AuthEndpoints : IEndpoint
{
    public void UseEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("login", () => "OK");
    }
}