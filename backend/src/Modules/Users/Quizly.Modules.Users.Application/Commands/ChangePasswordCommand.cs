using MediatR;
using Quizly.Shared.Abstractions.Auth;

namespace Quizly.Modules.Users.Application.Commands;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword) : IRequest<Unit>, IAuthenticated
{
    public Guid UserId { get; set; }
}