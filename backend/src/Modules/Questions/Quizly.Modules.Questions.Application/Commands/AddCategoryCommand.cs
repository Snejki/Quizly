using MediatR;

namespace Quizly.Modules.Questions.Application.Commands;

public sealed record AddCategoryCommand(string Name, string Description, string ImagePath) : IRequest<Unit>;