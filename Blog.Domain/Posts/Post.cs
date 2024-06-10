using Blog.Domain.Abstractions;
using Blog.Domain.Users;

namespace Blog.Domain.Posts;

public sealed class Post : Entity<PostId>
{
    private Post(PostId id, string title, string content, UserId authorId, DateTime createdOn) : base(id)
    {
        Title = title;
        Content = content;
        AuthorId = authorId;
        CreatedOn = createdOn;
    }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime? UpdatedOn { get; private set; }
    public UserId AuthorId { get; private set; }


    public static Post Create(string title, string content, UserId authorId, DateTime createdOn)
    {
        var post = new Post(PostId.New(), title, content, authorId, createdOn);

        return post;
    }

    public static Post Update(Post post, string title, string content, DateTime updatedOn)
    {
        post.Title = title;
        post.Content = content;
        post.UpdatedOn = updatedOn;

        return post;
    }
}
