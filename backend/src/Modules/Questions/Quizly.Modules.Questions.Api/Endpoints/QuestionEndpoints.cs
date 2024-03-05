using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quizly.Modules.Questions.Application.Commands;
using Quizly.Modules.Questions.Application.Queries;
using Quizly.Shared.Abstractions.Endpoints;

namespace Quizly.Modules.Questions.Api.Endpoints;

// ReSharper disable once UnusedType.Global
public sealed class QuestionEndpoints : IEndpoint
{
    public void UseEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("api/question", async (AddQuestionRequestDto dto, IMediator mediator, CancellationToken ct) =>
        {
            await mediator.Send(new AddQuestionCommand(dto), ct);
            return Results.Ok();
        });

        app.MapGet("api/question", async (IMediator mediator, CancellationToken ct) =>
        {
            var result = await mediator.Send(new GetQuestionListQuery(), ct);
            return Results.Ok(result);
        });
    }
}