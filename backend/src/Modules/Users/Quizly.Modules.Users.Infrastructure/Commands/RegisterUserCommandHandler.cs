using MediatR;
using Quizly.Modules.Users.Application.Commands;
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

    public RegisterUserCommandHandler(IClock clock, IUserRepository userRepository)
    {
        _clock = clock;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var login = new Login(request.Login);
        var email = new Email(request.Email);
        
        var user = await _userRepository.GetByEmail(email, cancellationToken);
        if (user is null)
        {
            throw new QuizlyException("");
        }

        user = await _userRepository.GetByLogin(login, cancellationToken);
        if (user is null)
        {
            throw new QuizlyException("");
        }

        // TODO: Password Hash
        var passwordHash = new Password(request.Password);

        user = new User(new UserId(Guid.NewGuid()), login, email, passwordHash, _clock.Current);
        await _userRepository.Add(user);
        
        // TODO: notifications
        
        return Unit.Value;
    }
}