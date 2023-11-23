using FluentAssertions;
using NSubstitute;
using Quizly.Modules.Users.Application.Commands;
using Quizly.Modules.Users.Application.Exceptions;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Modules.Users.Infrastructure.Commands;
using Quizly.Shared.Abstractions.Clock;

namespace Quizly.Modules.Users.Tests.Unit.Commands;

public class RegisterUserCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenProvidedCorrectData_Should_Return_Task()
    {
        // arrange
        // act
        var result = await _sut.Handle(Command, CancellationToken.None);

        // assert
        result.Should().Be(MediatR.Unit.Value);
    }

    [Fact]
    public async Task Handle_WhenUserWithProvidedEmailExists_ShouldThrowException()
    {
        // arrange
        _userRepository.GetByEmail(Arg.Any<Email>()).Returns(User);

        // act and assert
        await Assert.ThrowsAsync<UserWithProvidedEmailAlreadyExists>(async () =>
        {
            await _sut.Handle(Command, CancellationToken.None);
        });
    }

    [Fact]
    public async Task Handle_WhenUserWithProvidedLoginExists_ShouldThrowException()
    {
        // arrange
        _userRepository.GetByLogin(Arg.Any<Login>()).Returns(User);

        // act and assert
        await Assert.ThrowsAsync<UserWithProvidedLoginAlreadyExists>(async () =>
        {
            await _sut.Handle(Command, CancellationToken.None);
        });
    }

    private static User User => new(
        new UserId(Guid.NewGuid()),
        new Login("LOGIN"),
        new Email("test@mail.com"),
        new Password("PASSWORD_HASH"),
        DateTime.Now);

    private static RegisterUserCommand Command => new("test@mail.com", "LOGIN", "PASSWORD", "PASSWORD");

    private readonly RegisterUserCommandHandler _sut;
    private readonly IClock _clock = Substitute.For<IClock>();
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IPasswordService _passwordService = Substitute.For<IPasswordService>();

    public RegisterUserCommandHandlerTests()
    {
        _sut = new RegisterUserCommandHandler(_clock, _userRepository, _passwordService);
    }
}