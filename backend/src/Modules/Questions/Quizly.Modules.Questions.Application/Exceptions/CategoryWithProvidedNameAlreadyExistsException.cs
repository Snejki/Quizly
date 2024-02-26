using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Questions.Application.Exceptions;

public class CategoryWithProvidedNameAlreadyExistsException : QuizlyException
{
    public CategoryWithProvidedNameAlreadyExistsException()
        : base("Category with provided name already exists")
    {
    }
}