using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quizly.Modules.Users.Application.Commands;
using Quizly.Shared.Abstractions.Endpoints;

namespace Quizly.Modules.Users.Api.Endpoints;

// ReSharper disable once UnusedType.Global
public class UserEndpoints : IEndpoint
{
    public void UseEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("user/register", async (RegisterUserCommand command, IMediator mediator, CancellationToken ct) =>
        {
            await mediator.Send(command, ct);
            return Results.Created();
        });
    }
}   