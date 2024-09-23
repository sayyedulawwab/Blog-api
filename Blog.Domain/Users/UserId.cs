using Blog.Domain.Posts;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Blog.Domain.Users;

public sealed class UserId
{
    [BsonRepresentation(BsonType.String)]
    public Guid Value { get; private set; }

    public UserId(Guid value)
    {
        Value = value;
    }

    public static UserId New() => new UserId(Guid.NewGuid());

    public static UserId From(Guid value) => new UserId(value);

    public override string ToString() => Value.ToString();
}


