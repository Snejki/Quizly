using MediatR;

namespace Quizly.Modules.Users.Application.Queries;


public record LoginUserQuery(string Login, string Password) : IRequest<LoginUserResponse>;

public record LoginUserResponse(string Token);