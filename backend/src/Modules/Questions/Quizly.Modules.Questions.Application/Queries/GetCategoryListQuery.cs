using MediatR;

namespace Quizly.Modules.Questions.Application.Queries;

public record GetCategoryListQuery() : IRequest<GetCategoryListQueryResponse>;

public class GetCategoryListQueryResponse
{
    public List<Category> Items { get; set; }
    public int TotalCount { get; set; }

    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}