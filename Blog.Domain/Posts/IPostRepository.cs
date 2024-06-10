namespace Blog.Domain.Posts;
public interface IPostRepository
{
    Task<IReadOnlyList<Post>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Post> GetByIdAsync(PostId id, CancellationToken cancellationToken = default);
    Task AddAsync(Post post, CancellationToken cancellationToken = default);
    Task RemoveAsync(PostId id, CancellationToken cancellationToken = default);
    Task UpdateAsync(PostId id, Post post, CancellationToken cancellationToken = default);
    
}
