using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quizly.Modules.Users.Application.Commands;
using Quizly.Modules.Users.Application.Dtos;
using Quizly.Modules.Users.Infrastructure.Mappers;
using Quizly.Shared.Abstractions.Endpoints;

namespace Quizly.Modules.Users.Api.Endpoints;

// ReSharper disable once UnusedType.Global
public class UserEndpoints : IEndpoint
{
    public void UseEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("user");

        group.MapPost("register", async (RegisterUserCommand command, IMediator mediator, CancellationToken ct) =>
        {
            await mediator.Send(command, ct);
            return Results.Created();
        });

        group.MapPost("change-password", async (ChangePasswordRequestDto dto, IMediator mediator, CancellationToken ct) =>
        {
            await mediator.Send(dto.ToCommand(), ct);
            return Results.Ok();
        }).RequireAuthorization();
    }
}