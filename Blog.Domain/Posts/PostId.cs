using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Domain.Posts;
public sealed class PostId
{
    [BsonRepresentation(BsonType.String)]
    public Guid Value { get; private set; }

    public PostId(Guid value)
    {
        Value = value;
    }

    public static PostId New() => new PostId(Guid.NewGuid());

    public static PostId From(Guid value) => new PostId(value);

    public override string ToString() => Value.ToString();
}