using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quizly.Modules.Users.Application.Dtos;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Infrastructure.Mappers;
using Quizly.Shared.Abstractions.Endpoints;

namespace Quizly.Modules.Users.Api.Endpoints;

// ReSharper disable once UnusedType.Global
public class AuthEndpoints : IEndpoint
{
    public void UseEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/login", async (LoginUserRequestDto dto, IMediator mediator, CancellationToken ct) =>
        {
            var response = await mediator.Send(dto.ToLoginUserQuery(), ct);
            return Results.Ok(response);
        });

        app.MapPost("auth/refresh", async (RefreshTokenRequestDto dto, IMediator mediator, CancellationToken ct) =>
        {
            var query = new RefreshUserAccessTokenQuery(dto.RefreshToken, dto.AccessToken);
            var result = await mediator.Send(query, ct);

            return Results.Ok(result);
        });
    }
}