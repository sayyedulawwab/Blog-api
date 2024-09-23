using Blog.Domain.Posts;

namespace Blog.Domain.Users;
public interface IUserRepository
{
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<User> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
    Task AddAsync(User user, CancellationToken cancellationToken = default);
    Task RemoveAsync(UserId id, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserId id, User post, CancellationToken cancellationToken = default);

}
