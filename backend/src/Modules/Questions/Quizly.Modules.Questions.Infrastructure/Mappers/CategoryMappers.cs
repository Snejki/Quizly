using Quizly.Modules.Questions.Application.Queries;
using Quizly.Modules.Questions.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Quizly.Modules.Questions.Infrastructure.Mappers;

[Mapper]
public static partial class CategoryMappers
{
    public static GetCategoryListQueryResponse ToResponseDto(this List<Category> categories, int totalCount)
    {
        return new GetCategoryListQueryResponse()
        {
            Items = categories.Select(x => x.ToResponseDtoInternal()).ToList(),
            TotalCount = totalCount
        };
    }

    private static partial GetCategoryListQueryResponse.Category ToResponseDtoInternal(this Category category);
}