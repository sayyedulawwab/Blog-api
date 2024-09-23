using Blog.Domain.Abstractions;

namespace Blog.Domain.Users;
public sealed class User : Entity<UserId>
{
    private User(UserId id, string firstName, string lastName, string email, string passwordHash, string passwordSalt, bool isAdmin) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        IsAdmin = isAdmin;
    }

    private User()
    {
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    public bool IsAdmin { get; private set; }

    public static User Create(string firstName, string lastName, string email, string passwordHash, string passwordSalt, bool isAdmin)
    {
        var user = new User(UserId.New(), firstName, lastName, email, passwordHash, passwordSalt, isAdmin);

        return user;
    }
}
