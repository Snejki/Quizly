using MediatR;

namespace Quizly.Modules.Users.Application.Queries;

public class LoginUserQuery : IRequest<LoginUserResponse>
{
    public string Login { get; set; }
    public string Password { get; set; }
}

public record LoginUserResponse(string Token, string Login, string? AvatarPath);