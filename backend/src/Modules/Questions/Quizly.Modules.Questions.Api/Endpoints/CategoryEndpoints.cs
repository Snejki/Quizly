using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quizly.Modules.Questions.Application.Commands;
using Quizly.Modules.Questions.Application.Queries;
using Quizly.Shared.Abstractions.Endpoints;

namespace Quizly.Modules.Questions.Api.Endpoints;

// ReSharper disable once UnusedType.Global
public class CategoryEndpoints : IEndpoint
{
    public void UseEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("api/category", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetCategoryListQuery());
            return Results.Ok(result);
        });

        app.MapPost("api/category", async (AddCategoryCommand command, IMediator mediator) =>
        {
            await mediator.Send(command);
            return Results.Ok();
        });
    }
}