using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Users.Application.Dtos;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Xunit;

namespace Quizly.Modules.Users.Tests.Infrastructure.EndpointsTests.AuthEndpointsTests;

[ExcludeFromCodeCoverage]
public sealed class LoginUserTests : UsersModuleTests
{
    [Fact]
    public async Task LoginUser_When_Provided_Correct_Login_And_Password_Should_Login()
    {
        var email = $"{nameof(LoginUser_When_Provided_Correct_Login_And_Password_Should_Login)}@mail.com";
        var login = nameof(LoginUser_When_Provided_Correct_Login_And_Password_Should_Login);
        var password = "SOME_PASSWORD";

        await CreateUser(login, email, password);

        // arrange
        var request = new LoginUserRequestDto()
        {
            Login = login,
            Password = password,
        };

        // act
        var response = await Client.PostAsJsonAsync("auth/login", request);

        // assert
        response.EnsureSuccessStatusCode();
        var responseModel = await response.Content.ReadFromJsonAsync<LoginUserResponse>();
        responseModel.Should().NotBeNull();
        responseModel!.Login.Should().Be(login);
        responseModel.Token.Should().NotBeNullOrWhiteSpace();
    }

    private async Task CreateUser(string loginString, string emailString, string passwordString)
    {
        using (var scope = ServiceProvider.CreateScope())
        {
            var passwordService = scope.ServiceProvider.GetRequiredService<IPasswordService>();

            var userId = new UserId(Guid.NewGuid());
            var login = new Login(loginString);
            var email = new Email(emailString);
            var password = new Password(passwordService.GeneratePasswordHash(passwordString));

            var user = User.CreateWithEmailAndPassword(userId, login, email, password, DateTime.Now);

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();
        }
    }
}