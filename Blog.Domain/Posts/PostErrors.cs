using Blog.Domain.Abstractions;

namespace Blog.Domain.Posts;

public static class PostErrors
{
    public static Error NotFound = new(
       "Property.NotFound",
       "The property with the specified identifier was not found");
}
