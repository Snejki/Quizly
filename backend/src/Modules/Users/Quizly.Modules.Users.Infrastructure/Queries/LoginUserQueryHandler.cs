using MediatR;
using Microsoft.Extensions.Logging;
using Quizly.Modules.Users.Application.Queries;

namespace Quizly.Modules.Users.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
{
    private readonly ILogger<LoginUserQueryHandler> _logger;

    public LoginUserQueryHandler(ILogger<LoginUserQueryHandler> logger)
    {
        _logger = logger;
    }

    public Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling LoginUserQueryHandler with {Request}", request);
        throw new NotImplementedException();
    }
}