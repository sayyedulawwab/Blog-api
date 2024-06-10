using Blog.Domain.Abstractions;

namespace Blog.Domain.Users;

public sealed class User : Entity<UserId>
{
    private User(UserId id, string email, string passwordHash, DateTime createdOn) : base(id)
    {
        Email = email;
        PasswordHash = passwordHash;
        CreatedOn = createdOn;
    }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime? UpdatedOn { get; private set; }
    public List<string> PostIds { get; private set; } = new List<string>();

    public static User Create(string email, string passwordHash, DateTime createdOn)
    {
        var user = new User(UserId.New(), email, passwordHash, createdOn);

        return user;
    }
}
