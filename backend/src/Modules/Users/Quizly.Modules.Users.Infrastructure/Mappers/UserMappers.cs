using Quizly.Modules.Users.Application.Commands;
using Quizly.Modules.Users.Application.Dtos;
using Quizly.Modules.Users.Application.Queries;
using Quizly.Modules.Users.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Quizly.Modules.Users.Infrastructure.Mappers;

internal static class UserToLoginUserResponseMapper
{
    public static LoginUserResponse ToLoginUserResponse(this User user, string accessToken)
    {
        return new LoginUserResponse(accessToken, user.Login.Value, user.Avatar?.Path);
    }
}

[Mapper]
public static partial class LoginUserRequestDtoToLoginUserQueryMapper
{
    public static LoginUserQuery ToLoginUserQuery(this LoginUserRequestDto request)
    {
        var mapped = request.ToLoginUserQueryInternal();
        return mapped;
    }
    
    // TODO Add generic Map for requests dto to queries/handlers :D
    private static partial LoginUserQuery ToLoginUserQueryInternal(this LoginUserRequestDto request);
}


[Mapper]
public static partial class ChangePasswordMapper
{
    public static ChangePasswordCommand ToCommand(this ChangePasswordRequestDto dto)
    {
        return dto.ToCommandInternal();
    }

    private static partial ChangePasswordCommand ToCommandInternal(this ChangePasswordRequestDto dto);
}

