using MediatR;
using Quizly.Modules.Questions.Application.Queries;
using Quizly.Modules.Questions.Infrastructure.Mappers;
using Quizly.Modules.Questions.Infrastructure.Repositories;
using Quizly.Modules.Questions.Infrastructure.Specifications;

namespace Quizly.Modules.Questions.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
public sealed class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, GetCategoryListQueryResponse>
{
    private readonly ICategoryReadonlyRepository _categoryRepository;

    public GetCategoryListQueryHandler(ICategoryReadonlyRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryListQueryResponse> Handle(GetCategoryListQuery query, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.List(new GetOnlyActiveCategoriesSpecification(), cancellationToken);
        return categories.ToResponseDto(categories.Count);
        // todo: architecture tests to generic
    }
}