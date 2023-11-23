namespace Quizly.Shared.Abstractions.Auth;

// marker interface
public interface IAuthenticated
{
    Guid UserId { get; set; }
}