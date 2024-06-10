using Blog.Application.Abstractions.Messaging;

namespace Blog.Application.Posts.DeletePost;
public record DeletePostCommand(Guid id) : ICommand<Guid>;
