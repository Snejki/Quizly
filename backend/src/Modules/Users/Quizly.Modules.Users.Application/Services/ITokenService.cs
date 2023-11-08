using Quizly.Modules.Users.Domain;

namespace Quizly.Modules.Users.Application.Services;

public interface ITokenService
{
    public string GenerateToken(UserId userId, Login login);
}