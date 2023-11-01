using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Shared.Infrastructure.Exceptions;

internal class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleException(context, e);
        }    
    }
    
    private async Task HandleException(HttpContext context, Exception exception)
    {
        var errorModel = MapException(exception);
        context.Response.StatusCode = (int) errorModel.StatusCode;
        var response = errorModel?.Response;

        await context.Response.WriteAsJsonAsync(response);
    }

    private ErrorResponse MapException(Exception exception) => exception switch
    {
        QuizlyException e => new ErrorResponse(new Error(nameof(QuizlyException), e.Message), HttpStatusCode.BadRequest),
        ValidationException e => new ErrorResponse(new Error(nameof(ValidationException), e.Message), HttpStatusCode.BadRequest),
        _ => new ErrorResponse(new Error("unexpected_error", "There was an error"), HttpStatusCode.InternalServerError)
    };
}

internal record Error(string Code, string Message);

internal record ErrorResponse(object Response, HttpStatusCode StatusCode);