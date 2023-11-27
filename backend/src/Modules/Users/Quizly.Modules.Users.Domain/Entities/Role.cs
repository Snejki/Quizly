namespace Quizly.Modules.Users.Domain.Entities;

public sealed class Role
{
    public Guid Id { get; set; }

    public string Permission { get; set; }
}