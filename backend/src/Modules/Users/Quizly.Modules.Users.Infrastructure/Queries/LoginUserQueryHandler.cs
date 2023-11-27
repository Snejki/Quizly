using MediatR;
using Quizly.Modules.Users.Application.Exceptions;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Modules.Users.Infrastructure.Mappers;
using Quizly.Shared.Abstractions.Clock;

namespace Quizly.Modules.Users.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
internal sealed class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IClock _clock;

    public LoginUserQueryHandler(
        IUserRepository userRepository,
        ITokenService tokenService,
        IPasswordService passwordService,
        IClock clock)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _passwordService = passwordService;
        _clock = clock;
    }

    public async Task<LoginUserResponse> Handle(LoginUserQuery query, CancellationToken cancellationToken)
    {
         var login = new Login(query.Login);

         var user = await _userRepository.GetByLogin(login, cancellationToken);
         if (user is null)
         {
             throw new UserWithProvidedLoginNotFoundException();
         }

         var isPasswordValid = _passwordService.IsPasswordValid(query.Password, user.Password.Hash);
         if (!isPasswordValid)
         {
             throw new IncorrectPasswordException();
         }

         var accessToken = _tokenService.GenerateAccessToken(user.Id, user.Login);
         var refreshToken = PrepareRefreshToken(user.Id);

         user.AddRefreshToken(refreshToken);
         await _userRepository.Update(user, cancellationToken);

         return user.ToLoginUserResponse(accessToken, refreshToken.Token);
    }

    private RefreshToken PrepareRefreshToken(UserId userId)
    {
        return RefreshToken.Create(Guid.NewGuid(), userId, Guid.NewGuid().ToString("N"), _clock.Current.AddMonths(2));
    }
}