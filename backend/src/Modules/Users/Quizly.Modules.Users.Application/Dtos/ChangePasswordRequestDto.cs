namespace Quizly.Modules.Users.Application.Dtos;

public record ChangePasswordRequestDto(string CurrentPassword, string NewPassword);
