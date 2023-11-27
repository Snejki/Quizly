using Quizly.Modules.Users.Application.Services;

namespace Quizly.Modules.Users.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    public string GeneratePasswordHash(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password);

    public bool IsPasswordValid(string password, string hash) =>
        BCrypt.Net.BCrypt.Verify(password, hash);
}