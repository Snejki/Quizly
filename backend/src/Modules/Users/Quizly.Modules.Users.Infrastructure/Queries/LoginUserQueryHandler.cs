using MediatR;
using Microsoft.Extensions.Logging;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
{
    private readonly ILogger<LoginUserQueryHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;

    public LoginUserQueryHandler(ILogger<LoginUserQueryHandler> logger, 
        IUserRepository userRepository, 
        ITokenService tokenService, 
        IPasswordService passwordService)
    {
        _logger = logger;
        _userRepository = userRepository;
        _tokenService = tokenService;
        _passwordService = passwordService;
    }

    public async Task<LoginUserResponse> Handle(LoginUserQuery query, CancellationToken cancellationToken)
    {
         var login = new Login(query.Login);
        
         var user = await _userRepository.GetByLogin(login, cancellationToken);
         if (user is null)
         {
             throw new QuizlyException("");
         }
        
         var isPasswordValid = _passwordService.IsPasswordValid(query.Password, user.Password.Hash);
         if (isPasswordValid is false)
         {
             throw new QuizlyException("");
         }
        
        
         // TODO: check if is active;
        
         var token = _tokenService.GenerateToken(user.Id, user.Login);

        return new LoginUserResponse(token, user.Login.Value, user.Avatar?.Path);
    }
}