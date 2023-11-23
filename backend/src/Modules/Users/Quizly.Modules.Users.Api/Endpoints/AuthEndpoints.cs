using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quizly.Modules.Users.Application.Dtos;
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
        
        // TODO: refresh tokens
        // TODO: mapperly
        // TODO:
        // https://steven-giesel.com/blogPost/f3f46814-06c9-41b7-84fa-09ebb3305ed0
        // directory build props for sonaranalyzer.scharp
        // https://medium.com/@michaelparkerdev/linting-c-in-2019-stylecop-sonar-resharper-and-roslyn-73e88af57ebd
        app.MapPost("auth/refresh", async (CancellationToken ct) => Results.Ok());
    }
}