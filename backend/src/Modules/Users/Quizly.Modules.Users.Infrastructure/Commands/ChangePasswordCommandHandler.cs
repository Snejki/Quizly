using MediatR;
using Quizly.Modules.Users.Application.Commands;
using Quizly.Modules.Users.Application.Exceptions;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Repositories;

namespace Quizly.Modules.Users.Infrastructure.Commands;

// ReSharper disable once UnusedType.Global
internal sealed class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public ChangePasswordCommandHandler(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<Unit> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(new UserId(command.UserId), cancellationToken);
        if (user is null)
        {
            throw new UnauthorizedAccessException();
        }

        var isCurrentPasswordValid = _passwordService.IsPasswordValid(command.CurrentPassword, user.Password.Hash);
        if (isCurrentPasswordValid is false)
        {
            throw new IncorrectPasswordException();
        }

        var newPasswordHash = _passwordService.GeneratePasswordHash(command.NewPassword);
        user.ChangePassword(new Password(newPasswordHash));

        await _userRepository.Update(user, cancellationToken);

        return Unit.Value;
    }
}