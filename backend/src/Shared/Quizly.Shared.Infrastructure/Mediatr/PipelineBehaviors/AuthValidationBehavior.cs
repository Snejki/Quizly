using MediatR;
using Microsoft.AspNetCore.Http;
using Quizly.Shared.Abstractions.Auth;

namespace Quizly.Shared.Infrastructure.Mediatr.PipelineBehaviors;

public class AuthValidationBehavior<TQuery, TResult> : IPipelineBehavior<TQuery, TResult> 
    where TQuery : class, IRequest<TResult>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public AuthValidationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResult> Handle(TQuery request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        if (request is IAuthenticated authenticatedRequest)
        {
            var identityName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
            authenticatedRequest.UserId = new Guid(identityName!);
        }
        
        return await next();
    }
}