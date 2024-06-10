using MongoDB.Bson.Serialization;

namespace Blog.Domain.Posts;

public class PostIdSerializer : IBsonSerializer<PostId>
{
    public Type ValueType => typeof(PostId);

    public PostId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadString();
        return PostId.From(Guid.Parse(value));
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, PostId value)
    {
        context.Writer.WriteString(value.Value.ToString());
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
    {
        Serialize(context, args, (PostId)value);
    }

    object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        return Deserialize(context, args);
    }
}
