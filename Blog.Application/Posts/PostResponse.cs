namespace Blog.Application.Posts;
public sealed class PostResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime CreatedOn { get; init; }
}
