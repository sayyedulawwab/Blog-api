using Blog.Domain.Users;
using MongoDB.Driver;
using System.Threading;

namespace Blog.Infrastructure.Repositories;
internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext, "Users")
    {
    }

    public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {

        var filter = Builders<User>.Filter.Eq(e => e.Email, email);
        return await Collection.Find(filter).FirstOrDefaultAsync(cancellationToken);

    }

}
