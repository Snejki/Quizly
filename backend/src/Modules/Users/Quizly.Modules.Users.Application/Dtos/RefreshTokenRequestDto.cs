﻿namespace Quizly.Modules.Users.Application.Dtos;

public class RefreshTokenRequestDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}