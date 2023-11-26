using FluentAssertions;
using NSubstitute;
using Quizly.Modules.Users.Application.Exceptions;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Modules.Users.Infrastructure.Queries;
using Serilog;

namespace Quizly.Modules.Users.Tests.Unit.Queries;

public sealed class LoginUserQueryHandlerTests
{
    private readonly LoginUserQueryHandler _sut;
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly ITokenService _tokenService = Substitute.For<ITokenService>();
    private readonly IPasswordService _passwordService = Substitute.For<IPasswordService>();

    public LoginUserQueryHandlerTests()
    {
        _sut = new LoginUserQueryHandler(_userRepository, _tokenService, _passwordService);
    }

    [Fact]
    public async Task Handle_Should_Return_User_When_Provided_CorrectData()
    {
        // arrange
        _userRepository.GetByLogin(Arg.Any<Login>()).Returns(User);
        _passwordService.IsPasswordValid(Arg.Any<string>(), Arg.Any<string>()).Returns(true);
        _tokenService.GenerateAccessToken(Arg.Any<UserId>(), Arg.Any<Login>()).Returns("TOKEN");

        // act
        var result = await _sut.Handle(Query, CancellationToken.None);

        // assert
        result.Login.Should().Be(Query.Login);
        result.Token.Should().Be("TOKEN");
    }

    [Fact]
    public async Task Handle_When_User_With_Provided_Login_Not_Exists_Should_Throw()
    {
        // arrange
        // act and assert
        await Assert.ThrowsAsync<UserWithProvidedLoginNotFoundException>(async () =>
        {
            await _sut.Handle(Query, CancellationToken.None);
        });
    }

    [Fact]
    public async Task Handle_When_Provided_Wrong_Password_Should_Throw()
    {
        // arrange
        _userRepository.GetByLogin(Arg.Any<Login>()).Returns(User);
        _passwordService.IsPasswordValid(Arg.Any<string>(), Arg.Any<string>()).Returns(false);

        // act and assert
        await Assert.ThrowsAsync<IncorrectPasswordException>(async () =>
        {
            await _sut.Handle(Query, CancellationToken.None);
        });
    }

    private static LoginUserQuery Query => new()
    {
        Login = "LOGIN",
        Password = "PASSWORD_HASH",
    };

    private static User User => User.CreateWithEmailAndPassword(
        new UserId(Guid.NewGuid()),
        new Login("LOGIN"),
        new Email("test@mail.com"),
        new Password("PASSWORD_HASH"),
        DateTime.Now);
}