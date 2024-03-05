using System.Net.Http.Json;
using Ardalis.Specification.EntityFrameworkCore;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Questions.Application.Queries;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;
using Xunit;

namespace Quizly.Modules.Questions.Tests.Integration.EndpointsTests.QuestionEndpointTests;

public sealed class GetQuestionListTests : QuestionsModuleTests
{
    [Fact]
    public async Task GetQuestionList_Should_Get_Questions()
    {
        var category = new Category(new CategoryId(Guid.NewGuid()), "TV Series", "TV Series", "IMG_PATH");
        var question = Question.CreateTextQuestion(
            new QuestionId(Guid.NewGuid()),
            category.Id,
            "Monica Geller is fictional character from",
            new List<Answer>()
            {
                new("TBBT", false),
                new("Friends", true),
                new("How I Met your mother", false),
                new("Suits", false),
            });

        await DbContext.Categories.AddAsync(category);
        await DbContext.Questions.AddAsync(question);
        await DbContext.SaveChangesAsync();

        var result = await Client.GetFromJsonAsync<GetQuestionListResponseDto>("api/question");
        result.Should().NotBeNull();

        var questionsDb = await DbContext.Questions.ToListAsync();
        result!.Items.Count.Should().Be(questionsDb.Count);
    }
}