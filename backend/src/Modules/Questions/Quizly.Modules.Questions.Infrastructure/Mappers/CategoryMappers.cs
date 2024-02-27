using Quizly.Modules.Questions.Application.Queries;

namespace Quizly.Modules.Questions.Infrastructure.Mappers;

public static class CategoryMappers
{
    public static GetCategoryListQueryResponse ToResponseDto(this List<GetCategoryListQueryResponse.Category> categories, int totalCount)
    {
        return new GetCategoryListQueryResponse()
        {
            Items = categories,
            TotalCount = totalCount,
        };
    }
}