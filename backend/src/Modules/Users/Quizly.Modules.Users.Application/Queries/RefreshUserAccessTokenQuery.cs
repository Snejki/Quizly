using MediatR;

namespace Quizly.Modules.Users.Application.Queries;

public record RefreshUserAccessTokenQuery(string RefreshToken, string AccessToken) : IRequest<RefreshUserAccessTokenQueryResponseDto>;

public record RefreshUserAccessTokenQueryResponseDto(string AccessToken);