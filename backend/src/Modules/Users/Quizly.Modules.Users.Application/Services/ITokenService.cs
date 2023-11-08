using Quizly.Modules.Users.Domain;

namespace Quizly.Modules.Users.Application.Services;

public interface ITokenService
{
    public string GenerateAccessToken(UserId userId, Login login);
}