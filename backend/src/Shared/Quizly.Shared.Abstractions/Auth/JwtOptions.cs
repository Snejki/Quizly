namespace Quizly.Shared.Abstractions.Auth;

public class JwtOptions
{
    public const string Path = "Auth:JwtOptions";
    
    public string Key { get; set; }
    public string Issuer { get; set; }
    public int ExpiryTime { get; set; }
    public string Audience { get; set; }
}