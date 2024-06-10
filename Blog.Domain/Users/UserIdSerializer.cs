using MongoDB.Bson.Serialization;

namespace Blog.Domain.Users;

public class UserIdSerializer : IBsonSerializer<UserId>
{
    public Type ValueType => typeof(UserId);

    public UserId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadString();
        return UserId.From(Guid.Parse(value));
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, UserId value)
    {
        context.Writer.WriteString(value.Value.ToString());
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
    {
        Serialize(context, args, (UserId)value);
    }

    object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        return Deserialize(context, args);
    }
}
