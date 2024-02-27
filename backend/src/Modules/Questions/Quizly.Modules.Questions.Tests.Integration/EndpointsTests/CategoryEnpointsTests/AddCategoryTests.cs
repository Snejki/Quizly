using System.Net.Http.Json;
using FluentAssertions;
using Quizly.Modules.Questions.Application.Commands;
using Xunit;

namespace Quizly.Modules.Questions.Tests.Integration.EndpointsTests.CategoryEnpointsTests;

public sealed class AddCategoryTests : QuestionsModuleTests
{
    [Fact]
    public async Task Should_Create_New_Category_When_Provided_Correct_Data()
    {
        var command = new AddCategoryCommand("How i met your mother", "Movies category", "IMG_PATH");

        var response = await Client.PostAsJsonAsync("api/category", command);

        response.EnsureSuccessStatusCode();
        DbContext.Categories.FirstOrDefault(x => x.Name == command.Name).Should().NotBeNull();
    }
}