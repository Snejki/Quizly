using MediatR;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Shared.Abstractions.Clock;

namespace Quizly.Modules.Users.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
internal sealed class RefreshUserAccessTokenQueryHandler : IRequestHandler<RefreshUserAccessTokenQuery, RefreshUserAccessTokenQueryResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IClock _clock;
    private readonly ITokenService _tokenService;

    public RefreshUserAccessTokenQueryHandler(
        IUserRepository userRepository,
        IClock clock,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _clock = clock;
        _tokenService = tokenService;
    }

    public async Task<RefreshUserAccessTokenQueryResponseDto> Handle(RefreshUserAccessTokenQuery query, CancellationToken cancellationToken)
    {
        var principal = _tokenService.GetClaimsFromAccessToken(query.AccessToken);
        if (principal is null || string.IsNullOrWhiteSpace(principal.Identity?.Name))
        {
            throw new Exception();
        }

        var userId = new UserId(new Guid(principal.Identity.Name));
        var user = await _userRepository.GetById(userId, cancellationToken);
        if (user is null)
        {
            throw new Exception();
        }

        var refreshToken = user.FindRefreshToken(query.RefreshToken, _clock.Current);
        if (refreshToken is null)
        {
            throw new Exception();
        }

        var accessToken = _tokenService.GenerateAccessToken(user.Id, user.Login);

        return new RefreshUserAccessTokenQueryResponseDto(accessToken);
    }
}