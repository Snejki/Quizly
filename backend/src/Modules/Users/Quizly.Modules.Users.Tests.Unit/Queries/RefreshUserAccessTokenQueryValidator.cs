using System.Security.Claims;
using FluentAssertions;
using Microsoft.IdentityModel.JsonWebTokens;
using NSubstitute;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Modules.Users.Infrastructure.Queries;
using Quizly.Modules.Users.Tests.Shared.Builders;
using Quizly.Shared.Abstractions.Clock;

namespace Quizly.Modules.Users.Tests.Unit.Queries;

public sealed class RefreshUserAccessTokenQueryValidator
{
    private readonly RefreshUserAccessTokenQueryHandler _sut;
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IClock _clock = Substitute.For<IClock>();
    private readonly ITokenService _tokenService = Substitute.For<ITokenService>();

    public RefreshUserAccessTokenQueryValidator()
    {
        _sut = new RefreshUserAccessTokenQueryHandler(_userRepository, _clock, _tokenService);
    }

    [Fact]
    public async Task Handle_When_Provided_CorrectAccessToken_And_RefreshToken_Should_Return_New_AccessToken()
    {
        // arrange
        _tokenService.GetClaimsFromAccessToken(Arg.Any<string>()).Returns(Claims);
        _userRepository.GetById(Arg.Any<UserId>()).Returns(UserWithRefreshToken);
        _tokenService.GenerateAccessToken(Arg.Any<UserId>(), Arg.Any<Login>()).Returns("NEW_ACCESS_TOKEN");

        // act
        var result = await _sut.Handle(Query, CancellationToken.None);

        // assert
        result.AccessToken.Should().Be("NEW_ACCESS_TOKEN");
    }

    [Fact]
    public async Task Handle_When_Provided_Invalid_Token_Should_Throw_Exception()
    {
        // arrange
        // act and assert
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await _sut.Handle(Query, CancellationToken.None);
        });
    }

    [Fact]
    public async Task Handle_When_Provided_Correct_AccessToken_But_Not_Found_User_Should_Throw_Exception()
    {
        // arrange
        _tokenService.GetClaimsFromAccessToken(Arg.Any<string>()).Returns(Claims);

        // act and assert
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await _sut.Handle(Query, CancellationToken.None);
        });
    }

    [Fact]
    public async Task Handle_When_Provided_Incorrect_AccessToken_Should_Throw_Exception()
    {
        // arrange
        _tokenService.GetClaimsFromAccessToken(Arg.Any<string>()).Returns(Claims);
        _userRepository.GetById(Arg.Any<UserId>()).Returns(UserWithoutRefreshToken);

        // act and assert
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await _sut.Handle(Query, CancellationToken.None);
        });
    }

    private static RefreshUserAccessTokenQuery Query =>
        new("REFRESH_TOKEN", "ACCESS_TOKEN");

    private static User UserWithRefreshToken => new UserBuilder()
        .WithRefreshToken("REFRESH_TOKEN", DateTime.Now)
        .Build();

    private static User UserWithoutRefreshToken => new UserBuilder().Build();

    private static ClaimsPrincipal Claims => new(
        new ClaimsIdentity(new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, "USER_ID"),
            new(JwtRegisteredClaimNames.Name, "LOGIN"),
            new(JwtRegisteredClaimNames.NameId, "USER_ID"),
            new(ClaimTypes.Name, Guid.NewGuid().ToString()),
        }));
}