using Blog.Application.Abstractions.Messaging;

namespace Blog.Application.Posts.CreatePost;
public record CreatePostCommand(string title, string content, Guid authorId) : ICommand<Guid>;
