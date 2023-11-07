using MediatR;

namespace Quizly.Modules.Users.Application.Commands;

public record RegisterUserCommand(string Email, string Login, string Password, string ConfirmPassword) : IRequest<Unit>;