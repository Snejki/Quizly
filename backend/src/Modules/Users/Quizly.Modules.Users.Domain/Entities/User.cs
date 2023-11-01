namespace Quizly.Modules.Users.Domain.Entities;

public class User
{
    public UserId Id { get; }
    public Login Login { get; }
    public Email Email { get; }
    public Password Password { get; }

    public Avatar? Avatar { get; }

    public DateTime CreatedAt { get;  }
    public DateTime? ModifiedAt { get; }

    //private ICollection<Role> _roles;
    //public IReadOnlyCollection<Role> Roles => _roles;


    public User(UserId userId, Login login, Email email, Password password, DateTime? createdAt)
    {
        Id = userId ?? throw new NullReferenceException(nameof(userId));
        Login = login ?? throw new NullReferenceException(nameof(login));
        Email = email ?? throw new NullReferenceException(nameof(email));
        Password = password ?? throw new NullReferenceException(nameof(password));
        CreatedAt = createdAt ?? throw new NullReferenceException(nameof(createdAt));
    }

    public void ActivateUser()
    {
        
    }

    public void DeactivateUser()
    {
        
    }

    public void ChangePassword()
    {
        
    }

    public void ChangeAvatar()
    {
        
    }

    public void AddRole()
    {
        
    }

    public void RemoveRole()
    {
        
    }
}