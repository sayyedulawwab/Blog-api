using Blog.Domain.Posts;

namespace Blog.Infrastructure.Repositories;
internal sealed class PostRepository : Repository<Post, PostId>, IPostRepository
{
    public PostRepository(ApplicationDbContext dbContext) : base(dbContext, "Posts")
    {
    }
   
}
