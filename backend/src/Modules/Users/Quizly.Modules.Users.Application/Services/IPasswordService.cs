namespace Quizly.Modules.Users.Application.Services;

public interface IPasswordService
{
    string GeneratePasswordHash(string password);

    bool IsPasswordValid(string password, string hash);
}