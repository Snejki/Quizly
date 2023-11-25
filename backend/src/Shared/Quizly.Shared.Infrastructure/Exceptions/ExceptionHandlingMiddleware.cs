using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Quizly.Shared.Abstractions.Exceptions;
using ILogger = Serilog.ILogger;

namespace Quizly.Shared.Infrastructure.Exceptions;

internal class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            // TODO: log not every exception
            _logger.LogError("{Exception}", e);
            await HandleException(context, e);
        }
    }

    private async Task HandleException(HttpContext context, Exception exception)
    {
        var errorModel = MapException(exception);
        context.Response.StatusCode = (int)errorModel.StatusCode;
        var response = errorModel.Response;

        await context.Response.WriteAsJsonAsync(response);
    }

    private ErrorResponse MapException(Exception exception) => exception switch
    {
        QuizlyException e => new ErrorResponse(new Error(nameof(QuizlyException), e.Message), HttpStatusCode.BadRequest),
        ValidationException e => new ErrorResponse(new ValidationError(nameof(ValidationException), "Some field values are invalid", e.Errors), HttpStatusCode.BadRequest),
        _ => new ErrorResponse(new Error("unexpected_error", "There was an error"), HttpStatusCode.InternalServerError),
    };
}

internal record Error(string Code, string Message);
internal record ValidationError(string Code, string Message, IEnumerable<ValidationFailure> Errors);

internal record ErrorResponse(object Response, HttpStatusCode StatusCode);