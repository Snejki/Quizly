using MediatR;
using Quizly.Modules.Users.Application.Queries;

namespace Quizly.Modules.Users.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
internal sealed class RefreshUserAccessTokenQueryHandler : IRequestHandler<RefreshUserAccessTokenQuery, RefreshUserAccessTokenQueryResponseDto>
{
    public Task<RefreshUserAccessTokenQueryResponseDto> Handle(RefreshUserAccessTokenQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}