namespace Blog.Domain.Abstractions;

public abstract class Entity<TEntityId> : IEntity
{
    protected Entity(TEntityId id)
    {
        Id = id;
    }
    protected Entity()
    {
    }

    public TEntityId Id { get; init; }

}

