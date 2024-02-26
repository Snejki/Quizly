using MediatR;
using Quizly.Modules.Questions.Application.Commands;
using Quizly.Modules.Questions.Application.Exceptions;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;
using Quizly.Modules.Questions.Domain.Repositories;

namespace Quizly.Modules.Questions.Infrastructure.Commands;

// ReSharper disable once UnusedType.Global
public sealed class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByName(command.Name, cancellationToken);
        if(category is not null)
        {
            throw new CategoryWithProvidedNameAlreadyExistsException();
        }

        category = Category.Creaate(new CategoryId(Guid.NewGuid()), command.Name, command.Description, command.ImagePath);

        await _categoryRepository.Add(category, cancellationToken);
        return Unit.Value;
    }
}