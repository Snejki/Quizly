using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Shared.Abstractions.Endpoints;

namespace Quizly.Modules.Users.Api.Endpoints;

// ReSharper disable once UnusedType.Global
public class AuthEndpoints : IEndpoint
{
    public void UseEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/login", async (LoginUserQuery query, IMediator mediator, CancellationToken ct) =>
        {
            var response = await mediator.Send(query, ct);
            return Results.Ok(response);
        });
        
        // TODO: refresh tokens
    }
}