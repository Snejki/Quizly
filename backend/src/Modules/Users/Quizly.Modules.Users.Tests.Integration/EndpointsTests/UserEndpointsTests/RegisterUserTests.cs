using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Users.Application.Commands;
using Xunit;

namespace Quizly.Modules.Users.Tests.Infrastructure.EndpointsTests.UserEndpointsTests;

[ExcludeFromCodeCoverage]
public sealed class RegisterUserTests : UsersModuleTests
{
    [Fact]
    public async Task RegisterUser_When_Provided_Correct_Data_Should_Add_User_To_Database()
    {
        // arrange
        var email = "testuser@mail.com";
        var login = "testUserLogin";
        var password = "testPassword";

        var requestBody = new RegisterUserCommand(email, login, password, password);

        // act
        var result = await Client.PostAsJsonAsync("api/user/register", requestBody);

        // assert
        result.EnsureSuccessStatusCode();
        var createdUser = await DbContext.Users.FirstOrDefaultAsync(x => x.Email.Value == email);
        createdUser.Should().NotBeNull();
    }
}