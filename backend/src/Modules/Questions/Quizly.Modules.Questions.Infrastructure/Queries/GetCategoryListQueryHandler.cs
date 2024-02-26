using MediatR;
using Quizly.Modules.Questions.Application.Queries;
using Quizly.Modules.Questions.Domain.Repositories;
using Quizly.Modules.Questions.Infrastructure.Mappers;

namespace Quizly.Modules.Questions.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
public sealed class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, GetCategoryListQueryResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryListQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryListQueryResponse> Handle(GetCategoryListQuery query, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetList(cancellationToken);
        return categories.ToResponseDto(categories.Count);


        // todo: specification pattern
        // todo: architecture tests to generic
    }
}