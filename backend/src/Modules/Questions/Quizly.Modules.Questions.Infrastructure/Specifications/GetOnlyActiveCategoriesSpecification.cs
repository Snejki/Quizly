using Ardalis.Specification;
using Quizly.Modules.Questions.Application.Queries;
using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Infrastructure.Specifications;

public sealed class GetOnlyActiveCategoriesSpecification : Specification<Category, GetCategoryListQueryResponse.Category>
{
    public GetOnlyActiveCategoriesSpecification()
    {
        Query.Where(x => x.IsActive);
        Query.Select(x => new GetCategoryListQueryResponse.Category()
        {
            IsActive = x.IsActive,
            Id = x.Id.Id,
            Name = x.Name
        });
    }
}