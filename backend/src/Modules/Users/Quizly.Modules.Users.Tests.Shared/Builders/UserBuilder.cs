using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;

namespace Quizly.Modules.Users.Tests.Shared.Builders;

public sealed class UserBuilder
{
    public UserId UserId { get; private set; } = new(Guid.NewGuid());
    public Login Login { get; private set; } = new("LOGIN");
    public Email Email { get; private set; } = new("email@mail.com");
    public Password Password { get; private set; } = new("PASSWORD");
    public List<RefreshToken> RefreshTokens { get; private set; } = new();

    public UserBuilder WithLogin(string login)
    {
        Login = new Login(login);
        return this;
    }

    public UserBuilder WithEmail(string email)
    {
        Email = new Email(email);
        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        Password = new Password(password);
        return this;
    }

    public UserBuilder WithRefreshToken(string refreshToken, DateTime date)
    {
        RefreshTokens.Add(RefreshToken.Create(Guid.NewGuid(), UserId, refreshToken, date));
        return this;
    }

    public User Build()
    {
        var user = User.CreateWithEmailAndPassword(UserId, Login, Email, Password, DateTime.Now);

        foreach (var refreshToken in RefreshTokens)
        {
            user.AddRefreshToken(refreshToken);
        }

        return user;
    }
}