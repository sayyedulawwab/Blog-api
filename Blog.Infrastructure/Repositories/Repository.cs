using Blog.Domain.Abstractions;
using MongoDB.Driver;

namespace Blog.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TEntityId : class
{
    protected readonly IMongoCollection<TEntity> Collection;

    protected Repository(ApplicationDbContext context, string collectionName)
    {
        Collection = context.GetCollection<TEntity>(collectionName);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var filter = Builders<TEntity>.Filter.Empty;
        return await Collection.Find(filter).ToListAsync(cancellationToken);
    }

    public async Task<TEntity> GetByIdAsync(TEntityId id, CancellationToken cancellationToken = default)
    {
        var filter = Builders<TEntity>.Filter.Eq(e => e.Id, id);
        return await Collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(entity, null, cancellationToken);
    }

    public async Task RemoveAsync(TEntityId id, CancellationToken cancellationToken = default)
    {
        var filter = Builders<TEntity>.Filter.Eq(e => e.Id, id);
        await Collection.DeleteOneAsync(filter, cancellationToken);
    }

    public async Task UpdateAsync(TEntityId id, TEntity entity, CancellationToken cancellationToken = default)
    {
        var filter = Builders<TEntity>.Filter.Eq(e => e.Id, id);
        await Collection.ReplaceOneAsync(filter, entity, new ReplaceOptions(), cancellationToken);
    }
}
