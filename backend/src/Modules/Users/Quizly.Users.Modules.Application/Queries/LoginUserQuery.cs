using MediatR;

namespace Quizly.Users.Modules.Application.Queries;


public record LoginUserQuery(string Login, string Password) : IRequest<LoginUserResponse>;

public record LoginUserResponse(string Token);