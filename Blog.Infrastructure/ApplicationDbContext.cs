using Blog.Domain.Posts;
using Blog.Domain.Users;
using MongoDB.Driver;

namespace Blog.Infrastructure;
public sealed class ApplicationDbContext
{
    private readonly IMongoDatabase _database;

    public ApplicationDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    public IMongoCollection<Post> Posts => _database.GetCollection<Post>("Posts");

    public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName)
    {
        return _database.GetCollection<TEntity>(collectionName);
    }

}
