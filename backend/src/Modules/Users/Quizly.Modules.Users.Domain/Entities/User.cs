﻿namespace Quizly.Modules.Users.Domain.Entities;

public class User
{
    public UserId Id { get; private set; }

    public Login Login { get; private set; }

    public Email Email { get; private set; }

    public Password Password { get; private set; }

    public Avatar? Avatar { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? ModifiedAt { get; private set; }

    public User(UserId userId, Login login, Email email, Password password, DateTime? createdAt)
        : base()
    {
        Id = userId ?? throw new NullReferenceException(nameof(userId));
        Login = login ?? throw new NullReferenceException(nameof(login));
        Email = email ?? throw new NullReferenceException(nameof(email));
        Password = password ?? throw new NullReferenceException(nameof(password));
        CreatedAt = createdAt ?? throw new NullReferenceException(nameof(createdAt));
    }

    // ReSharper disable once UnusedMember.Local
    private User()
    {
    }

    public void ActivateUser()
    {
        throw new NotImplementedException();
    }

    public void DeactivateUser()
    {
        throw new NotImplementedException();
    }

    public void ChangePassword(Password? newPassword)
    {
        Password = newPassword ?? throw new NullReferenceException(nameof(Password));
    }

    public void ChangeAvatar()
    {
        throw new NotImplementedException();
    }

    public void AddRole()
    {
        throw new NotImplementedException();
    }

    public void RemoveRole()
    {
        throw new NotImplementedException();
    }
}