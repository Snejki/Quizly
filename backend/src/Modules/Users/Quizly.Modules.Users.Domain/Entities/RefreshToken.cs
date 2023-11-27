namespace Quizly.Modules.Users.Domain.Entities;

public sealed class RefreshToken
{
    public Guid Id { get; private set; }
    public UserId Userid { get; private set; }
    public string Token { get; private set; }
    public DateTime ValidTill { get; private set; }

    public static RefreshToken Create(Guid refreshTokenId, UserId userId, string token, DateTime validTill)
    {
        return new()
        {
            Id = refreshTokenId,
            Userid = userId,
            Token = token,
            ValidTill = validTill,
        };
    }

    public bool IsStillValid(DateTime currentTime)
    {
        return currentTime <= ValidTill;
    }

    private RefreshToken()
    {
    }
}