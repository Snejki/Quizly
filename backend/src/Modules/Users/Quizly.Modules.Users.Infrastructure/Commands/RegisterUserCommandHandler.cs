using MediatR;
using Quizly.Modules.Users.Application.Commands;
using Quizly.Modules.Users.Application.Exceptions;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Shared.Abstractions.Clock;
using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Infrastructure.Commands;

// ReSharper disable once UnusedType.Global
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
{
    private readonly IClock _clock;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public RegisterUserCommandHandler(
        IClock clock,
        IUserRepository userRepository,
        IPasswordService passwordService)
    {
        _clock = clock;
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<Unit> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var login = new Login(command.Login);
        var email = new Email(command.Email);

        var user = await _userRepository.GetByEmail(email, cancellationToken);
        if (user is not null)
        {
            throw new UserWithProvidedEmailAlreadyExistsException(command.Email);
        }

        user = await _userRepository.GetByLogin(login, cancellationToken);
        if (user is not null)
        {
            throw new UserWithProvidedLoginAlreadyExistsException(command.Login);
        }

        var passwordHash = new Password(_passwordService.GeneratePasswordHash(command.Password));

        user = new User(new UserId(Guid.NewGuid()), login, email, passwordHash, _clock.Current);
        await _userRepository.Add(user, cancellationToken);

        // TODO: notifications

        return Unit.Value;
    }
}