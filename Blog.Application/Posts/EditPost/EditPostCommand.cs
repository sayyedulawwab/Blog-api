using Blog.Application.Abstractions.Messaging;

namespace Blog.Application.Posts.EditPost;
public record EditPostCommand(Guid id, string title, string content) : ICommand<Guid>;
