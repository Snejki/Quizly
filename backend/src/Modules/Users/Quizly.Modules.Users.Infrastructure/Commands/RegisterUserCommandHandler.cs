using MediatR;
using Quizly.Modules.Users.Application.Commands;
using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Infrastructure.Commands;

// ReSharper disable once UnusedType.Global
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
{
    public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new QuizlyException("Some quizly exception");
        return Unit.Value;
        
    }
}