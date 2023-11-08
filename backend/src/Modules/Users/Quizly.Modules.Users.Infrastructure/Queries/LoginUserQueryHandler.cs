﻿using MediatR;
using Microsoft.Extensions.Logging;
using Quizly.Modules.Users.Application.Exceptions;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Modules.Users.Infrastructure.Mappers;
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
             throw new UserWithProvidedLoginNotFound();
         }
        
         var isPasswordValid = _passwordService.IsPasswordValid(query.Password, user.Password.Hash);
         if (isPasswordValid is false)
         {
             throw new IncorrectPassword();
         }
        
         // TODO return access token and refresh token and save refresh to database :P
         // TODO: check if is active;
        
         var accessToken = _tokenService.GenerateAccessToken(user.Id, user.Login);

         return user.ToLoginUserResponse(accessToken);
    }
}