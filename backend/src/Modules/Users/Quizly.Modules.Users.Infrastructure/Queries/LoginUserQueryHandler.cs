using MediatR;
using Quizly.Modules.Users.Application.Queries;

namespace Quizly.Modules.Users.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
{
    public Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}