using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Questions.Application.Commands;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;
using Xunit;

namespace Quizly.Modules.Questions.Tests.Integration.EndpointsTests.QuestionEndpointTests;

public sealed class AddQuestionTests : QuestionsModuleTests
{
    [Fact]
    public async Task AddQuestion_Should_Add_Question()
    {
        var category = new Category(new CategoryId(Guid.NewGuid()), "TV Series", "TV Series", "IMG_PATH");

        await DbContext.Categories.AddAsync(category);
        await DbContext.SaveChangesAsync();

        var questionDto = new AddQuestionRequestDto()
        {
            CategoryId = category.Id.Id,
            Type = QuestionType.Text,
            QuestionText = "Monica Geller is fictional character from",
            Answers = new List<AddQuestionRequestDto.Answer>()
            {
                new() { Text = "TBBT", IsActive = false, },
                new() { Text = "Friends", IsActive = true, },
                new() { Text = "How I Met your mother", IsActive = false, },
                new() { Text = "Suits", IsActive = false, },
            },
        };

        var response = await Client.PostAsJsonAsync("api/question", questionDto);
        response.EnsureSuccessStatusCode();

        var questionDb = await DbContext.Questions.FirstOrDefaultAsync(x => x.QuestionText == questionDto.QuestionText);
        questionDb.Should().NotBeNull();
    }
}