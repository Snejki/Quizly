using MediatR;
using Quizly.Modules.Questions.Application.Commands;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;
using Quizly.Modules.Questions.Infrastructure.Repositories;

namespace Quizly.Modules.Questions.Infrastructure.Commands;

public sealed class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByName(command.Name);
        if(category is not null)
        {
            throw new Exception();
        }

        category = Category.Creaate(new CategoryId(Guid.NewGuid()), command.Name, command.Description, command.ImagePath);

        await _categoryRepository.Add(category);
        return Unit.Value;
    }
}